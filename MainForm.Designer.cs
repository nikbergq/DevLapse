namespace DevLapse
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btnStartButton = new System.Windows.Forms.Button();
            btnStopButton = new System.Windows.Forms.Button();
            lblFilename = new System.Windows.Forms.Label();
            lblFrames = new System.Windows.Forms.Label();
            lblTime = new System.Windows.Forms.Label();
            tmrFrameRecorder = new System.Windows.Forms.Timer(components);
            txtFilename = new System.Windows.Forms.TextBox();
            txtTimeInterval = new System.Windows.Forms.TextBox();
            lblTimeInterval = new System.Windows.Forms.Label();
            lblWindowSelect = new System.Windows.Forms.Label();
            cboWindowSelect = new System.Windows.Forms.ComboBox();
            btnOpenFolder = new System.Windows.Forms.Button();
            lblFPS = new System.Windows.Forms.Label();
            cboFPS = new System.Windows.Forms.ComboBox();
            SuspendLayout();
            // 
            // btnStartButton
            // 
            btnStartButton.BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
            btnStartButton.Font = new System.Drawing.Font("Lucida Console", 25.8113213F);
            btnStartButton.Location = new System.Drawing.Point(35, 323);
            btnStartButton.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            btnStartButton.Name = "btnStartButton";
            btnStartButton.Size = new System.Drawing.Size(254, 90);
            btnStartButton.TabIndex = 0;
            btnStartButton.Text = "START";
            btnStartButton.UseVisualStyleBackColor = false;
            btnStartButton.Click += OnStartButtonClick;
            // 
            // btnStopButton
            // 
            btnStopButton.BackColor = System.Drawing.Color.Blue;
            btnStopButton.Font = new System.Drawing.Font("Lucida Console", 25.8113213F);
            btnStopButton.Location = new System.Drawing.Point(331, 323);
            btnStopButton.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            btnStopButton.Name = "btnStopButton";
            btnStopButton.Size = new System.Drawing.Size(254, 90);
            btnStopButton.TabIndex = 1;
            btnStopButton.Text = "STOP";
            btnStopButton.UseVisualStyleBackColor = false;
            btnStopButton.Click += OnStopButtonClick;
            // 
            // lblFilename
            // 
            lblFilename.AutoSize = true;
            lblFilename.BackColor = System.Drawing.Color.Transparent;
            lblFilename.Font = new System.Drawing.Font("Lucida Console", 10.18868F);
            lblFilename.ForeColor = System.Drawing.SystemColors.ButtonFace;
            lblFilename.Location = new System.Drawing.Point(15, 16);
            lblFilename.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            lblFilename.Name = "lblFilename";
            lblFilename.Size = new System.Drawing.Size(79, 15);
            lblFilename.TabIndex = 3;
            lblFilename.Text = "Filename";
            // 
            // lblFrames
            // 
            lblFrames.AutoSize = true;
            lblFrames.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            lblFrames.Font = new System.Drawing.Font("Lucida Console", 10.18868F);
            lblFrames.ForeColor = System.Drawing.SystemColors.ButtonFace;
            lblFrames.Location = new System.Drawing.Point(262, 277);
            lblFrames.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            lblFrames.Name = "lblFrames";
            lblFrames.Size = new System.Drawing.Size(79, 15);
            lblFrames.TabIndex = 4;
            lblFrames.Text = "FRAME: -";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            lblTime.Font = new System.Drawing.Font("Lucida Console", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblTime.ForeColor = System.Drawing.Color.DarkOrange;
            lblTime.Location = new System.Drawing.Point(174, 214);
            lblTime.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            lblTime.Name = "lblTime";
            lblTime.Size = new System.Drawing.Size(279, 53);
            lblTime.TabIndex = 5;
            lblTime.Text = "00:00:00";
            // 
            // tmrFrameRecorder
            // 
            tmrFrameRecorder.Interval = 5000;
            tmrFrameRecorder.Tick += OnFrameRecorderTick;
            // 
            // txtFilename
            // 
            txtFilename.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            txtFilename.Font = new System.Drawing.Font("Lucida Console", 10.18868F);
            txtFilename.ForeColor = System.Drawing.SystemColors.ButtonFace;
            txtFilename.Location = new System.Drawing.Point(15, 35);
            txtFilename.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            txtFilename.Name = "txtFilename";
            txtFilename.Size = new System.Drawing.Size(594, 22);
            txtFilename.TabIndex = 2;
            txtFilename.Text = "-";
            // 
            // txtTimeInterval
            // 
            txtTimeInterval.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            txtTimeInterval.Font = new System.Drawing.Font("Lucida Console", 10.18868F);
            txtTimeInterval.ForeColor = System.Drawing.SystemColors.ButtonFace;
            txtTimeInterval.Location = new System.Drawing.Point(15, 84);
            txtTimeInterval.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            txtTimeInterval.Name = "txtTimeInterval";
            txtTimeInterval.Size = new System.Drawing.Size(150, 22);
            txtTimeInterval.TabIndex = 6;
            txtTimeInterval.Text = "5";
            // 
            // lblTimeInterval
            // 
            lblTimeInterval.AutoSize = true;
            lblTimeInterval.BackColor = System.Drawing.Color.Transparent;
            lblTimeInterval.Font = new System.Drawing.Font("Lucida Console", 10.18868F);
            lblTimeInterval.ForeColor = System.Drawing.SystemColors.ButtonFace;
            lblTimeInterval.Location = new System.Drawing.Point(15, 65);
            lblTimeInterval.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            lblTimeInterval.Name = "lblTimeInterval";
            lblTimeInterval.Size = new System.Drawing.Size(160, 15);
            lblTimeInterval.TabIndex = 7;
            lblTimeInterval.Text = "Lapse time (sec.)";
            lblTimeInterval.Click += lblTimeInterval_Click_1;
            // 
            // lblWindowSelect
            // 
            lblWindowSelect.AutoSize = true;
            lblWindowSelect.BackColor = System.Drawing.Color.Transparent;
            lblWindowSelect.Font = new System.Drawing.Font("Lucida Console", 10.18868F);
            lblWindowSelect.ForeColor = System.Drawing.SystemColors.ButtonFace;
            lblWindowSelect.Location = new System.Drawing.Point(15, 125);
            lblWindowSelect.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            lblWindowSelect.Name = "lblWindowSelect";
            lblWindowSelect.Size = new System.Drawing.Size(214, 15);
            lblWindowSelect.TabIndex = 8;
            lblWindowSelect.Text = "Select recording window";
            // 
            // cboWindowSelect
            // 
            cboWindowSelect.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            cboWindowSelect.Font = new System.Drawing.Font("Lucida Console", 10.18868F);
            cboWindowSelect.ForeColor = System.Drawing.SystemColors.ButtonFace;
            cboWindowSelect.FormattingEnabled = true;
            cboWindowSelect.Location = new System.Drawing.Point(15, 147);
            cboWindowSelect.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            cboWindowSelect.Name = "cboWindowSelect";
            cboWindowSelect.Size = new System.Drawing.Size(594, 23);
            cboWindowSelect.TabIndex = 9;
            // 
            // btnOpenFolder
            // 
            btnOpenFolder.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            btnOpenFolder.Font = new System.Drawing.Font("Lucida Console", 10.18868F);
            btnOpenFolder.ForeColor = System.Drawing.SystemColors.ButtonFace;
            btnOpenFolder.Location = new System.Drawing.Point(459, 65);
            btnOpenFolder.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            btnOpenFolder.Name = "btnOpenFolder";
            btnOpenFolder.Size = new System.Drawing.Size(150, 41);
            btnOpenFolder.TabIndex = 10;
            btnOpenFolder.Text = "Select folder";
            btnOpenFolder.UseVisualStyleBackColor = false;
            btnOpenFolder.Click += OnOpenFolderClick;
            // 
            // lblFPS
            // 
            lblFPS.AutoSize = true;
            lblFPS.BackColor = System.Drawing.Color.Transparent;
            lblFPS.Font = new System.Drawing.Font("Lucida Console", 10.18868F);
            lblFPS.ForeColor = System.Drawing.SystemColors.ButtonFace;
            lblFPS.Location = new System.Drawing.Point(244, 65);
            lblFPS.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            lblFPS.Name = "lblFPS";
            lblFPS.Size = new System.Drawing.Size(142, 15);
            lblFPS.TabIndex = 12;
            lblFPS.Text = "Frames per sec.";
            // 
            // cboFPS
            // 
            cboFPS.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            cboFPS.Font = new System.Drawing.Font("Lucida Console", 10.18868F);
            cboFPS.ForeColor = System.Drawing.SystemColors.ButtonFace;
            cboFPS.FormattingEnabled = true;
            cboFPS.Location = new System.Drawing.Point(244, 83);
            cboFPS.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            cboFPS.Name = "cboFPS";
            cboFPS.Size = new System.Drawing.Size(150, 23);
            cboFPS.TabIndex = 13;
            cboFPS.Text = "10";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(11F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Black;
            ClientSize = new System.Drawing.Size(624, 439);
            Controls.Add(cboFPS);
            Controls.Add(lblFPS);
            Controls.Add(btnOpenFolder);
            Controls.Add(cboWindowSelect);
            Controls.Add(lblWindowSelect);
            Controls.Add(lblTimeInterval);
            Controls.Add(txtTimeInterval);
            Controls.Add(lblTime);
            Controls.Add(lblFrames);
            Controls.Add(lblFilename);
            Controls.Add(txtFilename);
            Controls.Add(btnStopButton);
            Controls.Add(btnStartButton);
            Font = new System.Drawing.Font("Lucida Console", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            Name = "MainForm";
            Text = "DevLapse";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartButton;
        private System.Windows.Forms.Button btnStopButton;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.Label lblFrames;
        public System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer tmrFrameRecorder;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.TextBox txtTimeInterval;
        private System.Windows.Forms.Label lblTimeInterval;
        private System.Windows.Forms.Label lblWindowSelect;
        private System.Windows.Forms.ComboBox cboWindowSelect;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Label lblFPS;
        private System.Windows.Forms.ComboBox cboFPS;
    }
}

