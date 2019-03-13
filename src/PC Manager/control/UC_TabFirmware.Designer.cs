namespace CustomPilot.control
{
    partial class UC_TabFirmware
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this._id_label = new System.Windows.Forms.Label();
            this.@__pid_label = new System.Windows.Forms.Label();
            this._firmware_label = new System.Windows.Forms.Label();
            this.@__version_label = new System.Windows.Forms.Label();
            this._information_groupBox = new System.Windows.Forms.GroupBox();
            this._firmwareBackup_groupBox = new System.Windows.Forms.GroupBox();
            this.@__firmdownload_file_version = new System.Windows.Forms.Label();
            this._ver_label1 = new System.Windows.Forms.Label();
            this.@__downState_label = new System.Windows.Forms.Label();
            this._firmware_down_open_file_button = new System.Windows.Forms.Button();
            this._firmware_dowload_button = new System.Windows.Forms.Button();
            this._state_label1 = new System.Windows.Forms.Label();
            this.@__down_progressBar = new System.Windows.Forms.ProgressBar();
            this.@__firmware_download_textBox = new System.Windows.Forms.TextBox();
            this._file_label1 = new System.Windows.Forms.Label();
            this._firmwareUpload_groupBox = new System.Windows.Forms.GroupBox();
            this.@__firmupload_file_version = new System.Windows.Forms.Label();
            this._ver_label2 = new System.Windows.Forms.Label();
            this.@__upState_label = new System.Windows.Forms.Label();
            this._firmware_up_open_file_button = new System.Windows.Forms.Button();
            this._firmware_upload_button = new System.Windows.Forms.Button();
            this._state_label2 = new System.Windows.Forms.Label();
            this.@__up_progressBar = new System.Windows.Forms.ProgressBar();
            this.@__firmware_upload_textBox = new System.Windows.Forms.TextBox();
            this._file_label2 = new System.Windows.Forms.Label();
            this._console_groupBox = new System.Windows.Forms.GroupBox();
            this.@__console_textBox = new System.Windows.Forms.TextBox();
            this._information_groupBox.SuspendLayout();
            this._firmwareBackup_groupBox.SuspendLayout();
            this._firmwareUpload_groupBox.SuspendLayout();
            this._console_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _id_label
            // 
            this._id_label.AutoSize = true;
            this._id_label.Location = new System.Drawing.Point(15, 35);
            this._id_label.Name = "_id_label";
            this._id_label.Size = new System.Drawing.Size(77, 15);
            this._id_label.TabIndex = 1;
            this._id_label.Text = "product id:";
            // 
            // __pid_label
            // 
            this.@__pid_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.@__pid_label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.@__pid_label.Location = new System.Drawing.Point(114, 30);
            this.@__pid_label.Name = "__pid_label";
            this.@__pid_label.Size = new System.Drawing.Size(153, 22);
            this.@__pid_label.TabIndex = 2;
            this.@__pid_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _firmware_label
            // 
            this._firmware_label.AutoSize = true;
            this._firmware_label.Location = new System.Drawing.Point(23, 70);
            this._firmware_label.Name = "_firmware_label";
            this._firmware_label.Size = new System.Drawing.Size(64, 15);
            this._firmware_label.TabIndex = 3;
            this._firmware_label.Text = "firmware:";
            // 
            // __version_label
            // 
            this.@__version_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.@__version_label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.@__version_label.Location = new System.Drawing.Point(114, 66);
            this.@__version_label.Name = "__version_label";
            this.@__version_label.Size = new System.Drawing.Size(153, 22);
            this.@__version_label.TabIndex = 4;
            this.@__version_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _information_groupBox
            // 
            this._information_groupBox.Controls.Add(this.@__version_label);
            this._information_groupBox.Controls.Add(this._id_label);
            this._information_groupBox.Controls.Add(this._firmware_label);
            this._information_groupBox.Controls.Add(this.@__pid_label);
            this._information_groupBox.Location = new System.Drawing.Point(3, 4);
            this._information_groupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._information_groupBox.Name = "_information_groupBox";
            this._information_groupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._information_groupBox.Size = new System.Drawing.Size(833, 100);
            this._information_groupBox.TabIndex = 5;
            this._information_groupBox.TabStop = false;
            this._information_groupBox.Text = "Information";
            // 
            // _firmwareBackup_groupBox
            // 
            this._firmwareBackup_groupBox.Controls.Add(this.@__firmdownload_file_version);
            this._firmwareBackup_groupBox.Controls.Add(this._ver_label1);
            this._firmwareBackup_groupBox.Controls.Add(this.@__downState_label);
            this._firmwareBackup_groupBox.Controls.Add(this._firmware_down_open_file_button);
            this._firmwareBackup_groupBox.Controls.Add(this._firmware_dowload_button);
            this._firmwareBackup_groupBox.Controls.Add(this._state_label1);
            this._firmwareBackup_groupBox.Controls.Add(this.@__down_progressBar);
            this._firmwareBackup_groupBox.Controls.Add(this.@__firmware_download_textBox);
            this._firmwareBackup_groupBox.Controls.Add(this._file_label1);
            this._firmwareBackup_groupBox.Location = new System.Drawing.Point(3, 111);
            this._firmwareBackup_groupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._firmwareBackup_groupBox.Name = "_firmwareBackup_groupBox";
            this._firmwareBackup_groupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._firmwareBackup_groupBox.Size = new System.Drawing.Size(833, 109);
            this._firmwareBackup_groupBox.TabIndex = 6;
            this._firmwareBackup_groupBox.TabStop = false;
            this._firmwareBackup_groupBox.Text = "Firmware Backup";
            // 
            // __firmdownload_file_version
            // 
            this.@__firmdownload_file_version.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.@__firmdownload_file_version.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.@__firmdownload_file_version.Location = new System.Drawing.Point(66, 61);
            this.@__firmdownload_file_version.Name = "__firmdownload_file_version";
            this.@__firmdownload_file_version.Size = new System.Drawing.Size(129, 28);
            this.@__firmdownload_file_version.TabIndex = 25;
            this.@__firmdownload_file_version.Text = "-";
            this.@__firmdownload_file_version.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _ver_label1
            // 
            this._ver_label1.AutoSize = true;
            this._ver_label1.Location = new System.Drawing.Point(15, 68);
            this._ver_label1.Name = "_ver_label1";
            this._ver_label1.Size = new System.Drawing.Size(39, 15);
            this._ver_label1.TabIndex = 24;
            this._ver_label1.Text = "VER:";
            // 
            // __downState_label
            // 
            this.@__downState_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.@__downState_label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.@__downState_label.Location = new System.Drawing.Point(257, 60);
            this.@__downState_label.Name = "__downState_label";
            this.@__downState_label.Size = new System.Drawing.Size(129, 28);
            this.@__downState_label.TabIndex = 14;
            this.@__downState_label.Text = "wait";
            this.@__downState_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _firmware_down_open_file_button
            // 
            this._firmware_down_open_file_button.Location = new System.Drawing.Point(744, 24);
            this._firmware_down_open_file_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._firmware_down_open_file_button.Name = "_firmware_down_open_file_button";
            this._firmware_down_open_file_button.Size = new System.Drawing.Size(82, 29);
            this._firmware_down_open_file_button.TabIndex = 8;
            this._firmware_down_open_file_button.Text = "Open";
            this._firmware_down_open_file_button.UseVisualStyleBackColor = true;
            this._firmware_down_open_file_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // _firmware_dowload_button
            // 
            this._firmware_dowload_button.Enabled = false;
            this._firmware_dowload_button.Location = new System.Drawing.Point(744, 60);
            this._firmware_dowload_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._firmware_dowload_button.Name = "_firmware_dowload_button";
            this._firmware_dowload_button.Size = new System.Drawing.Size(82, 29);
            this._firmware_dowload_button.TabIndex = 11;
            this._firmware_dowload_button.Text = "Download";
            this._firmware_dowload_button.UseVisualStyleBackColor = true;
            this._firmware_dowload_button.Click += new System.EventHandler(this.@__down_button_Click);
            // 
            // _state_label1
            // 
            this._state_label1.AutoSize = true;
            this._state_label1.Location = new System.Drawing.Point(206, 66);
            this._state_label1.Name = "_state_label1";
            this._state_label1.Size = new System.Drawing.Size(44, 15);
            this._state_label1.TabIndex = 10;
            this._state_label1.Text = "state:";
            // 
            // __down_progressBar
            // 
            this.@__down_progressBar.Location = new System.Drawing.Point(393, 60);
            this.@__down_progressBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.@__down_progressBar.Name = "__down_progressBar";
            this.@__down_progressBar.Size = new System.Drawing.Size(344, 29);
            this.@__down_progressBar.Step = 1;
            this.@__down_progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.@__down_progressBar.TabIndex = 12;
            // 
            // __firmware_download_textBox
            // 
            this.@__firmware_download_textBox.Location = new System.Drawing.Point(66, 26);
            this.@__firmware_download_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.@__firmware_download_textBox.MaxLength = 255;
            this.@__firmware_download_textBox.Name = "__firmware_download_textBox";
            this.@__firmware_download_textBox.ReadOnly = true;
            this.@__firmware_download_textBox.Size = new System.Drawing.Size(670, 25);
            this.@__firmware_download_textBox.TabIndex = 3;
            // 
            // _file_label1
            // 
            this._file_label1.AutoSize = true;
            this._file_label1.Location = new System.Drawing.Point(15, 32);
            this._file_label1.Name = "_file_label1";
            this._file_label1.Size = new System.Drawing.Size(34, 15);
            this._file_label1.TabIndex = 2;
            this._file_label1.Text = "File:";
            // 
            // _firmwareUpload_groupBox
            // 
            this._firmwareUpload_groupBox.Controls.Add(this.@__firmupload_file_version);
            this._firmwareUpload_groupBox.Controls.Add(this._ver_label2);
            this._firmwareUpload_groupBox.Controls.Add(this.@__upState_label);
            this._firmwareUpload_groupBox.Controls.Add(this._firmware_up_open_file_button);
            this._firmwareUpload_groupBox.Controls.Add(this._firmware_upload_button);
            this._firmwareUpload_groupBox.Controls.Add(this._state_label2);
            this._firmwareUpload_groupBox.Controls.Add(this.@__up_progressBar);
            this._firmwareUpload_groupBox.Controls.Add(this.@__firmware_upload_textBox);
            this._firmwareUpload_groupBox.Controls.Add(this._file_label2);
            this._firmwareUpload_groupBox.Location = new System.Drawing.Point(3, 228);
            this._firmwareUpload_groupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._firmwareUpload_groupBox.Name = "_firmwareUpload_groupBox";
            this._firmwareUpload_groupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._firmwareUpload_groupBox.Size = new System.Drawing.Size(833, 100);
            this._firmwareUpload_groupBox.TabIndex = 7;
            this._firmwareUpload_groupBox.TabStop = false;
            this._firmwareUpload_groupBox.Text = "Firmware Upload";
            // 
            // __firmupload_file_version
            // 
            this.@__firmupload_file_version.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.@__firmupload_file_version.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.@__firmupload_file_version.Location = new System.Drawing.Point(66, 59);
            this.@__firmupload_file_version.Name = "__firmupload_file_version";
            this.@__firmupload_file_version.Size = new System.Drawing.Size(129, 28);
            this.@__firmupload_file_version.TabIndex = 23;
            this.@__firmupload_file_version.Text = "-";
            this.@__firmupload_file_version.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _ver_label2
            // 
            this._ver_label2.AutoSize = true;
            this._ver_label2.Location = new System.Drawing.Point(15, 66);
            this._ver_label2.Name = "_ver_label2";
            this._ver_label2.Size = new System.Drawing.Size(39, 15);
            this._ver_label2.TabIndex = 22;
            this._ver_label2.Text = "VER:";
            // 
            // __upState_label
            // 
            this.@__upState_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.@__upState_label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.@__upState_label.Location = new System.Drawing.Point(257, 59);
            this.@__upState_label.Name = "__upState_label";
            this.@__upState_label.Size = new System.Drawing.Size(129, 28);
            this.@__upState_label.TabIndex = 21;
            this.@__upState_label.Text = "wait";
            this.@__upState_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _firmware_up_open_file_button
            // 
            this._firmware_up_open_file_button.Location = new System.Drawing.Point(744, 22);
            this._firmware_up_open_file_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._firmware_up_open_file_button.Name = "_firmware_up_open_file_button";
            this._firmware_up_open_file_button.Size = new System.Drawing.Size(82, 29);
            this._firmware_up_open_file_button.TabIndex = 17;
            this._firmware_up_open_file_button.Text = "Open";
            this._firmware_up_open_file_button.UseVisualStyleBackColor = true;
            this._firmware_up_open_file_button.Click += new System.EventHandler(this.@__firmware_up_open_file_button_Click);
            // 
            // _firmware_upload_button
            // 
            this._firmware_upload_button.Enabled = false;
            this._firmware_upload_button.Location = new System.Drawing.Point(744, 59);
            this._firmware_upload_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._firmware_upload_button.Name = "_firmware_upload_button";
            this._firmware_upload_button.Size = new System.Drawing.Size(82, 29);
            this._firmware_upload_button.TabIndex = 19;
            this._firmware_upload_button.Text = "Upload";
            this._firmware_upload_button.UseVisualStyleBackColor = true;
            this._firmware_upload_button.Click += new System.EventHandler(this.@__firmware_upload_button_Click);
            // 
            // _state_label2
            // 
            this._state_label2.AutoSize = true;
            this._state_label2.Location = new System.Drawing.Point(209, 66);
            this._state_label2.Name = "_state_label2";
            this._state_label2.Size = new System.Drawing.Size(44, 15);
            this._state_label2.TabIndex = 18;
            this._state_label2.Text = "state:";
            // 
            // __up_progressBar
            // 
            this.@__up_progressBar.Location = new System.Drawing.Point(393, 59);
            this.@__up_progressBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.@__up_progressBar.Name = "__up_progressBar";
            this.@__up_progressBar.Size = new System.Drawing.Size(344, 29);
            this.@__up_progressBar.TabIndex = 20;
            // 
            // __firmware_upload_textBox
            // 
            this.@__firmware_upload_textBox.Location = new System.Drawing.Point(66, 25);
            this.@__firmware_upload_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.@__firmware_upload_textBox.MaxLength = 255;
            this.@__firmware_upload_textBox.Name = "__firmware_upload_textBox";
            this.@__firmware_upload_textBox.ReadOnly = true;
            this.@__firmware_upload_textBox.Size = new System.Drawing.Size(670, 25);
            this.@__firmware_upload_textBox.TabIndex = 16;
            // 
            // _file_label2
            // 
            this._file_label2.AutoSize = true;
            this._file_label2.Location = new System.Drawing.Point(15, 31);
            this._file_label2.Name = "_file_label2";
            this._file_label2.Size = new System.Drawing.Size(34, 15);
            this._file_label2.TabIndex = 15;
            this._file_label2.Text = "File:";
            // 
            // _console_groupBox
            // 
            this._console_groupBox.Controls.Add(this.@__console_textBox);
            this._console_groupBox.Location = new System.Drawing.Point(3, 335);
            this._console_groupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._console_groupBox.Name = "_console_groupBox";
            this._console_groupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._console_groupBox.Size = new System.Drawing.Size(833, 309);
            this._console_groupBox.TabIndex = 8;
            this._console_groupBox.TabStop = false;
            this._console_groupBox.Text = "Console";
            // 
            // __console_textBox
            // 
            this.@__console_textBox.Location = new System.Drawing.Point(7, 25);
            this.@__console_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.@__console_textBox.Multiline = true;
            this.@__console_textBox.Name = "__console_textBox";
            this.@__console_textBox.ReadOnly = true;
            this.@__console_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.@__console_textBox.Size = new System.Drawing.Size(819, 269);
            this.@__console_textBox.TabIndex = 0;
            // 
            // UC_TabFirmware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._console_groupBox);
            this.Controls.Add(this._firmwareUpload_groupBox);
            this.Controls.Add(this._firmwareBackup_groupBox);
            this.Controls.Add(this._information_groupBox);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UC_TabFirmware";
            this.Size = new System.Drawing.Size(843, 648);
            this._information_groupBox.ResumeLayout(false);
            this._information_groupBox.PerformLayout();
            this._firmwareBackup_groupBox.ResumeLayout(false);
            this._firmwareBackup_groupBox.PerformLayout();
            this._firmwareUpload_groupBox.ResumeLayout(false);
            this._firmwareUpload_groupBox.PerformLayout();
            this._console_groupBox.ResumeLayout(false);
            this._console_groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _id_label;
        private System.Windows.Forms.Label __pid_label;
        private System.Windows.Forms.Label _firmware_label;
        private System.Windows.Forms.Label __version_label;
        private System.Windows.Forms.GroupBox _information_groupBox;
        private System.Windows.Forms.GroupBox _firmwareBackup_groupBox;
        private System.Windows.Forms.TextBox __firmware_download_textBox;
        private System.Windows.Forms.Label _file_label1;
        private System.Windows.Forms.Button _firmware_down_open_file_button;
        private System.Windows.Forms.GroupBox _firmwareUpload_groupBox;
        private System.Windows.Forms.ProgressBar __down_progressBar;
        private System.Windows.Forms.Label _state_label1;
        private System.Windows.Forms.GroupBox _console_groupBox;
        private System.Windows.Forms.Button _firmware_dowload_button;
        private System.Windows.Forms.TextBox __console_textBox;
        private System.Windows.Forms.Label __downState_label;
        private System.Windows.Forms.Label __upState_label;
        private System.Windows.Forms.Button _firmware_up_open_file_button;
        private System.Windows.Forms.Button _firmware_upload_button;
        private System.Windows.Forms.Label _state_label2;
        private System.Windows.Forms.ProgressBar __up_progressBar;
        private System.Windows.Forms.TextBox __firmware_upload_textBox;
        private System.Windows.Forms.Label _file_label2;
        private System.Windows.Forms.Label __firmdownload_file_version;
        private System.Windows.Forms.Label _ver_label1;
        private System.Windows.Forms.Label __firmupload_file_version;
        private System.Windows.Forms.Label _ver_label2;
    }
}
