namespace CustomPilot.control
{
    partial class UC_TabFlightMode
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
            this._modechannels_groupBox = new System.Windows.Forms.GroupBox();
            this.@__modeC_label = new System.Windows.Forms.Label();
            this.@__modeB_label = new System.Windows.Forms.Label();
            this.@__mode_label = new System.Windows.Forms.Label();
            this._mode3_label = new System.Windows.Forms.Label();
            this._mode2_label = new System.Windows.Forms.Label();
            this._mode1_label = new System.Windows.Forms.Label();
            this._modeSetting_groupBox = new System.Windows.Forms.GroupBox();
            this.@__mode_mix_Label = new System.Windows.Forms.Label();
            this.@__default_button = new System.Windows.Forms.Button();
            this.@__uC_FlightMode7 = new CustomPilot.control.UC_FlightMode();
            this.@__uC_FlightMode6 = new CustomPilot.control.UC_FlightMode();
            this.@__uC_FlightMode5 = new CustomPilot.control.UC_FlightMode();
            this.@__uC_FlightMode4 = new CustomPilot.control.UC_FlightMode();
            this.@__uC_FlightMode3 = new CustomPilot.control.UC_FlightMode();
            this.@__uC_FlightMode2 = new CustomPilot.control.UC_FlightMode();
            this.@__uC_FlightMode1 = new CustomPilot.control.UC_FlightMode();
            this._mixMode_label = new System.Windows.Forms.Label();
            this._modechannels_groupBox.SuspendLayout();
            this._modeSetting_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _modechannels_groupBox
            // 
            this._modechannels_groupBox.Controls.Add(this.@__modeC_label);
            this._modechannels_groupBox.Controls.Add(this.@__modeB_label);
            this._modechannels_groupBox.Controls.Add(this.@__mode_label);
            this._modechannels_groupBox.Controls.Add(this._mode3_label);
            this._modechannels_groupBox.Controls.Add(this._mode2_label);
            this._modechannels_groupBox.Controls.Add(this._mode1_label);
            this._modechannels_groupBox.Location = new System.Drawing.Point(0, 0);
            this._modechannels_groupBox.Name = "_modechannels_groupBox";
            this._modechannels_groupBox.Size = new System.Drawing.Size(114, 102);
            this._modechannels_groupBox.TabIndex = 0;
            this._modechannels_groupBox.TabStop = false;
            this._modechannels_groupBox.Text = "Mode Channels";
            // 
            // __modeC_label
            // 
            this.@__modeC_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.@__modeC_label.Location = new System.Drawing.Point(74, 74);
            this.@__modeC_label.Name = "__modeC_label";
            this.@__modeC_label.Size = new System.Drawing.Size(34, 21);
            this.@__modeC_label.TabIndex = 20;
            this.@__modeC_label.Text = "000";
            this.@__modeC_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // __modeB_label
            // 
            this.@__modeB_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.@__modeB_label.Location = new System.Drawing.Point(74, 50);
            this.@__modeB_label.Name = "__modeB_label";
            this.@__modeB_label.Size = new System.Drawing.Size(34, 21);
            this.@__modeB_label.TabIndex = 19;
            this.@__modeB_label.Text = "000";
            this.@__modeB_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // __mode_label
            // 
            this.@__mode_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.@__mode_label.Location = new System.Drawing.Point(74, 25);
            this.@__mode_label.Name = "__mode_label";
            this.@__mode_label.Size = new System.Drawing.Size(34, 21);
            this.@__mode_label.TabIndex = 18;
            this.@__mode_label.Text = "000";
            this.@__mode_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _mode3_label
            // 
            this._mode3_label.AutoSize = true;
            this._mode3_label.Location = new System.Drawing.Point(9, 78);
            this._mode3_label.Name = "_mode3_label";
            this._mode3_label.Size = new System.Drawing.Size(47, 12);
            this._mode3_label.TabIndex = 5;
            this._mode3_label.Text = "Mode3:";
            // 
            // _mode2_label
            // 
            this._mode2_label.AutoSize = true;
            this._mode2_label.Location = new System.Drawing.Point(10, 54);
            this._mode2_label.Name = "_mode2_label";
            this._mode2_label.Size = new System.Drawing.Size(47, 12);
            this._mode2_label.TabIndex = 3;
            this._mode2_label.Text = "Mode2:";
            // 
            // _mode1_label
            // 
            this._mode1_label.AutoSize = true;
            this._mode1_label.Location = new System.Drawing.Point(10, 30);
            this._mode1_label.Name = "_mode1_label";
            this._mode1_label.Size = new System.Drawing.Size(47, 12);
            this._mode1_label.TabIndex = 1;
            this._mode1_label.Text = "Mode1:";
            // 
            // _modeSetting_groupBox
            // 
            this._modeSetting_groupBox.Controls.Add(this.@__mode_mix_Label);
            this._modeSetting_groupBox.Controls.Add(this.@__default_button);
            this._modeSetting_groupBox.Controls.Add(this.@__uC_FlightMode7);
            this._modeSetting_groupBox.Controls.Add(this.@__uC_FlightMode6);
            this._modeSetting_groupBox.Controls.Add(this.@__uC_FlightMode5);
            this._modeSetting_groupBox.Controls.Add(this.@__uC_FlightMode4);
            this._modeSetting_groupBox.Controls.Add(this.@__uC_FlightMode3);
            this._modeSetting_groupBox.Controls.Add(this.@__uC_FlightMode2);
            this._modeSetting_groupBox.Controls.Add(this.@__uC_FlightMode1);
            this._modeSetting_groupBox.Controls.Add(this._mixMode_label);
            this._modeSetting_groupBox.Location = new System.Drawing.Point(120, 0);
            this._modeSetting_groupBox.Name = "_modeSetting_groupBox";
            this._modeSetting_groupBox.Size = new System.Drawing.Size(482, 402);
            this._modeSetting_groupBox.TabIndex = 1;
            this._modeSetting_groupBox.TabStop = false;
            this._modeSetting_groupBox.Text = "Flight Mode Setting";
            // 
            // __mode_mix_Label
            // 
            this.@__mode_mix_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.@__mode_mix_Label.Location = new System.Drawing.Point(84, 25);
            this.@__mode_mix_Label.Name = "__mode_mix_Label";
            this.@__mode_mix_Label.Size = new System.Drawing.Size(48, 21);
            this.@__mode_mix_Label.TabIndex = 17;
            this.@__mode_mix_Label.Text = "000";
            this.@__mode_mix_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // __default_button
            // 
            this.@__default_button.Location = new System.Drawing.Point(401, 373);
            this.@__default_button.Name = "__default_button";
            this.@__default_button.Size = new System.Drawing.Size(75, 23);
            this.@__default_button.TabIndex = 16;
            this.@__default_button.Text = "default";
            this.@__default_button.UseVisualStyleBackColor = true;
            this.@__default_button.Click += new System.EventHandler(this.@__default_button_Click);
            // 
            // __uC_FlightMode7
            // 
            this.@__uC_FlightMode7.ActiveMode = false;
            this.@__uC_FlightMode7.Location = new System.Drawing.Point(17, 229);
            this.@__uC_FlightMode7.MIXMODE = 0;
            this.@__uC_FlightMode7.MODE_NAME = "MANUAL";
            this.@__uC_FlightMode7.Name = "__uC_FlightMode7";
            this.@__uC_FlightMode7.Size = new System.Drawing.Size(271, 22);
            this.@__uC_FlightMode7.TabIndex = 15;
            this.@__uC_FlightMode7.On_AddMode += new System.EventHandler(this.@__uC_FlightMode7_On_AddMode);
            this.@__uC_FlightMode7.On_DelMode += new System.EventHandler(this.@__uC_FlightMode7_On_DelMode);
            // 
            // __uC_FlightMode6
            // 
            this.@__uC_FlightMode6.ActiveMode = false;
            this.@__uC_FlightMode6.Location = new System.Drawing.Point(17, 203);
            this.@__uC_FlightMode6.MIXMODE = 0;
            this.@__uC_FlightMode6.MODE_NAME = "MANUAL";
            this.@__uC_FlightMode6.Name = "__uC_FlightMode6";
            this.@__uC_FlightMode6.Size = new System.Drawing.Size(271, 22);
            this.@__uC_FlightMode6.TabIndex = 14;
            this.@__uC_FlightMode6.On_AddMode += new System.EventHandler(this.@__uC_FlightMode7_On_AddMode);
            this.@__uC_FlightMode6.On_DelMode += new System.EventHandler(this.@__uC_FlightMode7_On_DelMode);
            // 
            // __uC_FlightMode5
            // 
            this.@__uC_FlightMode5.ActiveMode = false;
            this.@__uC_FlightMode5.Location = new System.Drawing.Point(17, 177);
            this.@__uC_FlightMode5.MIXMODE = 0;
            this.@__uC_FlightMode5.MODE_NAME = "MANUAL";
            this.@__uC_FlightMode5.Name = "__uC_FlightMode5";
            this.@__uC_FlightMode5.Size = new System.Drawing.Size(271, 22);
            this.@__uC_FlightMode5.TabIndex = 13;
            this.@__uC_FlightMode5.On_AddMode += new System.EventHandler(this.@__uC_FlightMode7_On_AddMode);
            this.@__uC_FlightMode5.On_DelMode += new System.EventHandler(this.@__uC_FlightMode7_On_DelMode);
            this.@__uC_FlightMode5.Load += new System.EventHandler(this.@__uC_FlightMode5_Load);
            // 
            // __uC_FlightMode4
            // 
            this.@__uC_FlightMode4.ActiveMode = false;
            this.@__uC_FlightMode4.Location = new System.Drawing.Point(17, 151);
            this.@__uC_FlightMode4.MIXMODE = 0;
            this.@__uC_FlightMode4.MODE_NAME = "MANUAL";
            this.@__uC_FlightMode4.Name = "__uC_FlightMode4";
            this.@__uC_FlightMode4.Size = new System.Drawing.Size(271, 22);
            this.@__uC_FlightMode4.TabIndex = 12;
            this.@__uC_FlightMode4.On_AddMode += new System.EventHandler(this.@__uC_FlightMode7_On_AddMode);
            this.@__uC_FlightMode4.On_DelMode += new System.EventHandler(this.@__uC_FlightMode7_On_DelMode);
            // 
            // __uC_FlightMode3
            // 
            this.@__uC_FlightMode3.ActiveMode = false;
            this.@__uC_FlightMode3.Location = new System.Drawing.Point(17, 125);
            this.@__uC_FlightMode3.MIXMODE = 0;
            this.@__uC_FlightMode3.MODE_NAME = "MANUAL";
            this.@__uC_FlightMode3.Name = "__uC_FlightMode3";
            this.@__uC_FlightMode3.Size = new System.Drawing.Size(271, 22);
            this.@__uC_FlightMode3.TabIndex = 11;
            this.@__uC_FlightMode3.On_AddMode += new System.EventHandler(this.@__uC_FlightMode7_On_AddMode);
            this.@__uC_FlightMode3.On_DelMode += new System.EventHandler(this.@__uC_FlightMode7_On_DelMode);
            // 
            // __uC_FlightMode2
            // 
            this.@__uC_FlightMode2.ActiveMode = false;
            this.@__uC_FlightMode2.Location = new System.Drawing.Point(17, 99);
            this.@__uC_FlightMode2.MIXMODE = 0;
            this.@__uC_FlightMode2.MODE_NAME = "MANUAL";
            this.@__uC_FlightMode2.Name = "__uC_FlightMode2";
            this.@__uC_FlightMode2.Size = new System.Drawing.Size(271, 22);
            this.@__uC_FlightMode2.TabIndex = 10;
            this.@__uC_FlightMode2.On_AddMode += new System.EventHandler(this.@__uC_FlightMode7_On_AddMode);
            this.@__uC_FlightMode2.On_DelMode += new System.EventHandler(this.@__uC_FlightMode7_On_DelMode);
            // 
            // __uC_FlightMode1
            // 
            this.@__uC_FlightMode1.ActiveMode = false;
            this.@__uC_FlightMode1.Location = new System.Drawing.Point(17, 73);
            this.@__uC_FlightMode1.MIXMODE = 0;
            this.@__uC_FlightMode1.MODE_NAME = "MANUAL";
            this.@__uC_FlightMode1.Name = "__uC_FlightMode1";
            this.@__uC_FlightMode1.Size = new System.Drawing.Size(271, 22);
            this.@__uC_FlightMode1.TabIndex = 9;
            this.@__uC_FlightMode1.On_AddMode += new System.EventHandler(this.@__uC_FlightMode7_On_AddMode);
            this.@__uC_FlightMode1.On_DelMode += new System.EventHandler(this.@__uC_FlightMode7_On_DelMode);
            // 
            // _mixMode_label
            // 
            this._mixMode_label.AutoSize = true;
            this._mixMode_label.Location = new System.Drawing.Point(15, 30);
            this._mixMode_label.Name = "_mixMode_label";
            this._mixMode_label.Size = new System.Drawing.Size(30, 12);
            this._mixMode_label.TabIndex = 7;
            this._mixMode_label.Text = "Mix:";
            // 
            // UC_TabFlightMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._modeSetting_groupBox);
            this.Controls.Add(this._modechannels_groupBox);
            this.Name = "UC_TabFlightMode";
            this.Size = new System.Drawing.Size(624, 507);
            this._modechannels_groupBox.ResumeLayout(false);
            this._modechannels_groupBox.PerformLayout();
            this._modeSetting_groupBox.ResumeLayout(false);
            this._modeSetting_groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _modechannels_groupBox;
        private System.Windows.Forms.Label _mode3_label;
        private System.Windows.Forms.Label _mode2_label;
        private System.Windows.Forms.Label _mode1_label;
        private System.Windows.Forms.GroupBox _modeSetting_groupBox;
        private System.Windows.Forms.Label _mixMode_label;
        private UC_FlightMode __uC_FlightMode7;
        private UC_FlightMode __uC_FlightMode6;
        private UC_FlightMode __uC_FlightMode5;
        private UC_FlightMode __uC_FlightMode4;
        private UC_FlightMode __uC_FlightMode3;
        private UC_FlightMode __uC_FlightMode2;
        private UC_FlightMode __uC_FlightMode1;
        private System.Windows.Forms.Button __default_button;
        private System.Windows.Forms.Label __mode_mix_Label;
        private System.Windows.Forms.Label __modeC_label;
        private System.Windows.Forms.Label __modeB_label;
        private System.Windows.Forms.Label __mode_label;
    }
}
