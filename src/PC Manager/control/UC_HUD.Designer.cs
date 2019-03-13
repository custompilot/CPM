namespace CustomPilot.control
{
    partial class UC_HUD
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
            this.@__hud = new Simple_HUD.HUD_Graphic();
            this.@__alt = new Simple_HUD.Altimeter();
            this.@__hor = new Simple_HUD.Horizon();
            this.@__comp = new Simple_HUD.Compass();
            this.@__imuCal_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // __hud
            // 
            this.@__hud.Airspeed = 0F;
            this.@__hud.AlphaBrushColor = System.Drawing.Color.Black;
            this.@__hud.Altitude = 0F;
            this.@__hud.BrushAlpha = 70;
            this.@__hud.BrushTextBackgroundAlpha = 200;
            this.@__hud.Heading = 0F;
            this.@__hud.LinePenColor = System.Drawing.Color.White;
            this.@__hud.Location = new System.Drawing.Point(3, 0);
            this.@__hud.Name = "__hud";
            this.@__hud.Pitch = 0F;
            this.@__hud.Roll = 0F;
            this.@__hud.Size = new System.Drawing.Size(464, 450);
            this.@__hud.TabIndex = 0;
            this.@__hud.TextBackgroundBrushColor = System.Drawing.Color.Black;
            this.@__hud.TextBrushColor = System.Drawing.Color.White;
            // 
            // __alt
            // 
            this.@__alt.Altitude = 0F;
            this.@__alt.Location = new System.Drawing.Point(473, 0);
            this.@__alt.Name = "__alt";
            this.@__alt.Size = new System.Drawing.Size(145, 145);
            this.@__alt.TabIndex = 1;
            // 
            // __hor
            // 
            this.@__hor.Location = new System.Drawing.Point(473, 151);
            this.@__hor.Name = "__hor";
            this.@__hor.Pitch = 0F;
            this.@__hor.Roll = 0F;
            this.@__hor.Size = new System.Drawing.Size(145, 145);
            this.@__hor.TabIndex = 2;
            // 
            // __comp
            // 
            this.@__comp.Heading = 0F;
            this.@__comp.Location = new System.Drawing.Point(473, 305);
            this.@__comp.Name = "__comp";
            this.@__comp.Size = new System.Drawing.Size(145, 145);
            this.@__comp.TabIndex = 3;
            this.@__comp.YawRate = 0F;
            // 
            // __imuCal_label
            // 
            this.@__imuCal_label.AutoSize = true;
            this.@__imuCal_label.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.@__imuCal_label.ForeColor = System.Drawing.Color.Red;
            this.@__imuCal_label.Location = new System.Drawing.Point(50, 206);
            this.@__imuCal_label.Name = "__imuCal_label";
            this.@__imuCal_label.Size = new System.Drawing.Size(359, 32);
            this.@__imuCal_label.TabIndex = 4;
            this.@__imuCal_label.Text = "Calibration warning!!!";
            // 
            // UC_HUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.@__imuCal_label);
            this.Controls.Add(this.@__comp);
            this.Controls.Add(this.@__hor);
            this.Controls.Add(this.@__alt);
            this.Controls.Add(this.@__hud);
            this.Name = "UC_HUD";
            this.Size = new System.Drawing.Size(632, 466);
            this.Load += new System.EventHandler(this.UC_HUD_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Simple_HUD.HUD_Graphic __hud;
        private Simple_HUD.Altimeter __alt;
        private Simple_HUD.Horizon __hor;
        private Simple_HUD.Compass __comp;
        private System.Windows.Forms.Label __imuCal_label;
    }
}
