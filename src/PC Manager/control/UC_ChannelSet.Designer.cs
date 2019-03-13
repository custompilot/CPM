namespace CustomPilot.control
{
    partial class UC_ChannelSet
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
            this.components = new System.ComponentModel.Container();
            this.@__uC_ChannelMonitor1 = new CustomPilot.control.UC_ChannelMonitor();
            this._timer = new System.Windows.Forms.Timer(this.components);
            this.@__max_down_button = new System.Windows.Forms.Button();
            this.@__max_up_button = new System.Windows.Forms.Button();
            this.@__max_textBox = new System.Windows.Forms.TextBox();
            this.@__min_down_button = new System.Windows.Forms.Button();
            this.@__min_up_button = new System.Windows.Forms.Button();
            this.@__min_textBox = new System.Windows.Forms.TextBox();
            this.@__mid_down_button = new System.Windows.Forms.Button();
            this.@__mid_up_button = new System.Windows.Forms.Button();
            this.@__mid_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.@__reverse_checkBox = new System.Windows.Forms.CheckBox();
            this.@__current_TextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // __uC_ChannelMonitor1
            // 
            this.@__uC_ChannelMonitor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.@__uC_ChannelMonitor1.Center = 1496;
            this.@__uC_ChannelMonitor1.Current = 1496;
            this.@__uC_ChannelMonitor1.High = 2012;
            this.@__uC_ChannelMonitor1.Location = new System.Drawing.Point(130, 4);
            this.@__uC_ChannelMonitor1.Low = 988;
            this.@__uC_ChannelMonitor1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.@__uC_ChannelMonitor1.Name = "__uC_ChannelMonitor1";
            this.@__uC_ChannelMonitor1.Size = new System.Drawing.Size(191, 24);
            this.@__uC_ChannelMonitor1.TabIndex = 1;
            // 
            // _timer
            // 
            this._timer.Interval = 250;
            this._timer.Tick += new System.EventHandler(this._timer_Tick);
            // 
            // __max_down_button
            // 
            this.@__max_down_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.@__max_down_button.Location = new System.Drawing.Point(323, 4);
            this.@__max_down_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.@__max_down_button.Name = "__max_down_button";
            this.@__max_down_button.Size = new System.Drawing.Size(23, 25);
            this.@__max_down_button.TabIndex = 6;
            this.@__max_down_button.Text = "◀";
            this.@__max_down_button.UseVisualStyleBackColor = true;
            this.@__max_down_button.Click += new System.EventHandler(this.@__max_down_button_Click);
            // 
            // __max_up_button
            // 
            this.@__max_up_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.@__max_up_button.Location = new System.Drawing.Point(387, 4);
            this.@__max_up_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.@__max_up_button.Name = "__max_up_button";
            this.@__max_up_button.Size = new System.Drawing.Size(23, 25);
            this.@__max_up_button.TabIndex = 7;
            this.@__max_up_button.Text = "▶";
            this.@__max_up_button.UseVisualStyleBackColor = true;
            this.@__max_up_button.Click += new System.EventHandler(this.@__max_up_button_Click);
            // 
            // __max_textBox
            // 
            this.@__max_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.@__max_textBox.Location = new System.Drawing.Point(350, 9);
            this.@__max_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.@__max_textBox.MaxLength = 4;
            this.@__max_textBox.Name = "__max_textBox";
            this.@__max_textBox.Size = new System.Drawing.Size(34, 18);
            this.@__max_textBox.TabIndex = 8;
            this.@__max_textBox.Text = "2012";
            this.@__max_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.@__max_textBox.TextChanged += new System.EventHandler(this.@__max_textBox_TextChanged);
            this.@__max_textBox.Leave += new System.EventHandler(this.@__max_textBox_Leave);
            // 
            // __min_down_button
            // 
            this.@__min_down_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.@__min_down_button.Location = new System.Drawing.Point(41, 4);
            this.@__min_down_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.@__min_down_button.Name = "__min_down_button";
            this.@__min_down_button.Size = new System.Drawing.Size(23, 25);
            this.@__min_down_button.TabIndex = 9;
            this.@__min_down_button.Text = "◀";
            this.@__min_down_button.UseVisualStyleBackColor = true;
            this.@__min_down_button.Click += new System.EventHandler(this.@__min_down_button_Click);
            // 
            // __min_up_button
            // 
            this.@__min_up_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.@__min_up_button.Location = new System.Drawing.Point(105, 4);
            this.@__min_up_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.@__min_up_button.Name = "__min_up_button";
            this.@__min_up_button.Size = new System.Drawing.Size(23, 25);
            this.@__min_up_button.TabIndex = 10;
            this.@__min_up_button.Text = "▶";
            this.@__min_up_button.UseVisualStyleBackColor = true;
            this.@__min_up_button.Click += new System.EventHandler(this.@__min_up_button_Click);
            // 
            // __min_textBox
            // 
            this.@__min_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.@__min_textBox.Location = new System.Drawing.Point(67, 9);
            this.@__min_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.@__min_textBox.Name = "__min_textBox";
            this.@__min_textBox.Size = new System.Drawing.Size(34, 18);
            this.@__min_textBox.TabIndex = 11;
            this.@__min_textBox.Text = "988";
            this.@__min_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.@__min_textBox.TextChanged += new System.EventHandler(this.@__min_textBox_TextChanged);
            this.@__min_textBox.Leave += new System.EventHandler(this.@__min_textBox_Leave);
            // 
            // __mid_down_button
            // 
            this.@__mid_down_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.@__mid_down_button.Location = new System.Drawing.Point(422, 4);
            this.@__mid_down_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.@__mid_down_button.Name = "__mid_down_button";
            this.@__mid_down_button.Size = new System.Drawing.Size(23, 25);
            this.@__mid_down_button.TabIndex = 12;
            this.@__mid_down_button.Text = "◀";
            this.@__mid_down_button.UseVisualStyleBackColor = true;
            this.@__mid_down_button.Click += new System.EventHandler(this.@__mid_down_button_Click);
            // 
            // __mid_up_button
            // 
            this.@__mid_up_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.@__mid_up_button.Location = new System.Drawing.Point(486, 4);
            this.@__mid_up_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.@__mid_up_button.Name = "__mid_up_button";
            this.@__mid_up_button.Size = new System.Drawing.Size(23, 25);
            this.@__mid_up_button.TabIndex = 13;
            this.@__mid_up_button.Text = "▶";
            this.@__mid_up_button.UseVisualStyleBackColor = true;
            this.@__mid_up_button.Click += new System.EventHandler(this.@__mid_up_button_Click);
            // 
            // __mid_textBox
            // 
            this.@__mid_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.@__mid_textBox.Location = new System.Drawing.Point(448, 9);
            this.@__mid_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.@__mid_textBox.MaxLength = 4;
            this.@__mid_textBox.Name = "__mid_textBox";
            this.@__mid_textBox.Size = new System.Drawing.Size(34, 18);
            this.@__mid_textBox.TabIndex = 14;
            this.@__mid_textBox.Text = "1500";
            this.@__mid_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.@__mid_textBox.TextChanged += new System.EventHandler(this.@__mid_textBox_TextChanged);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(415, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2, 24);
            this.label1.TabIndex = 15;
            // 
            // __reverse_checkBox
            // 
            this.@__reverse_checkBox.AutoSize = true;
            this.@__reverse_checkBox.Location = new System.Drawing.Point(517, 8);
            this.@__reverse_checkBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.@__reverse_checkBox.Name = "__reverse_checkBox";
            this.@__reverse_checkBox.Size = new System.Drawing.Size(80, 19);
            this.@__reverse_checkBox.TabIndex = 16;
            this.@__reverse_checkBox.Text = "Reverse";
            this.@__reverse_checkBox.UseVisualStyleBackColor = true;
            this.@__reverse_checkBox.CheckedChanged += new System.EventHandler(this.@__reverse_checkBox_CheckedChanged);
            // 
            // __current_TextBox
            // 
            this.@__current_TextBox.BackColor = System.Drawing.Color.Red;
            this.@__current_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.@__current_TextBox.ForeColor = System.Drawing.Color.Black;
            this.@__current_TextBox.Location = new System.Drawing.Point(0, 9);
            this.@__current_TextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.@__current_TextBox.Name = "__current_TextBox";
            this.@__current_TextBox.ReadOnly = true;
            this.@__current_TextBox.Size = new System.Drawing.Size(34, 18);
            this.@__current_TextBox.TabIndex = 17;
            this.@__current_TextBox.Text = "988";
            this.@__current_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UC_ChannelSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.@__current_TextBox);
            this.Controls.Add(this.@__reverse_checkBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.@__mid_textBox);
            this.Controls.Add(this.@__mid_up_button);
            this.Controls.Add(this.@__mid_down_button);
            this.Controls.Add(this.@__min_textBox);
            this.Controls.Add(this.@__min_up_button);
            this.Controls.Add(this.@__min_down_button);
            this.Controls.Add(this.@__max_textBox);
            this.Controls.Add(this.@__max_up_button);
            this.Controls.Add(this.@__max_down_button);
            this.Controls.Add(this.@__uC_ChannelMonitor1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UC_ChannelSet";
            this.Size = new System.Drawing.Size(598, 35);
            this.Load += new System.EventHandler(this.UC_ChannelSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UC_ChannelMonitor __uC_ChannelMonitor1;
        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.Button __max_down_button;
        private System.Windows.Forms.Button __max_up_button;
        private System.Windows.Forms.TextBox __max_textBox;
        private System.Windows.Forms.Button __min_down_button;
        private System.Windows.Forms.Button __min_up_button;
        private System.Windows.Forms.TextBox __min_textBox;
        private System.Windows.Forms.Button __mid_down_button;
        private System.Windows.Forms.Button __mid_up_button;
        private System.Windows.Forms.TextBox __mid_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox __reverse_checkBox;
        private System.Windows.Forms.TextBox __current_TextBox;
    }
}
