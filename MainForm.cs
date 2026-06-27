using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DevLapse;

public partial class MainForm : Form
{
    private Recorder _recorder;
    private DateTime _recordingStartTime;
    private double _captureIntervalSeconds;

    public MainForm()
    {
        InitializeComponent();

        PopulateWindowList();
        PopulateFpsOptions();
        UpdateFilename();

        btnStopButton.Enabled = false;
    }

    private void UpdateFilename()
    {
        string savedDir = Properties.Settings.Default.OutputDirectory;
        string outputDir = string.IsNullOrEmpty(savedDir)
            ? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "DevLapse")
            : savedDir;
        Directory.CreateDirectory(outputDir);

        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
        txtFilename.Text = Path.Combine(outputDir, $"DevLapse ({timestamp}).avi");
    }

    private static readonly Regex TimestampSuffixPattern =
        new(@" \(\d{4}-\d{2}-\d{2} \d{2}-\d{2}-\d{2}\)$");

    private static string ResolveUniqueFilePath(string filePath)
    {
        if (!File.Exists(filePath))
            return filePath;

        string directory = Path.GetDirectoryName(filePath);
        string baseName = Path.GetFileNameWithoutExtension(filePath);
        string extension = Path.GetExtension(filePath);
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");

        baseName = TimestampSuffixPattern.Replace(baseName, string.Empty);

        return Path.Combine(directory, $"{baseName} ({timestamp}){extension}");
    }

    private void PopulateWindowList()
    {
        cboWindowSelect.Items.Clear();
        cboWindowSelect.Items.Add(new WindowInfo { Handle = IntPtr.Zero, Title = "Full screen" });

        foreach (var window in WindowEnumerator.GetOpenWindows())
        {
            cboWindowSelect.Items.Add(window);
        }

        cboWindowSelect.SelectedIndex = 0;
    }

    private void PopulateFpsOptions()
    {
        cboFPS.Items.Clear();
        cboFPS.Items.AddRange(new object[] { 10, 15, 24, 30, 60 });
        cboFPS.Text = Properties.Settings.Default.Fps.ToString();
    }

    private void OnStartButtonClick(object sender, EventArgs e)
    {
        if (!double.TryParse(txtTimeInterval.Text, out double intervalSeconds))
        {
            MessageBox.Show("Please enter a valid number for the time interval (seconds).");
            return;
        }

        if (!int.TryParse(cboFPS.Text, out int fps) || fps < 1 || fps > 60)
        {
            MessageBox.Show("Please enter a valid frame rate (1-60).");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(txtFilename.Text));
        txtFilename.Text = ResolveUniqueFilePath(txtFilename.Text);

        _captureIntervalSeconds = intervalSeconds;
        _recordingStartTime = DateTime.Now;

        tmrFrameRecorder.Interval = 1000;
        tmrFrameRecorder.Start();

        IntPtr selectedWindow = IntPtr.Zero;
        if (cboWindowSelect.SelectedItem is WindowInfo winInfo)
        {
            selectedWindow = winInfo.Handle;
        }

        _recorder = new Recorder(new RecorderParams(
            intervalSeconds,
            txtFilename.Text,
            fps,
            75,
            selectedWindow));

        Properties.Settings.Default.OutputDirectory = Path.GetDirectoryName(txtFilename.Text);
        Properties.Settings.Default.Fps = fps;
        Properties.Settings.Default.Save();

        btnStartButton.Enabled = false;
        btnStopButton.Enabled = true;
    }

    private void OnStopButtonClick(object sender, EventArgs e)
    {
        tmrFrameRecorder.Stop();
        _recorder?.Dispose();
        btnStopButton.Enabled = false;
        btnStartButton.Enabled = true;
    }

    private void OnFrameRecorderTick(object sender, EventArgs e)
    {
        TimeSpan elapsed = DateTime.Now - _recordingStartTime;
        int frameCount = (int)(elapsed.TotalSeconds / _captureIntervalSeconds);

        lblTime.Text = string.Format("{0}:{1:D2}:{2:D2}",
            (int)elapsed.TotalHours,
            elapsed.Minutes,
            elapsed.Seconds);
        lblFrames.Text = $"FRAME: {frameCount:D3}";
    }

    private void OnOpenFolderClick(object sender, EventArgs e)
    {
        using var dialog = new FolderBrowserDialog
        {
            Description = "Select output folder",
            SelectedPath = Path.GetDirectoryName(txtFilename.Text)
        };

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            Properties.Settings.Default.OutputDirectory = dialog.SelectedPath;
            Properties.Settings.Default.Save();
            UpdateFilename();
        }
    }

    private void lblTimeInterval_Click(object sender, EventArgs e)
    {

    }

    private void lblTimeInterval_Click_1(object sender, EventArgs e)
    {

    }
}
