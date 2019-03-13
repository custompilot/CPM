namespace CustomPilot.control
{
    partial class UC_Mount
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
            this.@__install_groupBox = new System.Windows.Forms.GroupBox();
            this.@__tb_groupBox = new System.Windows.Forms.GroupBox();
            this.@__reverse_comboBox = new System.Windows.Forms.ComboBox();
            this.@__fb_groupBox = new System.Windows.Forms.GroupBox();
            this.@__backword_comboBox = new System.Windows.Forms.ComboBox();
            this.@__picture = new System.Windows.Forms.PictureBox();
            this.@__install_groupBox.SuspendLayout();
            this.@__tb_groupBox.SuspendLayout();
            this.@__fb_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.@__picture)).BeginInit();
            this.SuspendLayout();
            // 
            // __install_groupBox
            // 
            this.@__install_groupBox.Controls.Add(this.@__tb_groupBox);
            this.@__install_groupBox.Controls.Add(this.@__fb_groupBox);
            this.@__install_groupBox.Controls.Add(this.@__picture);
            this.@__install_groupBox.Location = new System.Drawing.Point(3, 3);
            this.@__install_groupBox.Name = "__install_groupBox";
            this.@__install_groupBox.Size = new System.Drawing.Size(758, 484);
            this.@__install_groupBox.TabIndex = 0;
            this.@__install_groupBox.TabStop = false;
            this.@__install_groupBox.Text = "Mount";
            this.@__install_groupBox.Enter += new System.EventHandler(this.@__install_groupBox_Enter);
            // 
            // __tb_groupBox
            // 
            this.@__tb_groupBox.Controls.Add(this.@__reverse_comboBox);
            this.@__tb_groupBox.Location = new System.Drawing.Point(572, 74);
            this.@__tb_groupBox.Name = "__tb_groupBox";
            this.@__tb_groupBox.Size = new System.Drawing.Size(156, 48);
            this.@__tb_groupBox.TabIndex = 1;
            this.@__tb_groupBox.TabStop = false;
            this.@__tb_groupBox.Text = "Top/Bottom";
            // 
            // __reverse_comboBox
            // 
            this.@__reverse_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.@__reverse_comboBox.FormattingEnabled = true;
            this.@__reverse_comboBox.Items.AddRange(new object[] {
            "TOP",
            "BOTTOM"});
            this.@__reverse_comboBox.Location = new System.Drawing.Point(6, 22);
            this.@__reverse_comboBox.Name = "__reverse_comboBox";
            this.@__reverse_comboBox.Size = new System.Drawing.Size(144, 20);
            this.@__reverse_comboBox.TabIndex = 1;
            this.@__reverse_comboBox.TextChanged += new System.EventHandler(this.@__backword_comboBox_TextChanged);
            // 
            // __fb_groupBox
            // 
            this.@__fb_groupBox.Controls.Add(this.@__backword_comboBox);
            this.@__fb_groupBox.Location = new System.Drawing.Point(572, 20);
            this.@__fb_groupBox.Name = "__fb_groupBox";
            this.@__fb_groupBox.Size = new System.Drawing.Size(156, 48);
            this.@__fb_groupBox.TabIndex = 0;
            this.@__fb_groupBox.TabStop = false;
            this.@__fb_groupBox.Text = "Front/Back";
            // 
            // __backword_comboBox
            // 
            this.@__backword_comboBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.@__backword_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.@__backword_comboBox.FormattingEnabled = true;
            this.@__backword_comboBox.Items.AddRange(new object[] {
            "FRONT",
            "BACKWARD"});
            this.@__backword_comboBox.Location = new System.Drawing.Point(6, 20);
            this.@__backword_comboBox.Name = "__backword_comboBox";
            this.@__backword_comboBox.Size = new System.Drawing.Size(144, 20);
            this.@__backword_comboBox.TabIndex = 0;
            this.@__backword_comboBox.TextChanged += new System.EventHandler(this.@__backword_comboBox_TextChanged);
            // 
            // __picture
            // 
            this.@__picture.Location = new System.Drawing.Point(6, 20);
            this.@__picture.Name = "__picture";
            this.@__picture.Size = new System.Drawing.Size(560, 444);
            this.@__picture.TabIndex = 2;
            this.@__picture.TabStop = false;
            // 
            // UC_Mount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.@__install_groupBox);
            this.Name = "UC_Mount";
            this.Size = new System.Drawing.Size(764, 484);
            this.Load += new System.EventHandler(this.UC_Mount_Load);
            this.@__install_groupBox.ResumeLayout(false);
            this.@__tb_groupBox.ResumeLayout(false);
            this.@__fb_groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.@__picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox __install_groupBox;
        private System.Windows.Forms.GroupBox __tb_groupBox;
        private System.Windows.Forms.GroupBox __fb_groupBox;
        private System.Windows.Forms.ComboBox __reverse_comboBox;
        private System.Windows.Forms.ComboBox __backword_comboBox;
        private System.Windows.Forms.PictureBox __picture;
    }
}
