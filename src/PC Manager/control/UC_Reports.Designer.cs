namespace CustomPilot.control
{
    partial class UC_Reports
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
            this._reports_groupBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.@__WDT_label = new System.Windows.Forms.Label();
            this.@__export_button = new System.Windows.Forms.Button();
            this.@__count_label = new System.Windows.Forms.Label();
            this.@__fid_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.___reset_button = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.@__dataGridView = new System.Windows.Forms.DataGridView();
            this.FID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RADIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEMP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ERR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.V = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.T = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.W = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._reports_groupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.@__dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _reports_groupBox
            // 
            this._reports_groupBox.Controls.Add(this.label4);
            this._reports_groupBox.Controls.Add(this.@__WDT_label);
            this._reports_groupBox.Controls.Add(this.@__export_button);
            this._reports_groupBox.Controls.Add(this.@__count_label);
            this._reports_groupBox.Controls.Add(this.@__fid_label);
            this._reports_groupBox.Controls.Add(this.label2);
            this._reports_groupBox.Controls.Add(this.label1);
            this._reports_groupBox.Controls.Add(this.___reset_button);
            this._reports_groupBox.Location = new System.Drawing.Point(3, 3);
            this._reports_groupBox.Name = "_reports_groupBox";
            this._reports_groupBox.Size = new System.Drawing.Size(736, 71);
            this._reports_groupBox.TabIndex = 1;
            this._reports_groupBox.TabStop = false;
            this._reports_groupBox.Text = "Reports";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "WDT:";
            // 
            // __WDT_label
            // 
            this.@__WDT_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.@__WDT_label.Location = new System.Drawing.Point(166, 46);
            this.@__WDT_label.Name = "__WDT_label";
            this.@__WDT_label.Size = new System.Drawing.Size(39, 12);
            this.@__WDT_label.TabIndex = 6;
            this.@__WDT_label.Text = "SAFE";
            // 
            // __export_button
            // 
            this.@__export_button.Location = new System.Drawing.Point(574, 42);
            this.@__export_button.Name = "__export_button";
            this.@__export_button.Size = new System.Drawing.Size(75, 23);
            this.@__export_button.TabIndex = 5;
            this.@__export_button.Text = "Export(&E)";
            this.@__export_button.UseVisualStyleBackColor = true;
            this.@__export_button.Click += new System.EventHandler(this.@__export_button_Click);
            // 
            // __count_label
            // 
            this.@__count_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.@__count_label.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.@__count_label.Location = new System.Drawing.Point(58, 47);
            this.@__count_label.Name = "__count_label";
            this.@__count_label.Size = new System.Drawing.Size(39, 12);
            this.@__count_label.TabIndex = 4;
            this.@__count_label.Text = "00000";
            // 
            // __fid_label
            // 
            this.@__fid_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.@__fid_label.Location = new System.Drawing.Point(58, 28);
            this.@__fid_label.Name = "__fid_label";
            this.@__fid_label.Size = new System.Drawing.Size(39, 12);
            this.@__fid_label.TabIndex = 3;
            this.@__fid_label.Text = "00000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Count: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "FID: ";
            // 
            // ___reset_button
            // 
            this.___reset_button.Location = new System.Drawing.Point(655, 42);
            this.___reset_button.Name = "___reset_button";
            this.___reset_button.Size = new System.Drawing.Size(75, 23);
            this.___reset_button.TabIndex = 0;
            this.___reset_button.Text = "Reset(&R)";
            this.___reset_button.UseVisualStyleBackColor = true;
            this.___reset_button.Click += new System.EventHandler(this.@__reset_button_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.@__dataGridView);
            this.groupBox2.Location = new System.Drawing.Point(3, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(736, 405);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "History";
            // 
            // __dataGridView
            // 
            this.@__dataGridView.AllowUserToAddRows = false;
            this.@__dataGridView.AllowUserToDeleteRows = false;
            this.@__dataGridView.AllowUserToResizeColumns = false;
            this.@__dataGridView.AllowUserToResizeRows = false;
            this.@__dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.@__dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.@__dataGridView.ColumnHeadersHeight = 30;
            this.@__dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.@__dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FID,
            this.Time,
            this.RADIO,
            this.VCC,
            this.TEMP,
            this.ERR,
            this.LOC,
            this.R,
            this.V,
            this.T,
            this.E,
            this.W});
            this.@__dataGridView.Location = new System.Drawing.Point(6, 20);
            this.@__dataGridView.Name = "__dataGridView";
            this.@__dataGridView.ReadOnly = true;
            this.@__dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.@__dataGridView.RowTemplate.Height = 23;
            this.@__dataGridView.Size = new System.Drawing.Size(724, 379);
            this.@__dataGridView.TabIndex = 1;
            // 
            // FID
            // 
            this.FID.HeaderText = "FID";
            this.FID.MaxInputLength = 10;
            this.FID.Name = "FID";
            this.FID.ReadOnly = true;
            this.FID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FID.Width = 50;
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.MaxInputLength = 20;
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RADIO
            // 
            this.RADIO.HeaderText = "RADIO";
            this.RADIO.MaxInputLength = 10;
            this.RADIO.Name = "RADIO";
            this.RADIO.ReadOnly = true;
            this.RADIO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RADIO.Width = 70;
            // 
            // VCC
            // 
            this.VCC.HeaderText = "VCC";
            this.VCC.MaxInputLength = 10;
            this.VCC.Name = "VCC";
            this.VCC.ReadOnly = true;
            this.VCC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.VCC.Width = 50;
            // 
            // TEMP
            // 
            this.TEMP.HeaderText = "TEMP";
            this.TEMP.MaxInputLength = 10;
            this.TEMP.Name = "TEMP";
            this.TEMP.ReadOnly = true;
            this.TEMP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TEMP.Width = 50;
            // 
            // ERR
            // 
            this.ERR.HeaderText = "ERR";
            this.ERR.MaxInputLength = 10;
            this.ERR.Name = "ERR";
            this.ERR.ReadOnly = true;
            this.ERR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ERR.Width = 50;
            // 
            // LOC
            // 
            this.LOC.HeaderText = "LOC";
            this.LOC.MaxInputLength = 10;
            this.LOC.Name = "LOC";
            this.LOC.ReadOnly = true;
            this.LOC.Width = 40;
            // 
            // R
            // 
            this.R.HeaderText = "R";
            this.R.Name = "R";
            this.R.ReadOnly = true;
            this.R.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.R.Width = 20;
            // 
            // V
            // 
            this.V.HeaderText = "V";
            this.V.Name = "V";
            this.V.ReadOnly = true;
            this.V.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.V.Width = 20;
            // 
            // T
            // 
            this.T.HeaderText = "T";
            this.T.Name = "T";
            this.T.ReadOnly = true;
            this.T.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.T.Width = 20;
            // 
            // E
            // 
            this.E.HeaderText = "E";
            this.E.Name = "E";
            this.E.ReadOnly = true;
            this.E.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.E.Width = 20;
            // 
            // W
            // 
            this.W.HeaderText = "W";
            this.W.Name = "W";
            this.W.ReadOnly = true;
            this.W.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.W.Width = 20;
            // 
            // UC_Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this._reports_groupBox);
            this.Name = "UC_Reports";
            this.Size = new System.Drawing.Size(931, 666);
            this._reports_groupBox.ResumeLayout(false);
            this._reports_groupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.@__dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox _reports_groupBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView __dataGridView;
        private System.Windows.Forms.Button ___reset_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label __count_label;
        private System.Windows.Forms.Label __fid_label;
        private System.Windows.Forms.Button __export_button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label __WDT_label;
        private System.Windows.Forms.DataGridViewTextBoxColumn FID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn RADIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn VCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEMP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ERR;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn R;
        private System.Windows.Forms.DataGridViewTextBoxColumn V;
        private System.Windows.Forms.DataGridViewTextBoxColumn T;
        private System.Windows.Forms.DataGridViewTextBoxColumn E;
        private System.Windows.Forms.DataGridViewTextBoxColumn W;
    }
}
