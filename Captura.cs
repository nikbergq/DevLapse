using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpAvi;
using SharpAvi.Codecs;
using SharpAvi.Output;

namespace DevLapse;

public class WindowInfo
{
    public IntPtr Handle { get; set; }
    public string Title { get; set; }

    public override string ToString() => Title;
}

public static class WindowEnumerator
{
    [DllImport("user32.dll")]
    private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

    [DllImport("user32.dll")]
    private static extern bool IsWindowVisible(IntPtr hWnd);

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

    [DllImport("user32.dll")]
    private static extern int GetWindowTextLength(IntPtr hWnd);

    private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

    public static List<WindowInfo> GetOpenWindows()
    {
        var windows = new List<WindowInfo>();
        EnumWindows((hWnd, lParam) =>
        {
            if (!IsWindowVisible(hWnd))
                return true;

            int length = GetWindowTextLength(hWnd);
            if (length == 0)
                return true;

            var sb = new StringBuilder(length + 1);
            GetWindowText(hWnd, sb, sb.Capacity);
            windows.Add(new WindowInfo { Handle = hWnd, Title = sb.ToString() });
            return true;
        }, IntPtr.Zero);

        return windows;
    }
}

public class RecorderParams
{
    private readonly string _fileName;

    public double TimeInterval { get; }
    public IntPtr WindowHandle { get; }
    public int FramesPerSecond { get; }
    public int Quality { get; }
    public int Height { get; }
    public int Width { get; }

    public RecorderParams(double timeInterval, string fileName, int framesPerSecond, int quality, IntPtr windowHandle)
    {
        TimeInterval = timeInterval;
        FramesPerSecond = framesPerSecond;
        _fileName = fileName;
        Quality = quality;
        WindowHandle = windowHandle;

        if (windowHandle == IntPtr.Zero)
        {
            Height = Screen.PrimaryScreen.Bounds.Height;
            Width = Screen.PrimaryScreen.Bounds.Width;
        }
        else
        {
            NativeMethods.GetWindowRect(windowHandle, out var rect);
            Width = rect.Right - rect.Left;
            Height = rect.Bottom - rect.Top;
        }
    }

    public AviWriter CreateAviWriter()
    {
        return new AviWriter(_fileName)
        {
            FramesPerSecond = FramesPerSecond,
            EmitIndex1 = true,
        };
    }

    public IAviVideoStream CreateVideoStream(AviWriter writer)
    {
        var encoder = new MJpegWpfVideoEncoder(Width, Height, Quality);
        return writer.AddEncodingVideoStream(encoder, true, Width, Height);
    }
}

internal static class NativeMethods
{
    public const uint RenderFullContent = 0x00000002;

    [DllImport("user32.dll")]
    public static extern bool GetWindowRect(IntPtr hWnd, out WindowRect lpRect);

    [DllImport("user32.dll")]
    public static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, uint nFlags);

    [StructLayout(LayoutKind.Sequential)]
    public struct WindowRect
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
}

public class Recorder : IDisposable
{
    private readonly AviWriter _writer;
    private readonly RecorderParams _recorderParams;
    private readonly IAviVideoStream _videoStream;
    private readonly Thread _screenThread;
    private readonly ManualResetEvent _stopThread = new ManualResetEvent(false);
    private readonly Bitmap _screenBmp;
    private readonly Graphics _screenGraphics;
    private bool _isDisposed;

    public Recorder(RecorderParams recorderParams)
    {
        _recorderParams = recorderParams;
        _writer = recorderParams.CreateAviWriter();
        _videoStream = recorderParams.CreateVideoStream(_writer);
        _videoStream.Name = "Captura";

        _screenBmp = new Bitmap(recorderParams.Width, recorderParams.Height, PixelFormat.Format32bppRgb);
        _screenGraphics = Graphics.FromImage(_screenBmp);

        _screenThread = new Thread(RecordScreen)
        {
            Name = nameof(Recorder) + ".RecordScreen",
            IsBackground = true
        };
        _screenThread.Start();
    }

    public void Dispose()
    {
        if (_isDisposed)
            return;

        _isDisposed = true;
        _stopThread.Set();
        _screenThread.Join();

        _writer.Close();
        _screenGraphics.Dispose();
        _screenBmp.Dispose();
        _stopThread.Dispose();
    }

    private void RecordScreen()
    {
        var frameInterval = TimeSpan.FromSeconds(_recorderParams.TimeInterval);
        var buffer = new byte[_recorderParams.Width * _recorderParams.Height * 4];
        Task videoWriteTask = null;
        var timeTillNextFrame = TimeSpan.Zero;
        var rect = new Rectangle(0, 0, _recorderParams.Width, _recorderParams.Height);
        var size = new Size(_recorderParams.Width, _recorderParams.Height);

        while (!_stopThread.WaitOne(timeTillNextFrame))
        {
            var timestamp = DateTime.Now;

            CaptureFrame(buffer, rect, size);

            videoWriteTask?.Wait();
            videoWriteTask = _videoStream.WriteFrameAsync(true, buffer, 0, buffer.Length);

            timeTillNextFrame = timestamp + frameInterval - DateTime.Now;
            if (timeTillNextFrame < TimeSpan.Zero)
                timeTillNextFrame = TimeSpan.Zero;
        }

        videoWriteTask?.Wait();
    }

    private void CaptureFrame(byte[] buffer, Rectangle rect, Size size)
    {
        if (_recorderParams.WindowHandle == IntPtr.Zero)
        {
            _screenGraphics.CopyFromScreen(Point.Empty, Point.Empty, size, CopyPixelOperation.SourceCopy);
        }
        else
        {
            IntPtr hdc = _screenGraphics.GetHdc();
            NativeMethods.PrintWindow(_recorderParams.WindowHandle, hdc, NativeMethods.RenderFullContent);
            _screenGraphics.ReleaseHdc(hdc);
        }
        _screenGraphics.Flush();

        var bits = _screenBmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);
        try
        {
            Marshal.Copy(bits.Scan0, buffer, 0, buffer.Length);
        }
        finally
        {
            _screenBmp.UnlockBits(bits);
        }
    }
}
