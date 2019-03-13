namespace CustomPilot.control
{
    partial class UC_TabDebug
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
            this.@__set_button = new System.Windows.Forms.Button();
            this.@__wdt_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.@__firmupload_file_version = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.@__upState_label = new System.Windows.Forms.Label();
            this.@__firmware_up_open_file_button = new System.Windows.Forms.Button();
            this.@__firmware_upload_button = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.@__up_progressBar = new System.Windows.Forms.ProgressBar();
            this.@__firmware_upload_textBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.@__firmdownload_file_version = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.@__downState_label = new System.Windows.Forms.Label();
            this.@__firmware_down_open_file_button = new System.Windows.Forms.Button();
            this.@__firmware_dowload_button = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.@__down_progressBar = new System.Windows.Forms.ProgressBar();
            this.@__firmware_download_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.@__programmer_comboBox = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.@__console_textBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // __set_button
            // 
            this.@__set_button.Location = new System.Drawing.Point(647, 63);
            this.@__set_button.Name = "__set_button";
            this.@__set_button.Size = new System.Drawing.Size(75, 23);
            this.@__set_button.TabIndex = 5;
            this.@__set_button.Text = "set";
            this.@__set_button.UseVisualStyleBackColor = true;
            // 
            // __wdt_button
            // 
            this.@__wdt_button.Location = new System.Drawing.Point(14, 20);
            this.@__wdt_button.Name = "__wdt_button";
            this.@__wdt_button.Size = new System.Drawing.Size(75, 23);
            this.@__wdt_button.TabIndex = 6;
            this.@__wdt_button.Text = "WDT";
            this.@__wdt_button.UseVisualStyleBackColor = true;
            this.@__wdt_button.Click += new System.EventHandler(this.@__get_button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.@__wdt_button);
            this.groupBox1.Controls.Add(this.@__set_button);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(728, 92);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TEST";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.@__programmer_comboBox);
            this.groupBox2.Location = new System.Drawing.Point(3, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(728, 218);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Programmer";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.@__firmupload_file_version);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.@__upState_label);
            this.groupBox3.Controls.Add(this.@__firmware_up_open_file_button);
            this.groupBox3.Controls.Add(this.@__firmware_upload_button);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.@__up_progressBar);
            this.groupBox3.Controls.Add(this.@__firmware_upload_textBox);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(-1, 139);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(729, 80);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Firmware Upload";
            // 
            // __firmupload_file_version
            // 
            this.@__firmupload_file_version.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.@__firmupload_file_version.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.@__firmupload_file_version.Location = new System.Drawing.Point(58, 47);
            this.@__firmupload_file_version.Name = "__firmupload_file_version";
            this.@__firmupload_file_version.Size = new System.Drawing.Size(113, 23);
            this.@__firmupload_file_version.TabIndex = 23;
            this.@__firmupload_file_version.Text = "-";
            this.@__firmupload_file_version.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "VER:";
            // 
            // __upState_label
            // 
            this.@__upState_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.@__upState_label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.@__upState_label.Location = new System.Drawing.Point(225, 47);
            this.@__upState_label.Name = "__upState_label";
            this.@__upState_label.Size = new System.Drawing.Size(113, 23);
            this.@__upState_label.TabIndex = 21;
            this.@__upState_label.Text = "wait";
            this.@__upState_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // __firmware_up_open_file_button
            // 
            this.@__firmware_up_open_file_button.Location = new System.Drawing.Point(651, 18);
            this.@__firmware_up_open_file_button.Name = "__firmware_up_open_file_button";
            this.@__firmware_up_open_file_button.Size = new System.Drawing.Size(72, 23);
            this.@__firmware_up_open_file_button.TabIndex = 17;
            this.@__firmware_up_open_file_button.Text = "Open";
            this.@__firmware_up_open_file_button.UseVisualStyleBackColor = true;
            // 
            // __firmware_upload_button
            // 
            this.@__firmware_upload_button.Location = new System.Drawing.Point(651, 47);
            this.@__firmware_upload_button.Name = "__firmware_upload_button";
            this.@__firmware_upload_button.Size = new System.Drawing.Size(72, 23);
            this.@__firmware_upload_button.TabIndex = 19;
            this.@__firmware_upload_button.Text = "Upload";
            this.@__firmware_upload_button.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(183, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "state:";
            // 
            // __up_progressBar
            // 
            this.@__up_progressBar.Location = new System.Drawing.Point(344, 47);
            this.@__up_progressBar.Name = "__up_progressBar";
            this.@__up_progressBar.Size = new System.Drawing.Size(301, 23);
            this.@__up_progressBar.TabIndex = 20;
            // 
            // __firmware_upload_textBox
            // 
            this.@__firmware_upload_textBox.Location = new System.Drawing.Point(58, 20);
            this.@__firmware_upload_textBox.MaxLength = 255;
            this.@__firmware_upload_textBox.Name = "__firmware_upload_textBox";
            this.@__firmware_upload_textBox.ReadOnly = true;
            this.@__firmware_upload_textBox.Size = new System.Drawing.Size(587, 21);
            this.@__firmware_upload_textBox.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "File:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.@__firmdownload_file_version);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.@__downState_label);
            this.groupBox4.Controls.Add(this.@__firmware_down_open_file_button);
            this.groupBox4.Controls.Add(this.@__firmware_dowload_button);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.@__down_progressBar);
            this.groupBox4.Controls.Add(this.@__firmware_download_textBox);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(-1, 46);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(729, 87);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Firmware Backup";
            // 
            // __firmdownload_file_version
            // 
            this.@__firmdownload_file_version.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.@__firmdownload_file_version.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.@__firmdownload_file_version.Location = new System.Drawing.Point(58, 49);
            this.@__firmdownload_file_version.Name = "__firmdownload_file_version";
            this.@__firmdownload_file_version.Size = new System.Drawing.Size(113, 23);
            this.@__firmdownload_file_version.TabIndex = 25;
            this.@__firmdownload_file_version.Text = "-";
            this.@__firmdownload_file_version.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 12);
            this.label10.TabIndex = 24;
            this.label10.Text = "VER:";
            // 
            // __downState_label
            // 
            this.@__downState_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.@__downState_label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.@__downState_label.Location = new System.Drawing.Point(225, 48);
            this.@__downState_label.Name = "__downState_label";
            this.@__downState_label.Size = new System.Drawing.Size(113, 23);
            this.@__downState_label.TabIndex = 14;
            this.@__downState_label.Text = "wait";
            this.@__downState_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // __firmware_down_open_file_button
            // 
            this.@__firmware_down_open_file_button.Location = new System.Drawing.Point(651, 19);
            this.@__firmware_down_open_file_button.Name = "__firmware_down_open_file_button";
            this.@__firmware_down_open_file_button.Size = new System.Drawing.Size(72, 23);
            this.@__firmware_down_open_file_button.TabIndex = 8;
            this.@__firmware_down_open_file_button.Text = "Open";
            this.@__firmware_down_open_file_button.UseVisualStyleBackColor = true;
            this.@__firmware_down_open_file_button.Click += new System.EventHandler(this.@__firmware_down_open_file_button_Click);
            // 
            // __firmware_dowload_button
            // 
            this.@__firmware_dowload_button.Location = new System.Drawing.Point(651, 48);
            this.@__firmware_dowload_button.Name = "__firmware_dowload_button";
            this.@__firmware_dowload_button.Size = new System.Drawing.Size(72, 23);
            this.@__firmware_dowload_button.TabIndex = 11;
            this.@__firmware_dowload_button.Text = "Download";
            this.@__firmware_dowload_button.UseVisualStyleBackColor = true;
            this.@__firmware_dowload_button.Click += new System.EventHandler(this.@__firmware_dowload_button_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(180, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "state:";
            // 
            // __down_progressBar
            // 
            this.@__down_progressBar.Location = new System.Drawing.Point(344, 48);
            this.@__down_progressBar.Name = "__down_progressBar";
            this.@__down_progressBar.Size = new System.Drawing.Size(301, 23);
            this.@__down_progressBar.Step = 1;
            this.@__down_progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.@__down_progressBar.TabIndex = 12;
            // 
            // __firmware_download_textBox
            // 
            this.@__firmware_download_textBox.Location = new System.Drawing.Point(58, 21);
            this.@__firmware_download_textBox.MaxLength = 255;
            this.@__firmware_download_textBox.Name = "__firmware_download_textBox";
            this.@__firmware_download_textBox.ReadOnly = true;
            this.@__firmware_download_textBox.Size = new System.Drawing.Size(587, 21);
            this.@__firmware_download_textBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "File:";
            // 
            // __programmer_comboBox
            // 
            this.@__programmer_comboBox.FormattingEnabled = true;
            this.@__programmer_comboBox.Items.AddRange(new object[] {
            "USBasp",
            "USBTinyISP"});
            this.@__programmer_comboBox.Location = new System.Drawing.Point(6, 20);
            this.@__programmer_comboBox.Name = "__programmer_comboBox";
            this.@__programmer_comboBox.Size = new System.Drawing.Size(150, 20);
            this.@__programmer_comboBox.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.@__console_textBox);
            this.groupBox5.Location = new System.Drawing.Point(3, 326);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(729, 215);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Console";
            // 
            // __console_textBox
            // 
            this.@__console_textBox.Location = new System.Drawing.Point(6, 20);
            this.@__console_textBox.Multiline = true;
            this.@__console_textBox.Name = "__console_textBox";
            this.@__console_textBox.ReadOnly = true;
            this.@__console_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.@__console_textBox.Size = new System.Drawing.Size(717, 189);
            this.@__console_textBox.TabIndex = 0;
            // 
            // UC_TabDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UC_TabDebug";
            this.Size = new System.Drawing.Size(759, 565);
            this.Load += new System.EventHandler(this.UC_TabDebug_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button __set_button;
        private System.Windows.Forms.Button __wdt_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox __programmer_comboBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label __firmupload_file_version;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label __upState_label;
        private System.Windows.Forms.Button __firmware_up_open_file_button;
        private System.Windows.Forms.Button __firmware_upload_button;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar __up_progressBar;
        private System.Windows.Forms.TextBox __firmware_upload_textBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label __firmdownload_file_version;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label __downState_label;
        private System.Windows.Forms.Button __firmware_down_open_file_button;
        private System.Windows.Forms.Button __firmware_dowload_button;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar __down_progressBar;
        private System.Windows.Forms.TextBox __firmware_download_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox __console_textBox;
    }
}
