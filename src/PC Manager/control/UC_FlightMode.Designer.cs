namespace CustomPilot.control
{
    partial class UC_FlightMode
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
            this.@__mixmode_label = new System.Windows.Forms.Label();
            this.@__modename_label = new System.Windows.Forms.Label();
            this.@__set_button = new System.Windows.Forms.Button();
            this.@__del_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // __mixmode_label
            // 
            this.@__mixmode_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.@__mixmode_label.Location = new System.Drawing.Point(134, 1);
            this.@__mixmode_label.Name = "__mixmode_label";
            this.@__mixmode_label.Size = new System.Drawing.Size(28, 24);
            this.@__mixmode_label.TabIndex = 3;
            this.@__mixmode_label.Text = "000";
            this.@__mixmode_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // __modename_label
            // 
            this.@__modename_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.@__modename_label.Location = new System.Drawing.Point(3, 1);
            this.@__modename_label.Name = "__modename_label";
            this.@__modename_label.Size = new System.Drawing.Size(123, 24);
            this.@__modename_label.TabIndex = 5;
            this.@__modename_label.Text = "MANUAL";
            this.@__modename_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // __set_button
            // 
            this.@__set_button.Enabled = false;
            this.@__set_button.Location = new System.Drawing.Point(169, 1);
            this.@__set_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.@__set_button.Name = "__set_button";
            this.@__set_button.Size = new System.Drawing.Size(45, 26);
            this.@__set_button.TabIndex = 6;
            this.@__set_button.Text = "set";
            this.@__set_button.UseVisualStyleBackColor = true;
            this.@__set_button.Click += new System.EventHandler(this.@__set_button_Click);
            // 
            // __del_button
            // 
            this.@__del_button.Enabled = false;
            this.@__del_button.Location = new System.Drawing.Point(219, 1);
            this.@__del_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.@__del_button.Name = "__del_button";
            this.@__del_button.Size = new System.Drawing.Size(45, 26);
            this.@__del_button.TabIndex = 7;
            this.@__del_button.Text = "del";
            this.@__del_button.UseVisualStyleBackColor = true;
            this.@__del_button.Click += new System.EventHandler(this.@__del_button_Click);
            // 
            // UC_FlightMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.@__del_button);
            this.Controls.Add(this.@__set_button);
            this.Controls.Add(this.@__modename_label);
            this.Controls.Add(this.@__mixmode_label);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UC_FlightMode";
            this.Size = new System.Drawing.Size(267, 28);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label __mixmode_label;
        private System.Windows.Forms.Label __modename_label;
        private System.Windows.Forms.Button __set_button;
        private System.Windows.Forms.Button __del_button;
    }
}
