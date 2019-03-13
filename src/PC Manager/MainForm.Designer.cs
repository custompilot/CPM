namespace CustomPilot
{
    partial class MainForm
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.@__openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.@__saveOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.@__exitXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.@__settingSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imutoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.@__IMUCalibrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.factoryreset_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.@__supportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._languages_toolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.@__userLanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.@__manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.@__firmware1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.@__productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.@__installUSBDriverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.@__helpHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.@__onlineSupportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.@__tESTTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.@__aboutAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.@__com_toolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.@__refresh_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.@__connect_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.@__firmver_toolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.@__timer_serial = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.___looptime_toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.@__ypr_toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.___gforce_toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.___vcc_toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.___temp_toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.___err_toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.___report_toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this._devicename__toolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this._set_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this._size_toolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.@__uC_TabFirmware = new CustomPilot.control.UC_TabFirmware();
            this.@__tabControl = new System.Windows.Forms.TabControl();
            this.@__mount_tabPage = new System.Windows.Forms.TabPage();
            this.@__uC_Mount = new CustomPilot.control.UC_Mount();
            this.@__radio_tabPage = new System.Windows.Forms.TabPage();
            this._uC_RadioTab = new CustomPilot.control.UC_TabRadio();
            this.@__mode_tabPage = new System.Windows.Forms.TabPage();
            this.@__uC_FlightModeWindow = new CustomPilot.control.UC_TabFlightMode();
            this._output_tabPage = new System.Windows.Forms.TabPage();
            this._uC_ServoWindow = new CustomPilot.control.UC_TabServo();
            this.@__sensors_tabPage = new System.Windows.Forms.TabPage();
            this.@__uc_HUD = new CustomPilot.control.UC_HUD();
            this.@__reports_tabPage = new System.Windows.Forms.TabPage();
            this.@__uC_Reports = new CustomPilot.control.UC_Reports();
            this.DEBUG = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.@__uC_TabDebug = new CustomPilot.control.UC_TabDebug();
            this.@__firmware2 = new System.Windows.Forms.ToolStripMenuItem();
            this.@__pCManager = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.@__tabControl.SuspendLayout();
            this.@__mount_tabPage.SuspendLayout();
            this.@__radio_tabPage.SuspendLayout();
            this.@__mode_tabPage.SuspendLayout();
            this._output_tabPage.SuspendLayout();
            this.@__sensors_tabPage.SuspendLayout();
            this.@__reports_tabPage.SuspendLayout();
            this.DEBUG.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileFToolStripMenuItem,
            this.@__settingSToolStripMenuItem,
            this.@__supportToolStripMenuItem,
            this.@__helpHToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(738, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileFToolStripMenuItem
            // 
            this.fileFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.@__openToolStripMenuItem,
            this.@__saveOToolStripMenuItem,
            this.toolStripMenuItem1,
            this.@__exitXToolStripMenuItem});
            this.fileFToolStripMenuItem.Name = "fileFToolStripMenuItem";
            this.fileFToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.fileFToolStripMenuItem.Text = "File(&F)";
            // 
            // __openToolStripMenuItem
            // 
            this.@__openToolStripMenuItem.Enabled = false;
            this.@__openToolStripMenuItem.Name = "__openToolStripMenuItem";
            this.@__openToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.@__openToolStripMenuItem.Text = "Open(&O)";
            this.@__openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // __saveOToolStripMenuItem
            // 
            this.@__saveOToolStripMenuItem.Enabled = false;
            this.@__saveOToolStripMenuItem.Name = "__saveOToolStripMenuItem";
            this.@__saveOToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.@__saveOToolStripMenuItem.Text = "Save(&O)";
            this.@__saveOToolStripMenuItem.Click += new System.EventHandler(this.saveOToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(117, 6);
            // 
            // __exitXToolStripMenuItem
            // 
            this.@__exitXToolStripMenuItem.Name = "__exitXToolStripMenuItem";
            this.@__exitXToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.@__exitXToolStripMenuItem.Text = "Exit(&X)";
            this.@__exitXToolStripMenuItem.Click += new System.EventHandler(this.@__exitXToolStripMenuItem_Click);
            // 
            // __settingSToolStripMenuItem
            // 
            this.@__settingSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imutoolStripMenuItem,
            this.toolStripMenuItem5,
            this.factoryreset_ToolStripMenuItem});
            this.@__settingSToolStripMenuItem.Enabled = false;
            this.@__settingSToolStripMenuItem.Name = "__settingSToolStripMenuItem";
            this.@__settingSToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.@__settingSToolStripMenuItem.Text = "Setting(&S)";
            // 
            // imutoolStripMenuItem
            // 
            this.imutoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.@__IMUCalibrationToolStripMenuItem});
            this.imutoolStripMenuItem.Name = "imutoolStripMenuItem";
            this.imutoolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.imutoolStripMenuItem.Text = "IMU";
            // 
            // __IMUCalibrationToolStripMenuItem
            // 
            this.@__IMUCalibrationToolStripMenuItem.Name = "__IMUCalibrationToolStripMenuItem";
            this.@__IMUCalibrationToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.@__IMUCalibrationToolStripMenuItem.Text = "IMU Calibration";
            this.@__IMUCalibrationToolStripMenuItem.Click += new System.EventHandler(this.@__gyroCalibrationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(142, 6);
            // 
            // factoryreset_ToolStripMenuItem
            // 
            this.factoryreset_ToolStripMenuItem.Name = "factoryreset_ToolStripMenuItem";
            this.factoryreset_ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.factoryreset_ToolStripMenuItem.Text = "Factory Reset";
            this.factoryreset_ToolStripMenuItem.Click += new System.EventHandler(this.@__reset_ToolStripMenuItem_Click);
            // 
            // __supportToolStripMenuItem
            // 
            this.@__supportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._languages_toolStripComboBox,
            this.@__userLanguageToolStripMenuItem,
            this.toolStripMenuItem3,
            this.@__manualToolStripMenuItem,
            this.@__firmware1,
            this.@__firmware2,
            this.@__pCManager,
            this.toolStripMenuItem6,
            this.@__productsToolStripMenuItem,
            this.toolStripMenuItem7,
            this.@__installUSBDriverToolStripMenuItem});
            this.@__supportToolStripMenuItem.Name = "__supportToolStripMenuItem";
            this.@__supportToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.@__supportToolStripMenuItem.Text = "Support";
            // 
            // _languages_toolStripComboBox
            // 
            this._languages_toolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._languages_toolStripComboBox.Name = "_languages_toolStripComboBox";
            this._languages_toolStripComboBox.Size = new System.Drawing.Size(121, 23);
            this._languages_toolStripComboBox.SelectedIndexChanged += new System.EventHandler(this._languages_toolStripComboBox_SelectedIndexChanged);
            // 
            // __userLanguageToolStripMenuItem
            // 
            this.@__userLanguageToolStripMenuItem.Name = "__userLanguageToolStripMenuItem";
            this.@__userLanguageToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.@__userLanguageToolStripMenuItem.Text = "User language";
            this.@__userLanguageToolStripMenuItem.Click += new System.EventHandler(this.@__userLanguageToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(178, 6);
            // 
            // __manualToolStripMenuItem
            // 
            this.@__manualToolStripMenuItem.Name = "__manualToolStripMenuItem";
            this.@__manualToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.@__manualToolStripMenuItem.Text = "Manual";
            this.@__manualToolStripMenuItem.Click += new System.EventHandler(this.@__manualToolStripMenuItem_Click);
            // 
            // __firmware1
            // 
            this.@__firmware1.Name = "__firmware1";
            this.@__firmware1.Size = new System.Drawing.Size(181, 22);
            this.@__firmware1.Text = "Firmware";
            this.@__firmware1.Click += new System.EventHandler(this.@__firmware1_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(178, 6);
            // 
            // __productsToolStripMenuItem
            // 
            this.@__productsToolStripMenuItem.Enabled = false;
            this.@__productsToolStripMenuItem.Name = "__productsToolStripMenuItem";
            this.@__productsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.@__productsToolStripMenuItem.Text = "Products";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(178, 6);
            // 
            // __installUSBDriverToolStripMenuItem
            // 
            this.@__installUSBDriverToolStripMenuItem.Name = "__installUSBDriverToolStripMenuItem";
            this.@__installUSBDriverToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.@__installUSBDriverToolStripMenuItem.Text = "Install USB Driver";
            this.@__installUSBDriverToolStripMenuItem.Click += new System.EventHandler(this.@__installUSBDriverToolStripMenuItem_Click);
            // 
            // __helpHToolStripMenuItem
            // 
            this.@__helpHToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.@__onlineSupportToolStripMenuItem,
            this.@__tESTTToolStripMenuItem,
            this.toolStripMenuItem4,
            this.@__aboutAToolStripMenuItem});
            this.@__helpHToolStripMenuItem.Name = "__helpHToolStripMenuItem";
            this.@__helpHToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.@__helpHToolStripMenuItem.Text = "Help(&H)";
            // 
            // __onlineSupportToolStripMenuItem
            // 
            this.@__onlineSupportToolStripMenuItem.Name = "__onlineSupportToolStripMenuItem";
            this.@__onlineSupportToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.@__onlineSupportToolStripMenuItem.Text = "Online support(&O)";
            this.@__onlineSupportToolStripMenuItem.Click += new System.EventHandler(this.@__onlineSupportToolStripMenuItem_Click);
            // 
            // __tESTTToolStripMenuItem
            // 
            this.@__tESTTToolStripMenuItem.Name = "__tESTTToolStripMenuItem";
            this.@__tESTTToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.@__tESTTToolStripMenuItem.Text = "TEST(&T)";
            this.@__tESTTToolStripMenuItem.Click += new System.EventHandler(this.@__tESTTToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(225, 6);
            // 
            // __aboutAToolStripMenuItem
            // 
            this.@__aboutAToolStripMenuItem.Name = "__aboutAToolStripMenuItem";
            this.@__aboutAToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.@__aboutAToolStripMenuItem.Text = "About Custompilot Micro(&A)";
            this.@__aboutAToolStripMenuItem.Click += new System.EventHandler(this.@__aboutAToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.@__com_toolStripComboBox,
            this.@__refresh_toolStripButton,
            this.@__connect_toolStripButton,
            this.@__firmver_toolStripLabel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(738, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // __com_toolStripComboBox
            // 
            this.@__com_toolStripComboBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.@__com_toolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.@__com_toolStripComboBox.Name = "__com_toolStripComboBox";
            this.@__com_toolStripComboBox.Size = new System.Drawing.Size(200, 25);
            this.@__com_toolStripComboBox.DropDown += new System.EventHandler(this.@__com_toolStripComboBox_DropDown);
            this.@__com_toolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.@__com_toolStripComboBox_SelectedIndexChanged);
            // 
            // __refresh_toolStripButton
            // 
            this.@__refresh_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.@__refresh_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("__refresh_toolStripButton.Image")));
            this.@__refresh_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.@__refresh_toolStripButton.Name = "__refresh_toolStripButton";
            this.@__refresh_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.@__refresh_toolStripButton.Text = "Refresh";
            this.@__refresh_toolStripButton.Click += new System.EventHandler(this.@__refresh_toolStripButton_Click);
            this.@__refresh_toolStripButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.@__refresh_toolStripButton_MouseMove);
            // 
            // __connect_toolStripButton
            // 
            this.@__connect_toolStripButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.@__connect_toolStripButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.@__connect_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.@__connect_toolStripButton.ForeColor = System.Drawing.Color.Black;
            this.@__connect_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.@__connect_toolStripButton.Name = "__connect_toolStripButton";
            this.@__connect_toolStripButton.Size = new System.Drawing.Size(56, 22);
            this.@__connect_toolStripButton.Text = "Connect";
            this.@__connect_toolStripButton.Click += new System.EventHandler(this.@__connect_toolStripButton_Click);
            this.@__connect_toolStripButton.MouseLeave += new System.EventHandler(this.@__connect_toolStripButton_MouseLeave);
            this.@__connect_toolStripButton.MouseHover += new System.EventHandler(this.@__connect_toolStripButton_MouseHover);
            this.@__connect_toolStripButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.@__connect_toolStripButton_MouseMove);
            // 
            // __firmver_toolStripLabel
            // 
            this.@__firmver_toolStripLabel.Name = "__firmver_toolStripLabel";
            this.@__firmver_toolStripLabel.Size = new System.Drawing.Size(85, 22);
            this.@__firmver_toolStripLabel.Text = "Firmware Ver: ";
            // 
            // __timer_serial
            // 
            this.@__timer_serial.Enabled = true;
            this.@__timer_serial.Interval = 1;
            this.@__timer_serial.Tick += new System.EventHandler(this.@__timer_serial_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.___looptime_toolStripStatusLabel,
            this.@__ypr_toolStripStatusLabel,
            this.___gforce_toolStripStatusLabel,
            this.___vcc_toolStripStatusLabel,
            this.___temp_toolStripStatusLabel,
            this.___err_toolStripStatusLabel,
            this.___report_toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 596);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(738, 24);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ___looptime_toolStripStatusLabel
            // 
            this.___looptime_toolStripStatusLabel.AutoSize = false;
            this.___looptime_toolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.___looptime_toolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.___looptime_toolStripStatusLabel.Name = "___looptime_toolStripStatusLabel";
            this.___looptime_toolStripStatusLabel.Size = new System.Drawing.Size(93, 19);
            this.___looptime_toolStripStatusLabel.Text = "Looptime: 0500";
            // 
            // __ypr_toolStripStatusLabel
            // 
            this.@__ypr_toolStripStatusLabel.AutoSize = false;
            this.@__ypr_toolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.@__ypr_toolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.@__ypr_toolStripStatusLabel.Name = "__ypr_toolStripStatusLabel";
            this.@__ypr_toolStripStatusLabel.Size = new System.Drawing.Size(136, 19);
            this.@__ypr_toolStripStatusLabel.Text = "ypr: 180.0 180.0 180.0";
            // 
            // ___gforce_toolStripStatusLabel
            // 
            this.___gforce_toolStripStatusLabel.AutoSize = false;
            this.___gforce_toolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.___gforce_toolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.___gforce_toolStripStatusLabel.Name = "___gforce_toolStripStatusLabel";
            this.___gforce_toolStripStatusLabel.Size = new System.Drawing.Size(136, 19);
            this.___gforce_toolStripStatusLabel.Text = "G: 180.0 180.0 180.0";
            this.___gforce_toolStripStatusLabel.Click += new System.EventHandler(this.___gforce_toolStripStatusLabel_Click);
            // 
            // ___vcc_toolStripStatusLabel
            // 
            this.___vcc_toolStripStatusLabel.AutoSize = false;
            this.___vcc_toolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.___vcc_toolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.___vcc_toolStripStatusLabel.Name = "___vcc_toolStripStatusLabel";
            this.___vcc_toolStripStatusLabel.Size = new System.Drawing.Size(68, 19);
            this.___vcc_toolStripStatusLabel.Text = "vcc: 4.95V";
            // 
            // ___temp_toolStripStatusLabel
            // 
            this.___temp_toolStripStatusLabel.AutoSize = false;
            this.___temp_toolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.___temp_toolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.___temp_toolStripStatusLabel.Name = "___temp_toolStripStatusLabel";
            this.___temp_toolStripStatusLabel.Size = new System.Drawing.Size(75, 19);
            this.___temp_toolStripStatusLabel.Text = "temp: 35 ℃";
            // 
            // ___err_toolStripStatusLabel
            // 
            this.___err_toolStripStatusLabel.AutoSize = false;
            this.___err_toolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.___err_toolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.___err_toolStripStatusLabel.Name = "___err_toolStripStatusLabel";
            this.___err_toolStripStatusLabel.Size = new System.Drawing.Size(63, 19);
            this.___err_toolStripStatusLabel.Text = "err:     0";
            // 
            // ___report_toolStripStatusLabel
            // 
            this.___report_toolStripStatusLabel.AutoSize = false;
            this.___report_toolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.___report_toolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.___report_toolStripStatusLabel.Name = "___report_toolStripStatusLabel";
            this.___report_toolStripStatusLabel.Size = new System.Drawing.Size(79, 19);
            this.___report_toolStripStatusLabel.Text = "Reports:   0";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this._devicename__toolStripTextBox,
            this._set_toolStripButton,
            this._size_toolStripLabel});
            this.toolStrip2.Location = new System.Drawing.Point(0, 49);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(738, 25);
            this.toolStrip2.TabIndex = 6;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(40, 22);
            this.toolStripLabel1.Text = "name:";
            // 
            // _devicename__toolStripTextBox
            // 
            this._devicename__toolStripTextBox.Enabled = false;
            this._devicename__toolStripTextBox.MaxLength = 16;
            this._devicename__toolStripTextBox.Name = "_devicename__toolStripTextBox";
            this._devicename__toolStripTextBox.Size = new System.Drawing.Size(150, 25);
            this._devicename__toolStripTextBox.Text = "CustomPilot Micro";
            this._devicename__toolStripTextBox.TextChanged += new System.EventHandler(this._devicename__toolStripTextBox_TextChanged);
            // 
            // _set_toolStripButton
            // 
            this._set_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._set_toolStripButton.Enabled = false;
            this._set_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_set_toolStripButton.Image")));
            this._set_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._set_toolStripButton.Name = "_set_toolStripButton";
            this._set_toolStripButton.Size = new System.Drawing.Size(26, 22);
            this._set_toolStripButton.Text = "set";
            this._set_toolStripButton.Click += new System.EventHandler(this._set_toolStripButton_Click);
            this._set_toolStripButton.MouseLeave += new System.EventHandler(this._set_toolStripButton_MouseLeave);
            this._set_toolStripButton.MouseHover += new System.EventHandler(this._set_toolStripButton_MouseHover);
            this._set_toolStripButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this._set_toolStripButton_MouseMove);
            this._set_toolStripButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this._set_toolStripButton_MouseUp);
            // 
            // _size_toolStripLabel
            // 
            this._size_toolStripLabel.Name = "_size_toolStripLabel";
            this._size_toolStripLabel.Size = new System.Drawing.Size(80, 22);
            this._size_toolStripLabel.Text = "(00/32 bytes)";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.@__uC_TabFirmware);
            this.panel1.Controls.Add(this.@__tabControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 74);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(738, 522);
            this.panel1.TabIndex = 7;
            // 
            // __uC_TabFirmware
            // 
            this.@__uC_TabFirmware.COMPORT = null;
            this.@__uC_TabFirmware.DownFirmwarePath = "";
            this.@__uC_TabFirmware.Location = new System.Drawing.Point(0, 1);
            this.@__uC_TabFirmware.Name = "__uC_TabFirmware";
            this.@__uC_TabFirmware.pid = "";
            this.@__uC_TabFirmware.Size = new System.Drawing.Size(738, 539);
            this.@__uC_TabFirmware.TabIndex = 11;
            this.@__uC_TabFirmware.UploadFirmwarePath = "";
            this.@__uC_TabFirmware.Version = "";
            this.@__uC_TabFirmware.OnFirmwareDownloadComplete += new System.EventHandler(this.@__uC_TabFirmware_OnFirmwareDownloadComplete);
            this.@__uC_TabFirmware.On_BootloaderDownloadMode += new System.EventHandler(this.@__uC_TabFirmware_On_BootloaderMode);
            this.@__uC_TabFirmware.On_BootloaderUploadMode += new System.EventHandler(this.@__uC_TabFirmware_On_BootloaderUploadMode);
            // 
            // __tabControl
            // 
            this.@__tabControl.Controls.Add(this.@__mount_tabPage);
            this.@__tabControl.Controls.Add(this.@__radio_tabPage);
            this.@__tabControl.Controls.Add(this.@__mode_tabPage);
            this.@__tabControl.Controls.Add(this._output_tabPage);
            this.@__tabControl.Controls.Add(this.@__sensors_tabPage);
            this.@__tabControl.Controls.Add(this.@__reports_tabPage);
            this.@__tabControl.Controls.Add(this.DEBUG);
            this.@__tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.@__tabControl.Location = new System.Drawing.Point(0, 0);
            this.@__tabControl.Name = "__tabControl";
            this.@__tabControl.SelectedIndex = 0;
            this.@__tabControl.Size = new System.Drawing.Size(738, 522);
            this.@__tabControl.TabIndex = 4;
            this.@__tabControl.SelectedIndexChanged += new System.EventHandler(this.@__tabControl_SelectedIndexChanged);
            // 
            // __mount_tabPage
            // 
            this.@__mount_tabPage.Controls.Add(this.@__uC_Mount);
            this.@__mount_tabPage.Location = new System.Drawing.Point(4, 22);
            this.@__mount_tabPage.Name = "__mount_tabPage";
            this.@__mount_tabPage.Size = new System.Drawing.Size(730, 496);
            this.@__mount_tabPage.TabIndex = 7;
            this.@__mount_tabPage.Text = "Mount";
            this.@__mount_tabPage.UseVisualStyleBackColor = true;
            // 
            // __uC_Mount
            // 
            this.@__uC_Mount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.@__uC_Mount.Location = new System.Drawing.Point(0, 0);
            this.@__uC_Mount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.@__uC_Mount.Name = "__uC_Mount";
            this.@__uC_Mount.Size = new System.Drawing.Size(730, 496);
            this.@__uC_Mount.TabIndex = 0;
            this.@__uC_Mount.OnSettingChanged += new System.EventHandler(this.@__uC_Mount_OnSettingChanged);
            // 
            // __radio_tabPage
            // 
            this.@__radio_tabPage.Controls.Add(this._uC_RadioTab);
            this.@__radio_tabPage.Location = new System.Drawing.Point(4, 22);
            this.@__radio_tabPage.Name = "__radio_tabPage";
            this.@__radio_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.@__radio_tabPage.Size = new System.Drawing.Size(730, 496);
            this.@__radio_tabPage.TabIndex = 0;
            this.@__radio_tabPage.Text = "Radio";
            this.@__radio_tabPage.UseVisualStyleBackColor = true;
            // 
            // _uC_RadioTab
            // 
            this._uC_RadioTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this._uC_RadioTab.Location = new System.Drawing.Point(3, 3);
            this._uC_RadioTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._uC_RadioTab.Name = "_uC_RadioTab";
            this._uC_RadioTab.Size = new System.Drawing.Size(724, 490);
            this._uC_RadioTab.TabIndex = 0;
            this._uC_RadioTab.Protocol_Selected += new System.EventHandler(this.@__uC_RadioTab_Protocol_Selected);
            this._uC_RadioTab.Channel_Selected += new System.EventHandler(this.@__uC_RadioTab_Channel_Selected);
            this._uC_RadioTab.Calibration_Changed += new System.EventHandler(this.@__uC_RadioTab_Calibration_Changed);
            // 
            // __mode_tabPage
            // 
            this.@__mode_tabPage.Controls.Add(this.@__uC_FlightModeWindow);
            this.@__mode_tabPage.Location = new System.Drawing.Point(4, 22);
            this.@__mode_tabPage.Name = "__mode_tabPage";
            this.@__mode_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.@__mode_tabPage.Size = new System.Drawing.Size(730, 496);
            this.@__mode_tabPage.TabIndex = 1;
            this.@__mode_tabPage.Text = "Flight Mode";
            this.@__mode_tabPage.UseVisualStyleBackColor = true;
            // 
            // __uC_FlightModeWindow
            // 
            this.@__uC_FlightModeWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.@__uC_FlightModeWindow.Location = new System.Drawing.Point(3, 3);
            this.@__uC_FlightModeWindow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.@__uC_FlightModeWindow.Name = "__uC_FlightModeWindow";
            this.@__uC_FlightModeWindow.Size = new System.Drawing.Size(724, 490);
            this.@__uC_FlightModeWindow.TabIndex = 0;
            this.@__uC_FlightModeWindow.On_FlightModeChanged += new System.EventHandler(this.@__uC_FlightModeWindow_On_FlightModeChanged);
            // 
            // _output_tabPage
            // 
            this._output_tabPage.Controls.Add(this._uC_ServoWindow);
            this._output_tabPage.Location = new System.Drawing.Point(4, 22);
            this._output_tabPage.Name = "_output_tabPage";
            this._output_tabPage.Size = new System.Drawing.Size(730, 496);
            this._output_tabPage.TabIndex = 2;
            this._output_tabPage.Text = "Output";
            this._output_tabPage.UseVisualStyleBackColor = true;
            // 
            // _uC_ServoWindow
            // 
            this._uC_ServoWindow.Location = new System.Drawing.Point(3, 3);
            this._uC_ServoWindow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._uC_ServoWindow.Name = "_uC_ServoWindow";
            this._uC_ServoWindow.Size = new System.Drawing.Size(763, 572);
            this._uC_ServoWindow.TabIndex = 1;
            this._uC_ServoWindow.OnServoSettingChanged += new System.EventHandler(this.@__uC_ServoWindow_OnServoSettingChanged);
            // 
            // __sensors_tabPage
            // 
            this.@__sensors_tabPage.Controls.Add(this.@__uc_HUD);
            this.@__sensors_tabPage.Location = new System.Drawing.Point(4, 22);
            this.@__sensors_tabPage.Name = "__sensors_tabPage";
            this.@__sensors_tabPage.Size = new System.Drawing.Size(730, 496);
            this.@__sensors_tabPage.TabIndex = 5;
            this.@__sensors_tabPage.Text = "Sensor";
            this.@__sensors_tabPage.UseVisualStyleBackColor = true;
            // 
            // __uc_HUD
            // 
            this.@__uc_HUD.CalibrationWarning = false;
            this.@__uc_HUD.Location = new System.Drawing.Point(0, 0);
            this.@__uc_HUD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.@__uc_HUD.Name = "__uc_HUD";
            this.@__uc_HUD.Size = new System.Drawing.Size(644, 463);
            this.@__uc_HUD.TabIndex = 0;
            // 
            // __reports_tabPage
            // 
            this.@__reports_tabPage.Controls.Add(this.@__uC_Reports);
            this.@__reports_tabPage.Location = new System.Drawing.Point(4, 22);
            this.@__reports_tabPage.Name = "__reports_tabPage";
            this.@__reports_tabPage.Size = new System.Drawing.Size(730, 496);
            this.@__reports_tabPage.TabIndex = 6;
            this.@__reports_tabPage.Text = "Reports";
            this.@__reports_tabPage.UseVisualStyleBackColor = true;
            // 
            // __uC_Reports
            // 
            this.@__uC_Reports.Location = new System.Drawing.Point(-4, 0);
            this.@__uC_Reports.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.@__uC_Reports.Name = "__uC_Reports";
            this.@__uC_Reports.Size = new System.Drawing.Size(1029, 910);
            this.@__uC_Reports.TabIndex = 0;
            this.@__uC_Reports.OnResetReport += new System.EventHandler(this.@__uC_Reports_OnResetReport);
            // 
            // DEBUG
            // 
            this.DEBUG.Controls.Add(this.label1);
            this.DEBUG.Controls.Add(this.@__uC_TabDebug);
            this.DEBUG.Location = new System.Drawing.Point(4, 22);
            this.DEBUG.Name = "DEBUG";
            this.DEBUG.Size = new System.Drawing.Size(730, 496);
            this.DEBUG.TabIndex = 4;
            this.DEBUG.Text = "DEBUG";
            this.DEBUG.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // __uC_TabDebug
            // 
            this.@__uC_TabDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.@__uC_TabDebug.Location = new System.Drawing.Point(0, 0);
            this.@__uC_TabDebug.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.@__uC_TabDebug.Name = "__uC_TabDebug";
            this.@__uC_TabDebug.Size = new System.Drawing.Size(730, 496);
            this.@__uC_TabDebug.TabIndex = 0;
            // 
            // __firmware2
            // 
            this.@__firmware2.Name = "__firmware2";
            this.@__firmware2.Size = new System.Drawing.Size(181, 22);
            this.@__firmware2.Text = "Firmware";
            this.@__firmware2.Click += new System.EventHandler(this.@__firmware2_Click);
            // 
            // __pCManager
            // 
            this.@__pCManager.Name = "__pCManager";
            this.@__pCManager.Size = new System.Drawing.Size(181, 22);
            this.@__pCManager.Text = "PC Manager";
            this.@__pCManager.Click += new System.EventHandler(this.@__pCManager_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 620);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Custompilot Software Micro PC Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.@__tabControl.ResumeLayout(false);
            this.@__mount_tabPage.ResumeLayout(false);
            this.@__radio_tabPage.ResumeLayout(false);
            this.@__mode_tabPage.ResumeLayout(false);
            this._output_tabPage.ResumeLayout(false);
            this.@__sensors_tabPage.ResumeLayout(false);
            this.@__reports_tabPage.ResumeLayout(false);
            this.DEBUG.ResumeLayout(false);
            this.DEBUG.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem __openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem __saveOToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem __exitXToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox __com_toolStripComboBox;
        private System.Windows.Forms.ToolStripButton __connect_toolStripButton;
        private System.Windows.Forms.ToolStripLabel __firmver_toolStripLabel;
        
        private control.UC_ChannelMonitor[]         __uc_channels = new control.UC_ChannelMonitor[16];
        private System.Windows.Forms.Label[]        __ch_labels = new System.Windows.Forms.Label[16];
        private System.Windows.Forms.ComboBox[]     __ch_combos = new System.Windows.Forms.ComboBox[16];
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ___looptime_toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem __settingSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem factoryreset_ToolStripMenuItem;
        private System.Windows.Forms.Timer __timer_serial;
        private System.Windows.Forms.ToolStripStatusLabel __ypr_toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem imutoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem __IMUCalibrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel ___vcc_toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel ___temp_toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel ___err_toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel ___report_toolStripStatusLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripStatusLabel ___gforce_toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem __helpHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem __aboutAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem __onlineSupportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripButton __refresh_toolStripButton;
        private System.Windows.Forms.ToolStripMenuItem __supportToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox _languages_toolStripComboBox;
        private System.Windows.Forms.ToolStripMenuItem __userLanguageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem __firmware1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem __productsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem __installUSBDriverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem __manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem __tESTTToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl __tabControl;
        private System.Windows.Forms.TabPage __mount_tabPage;
        private control.UC_Mount __uC_Mount;
        private System.Windows.Forms.TabPage __radio_tabPage;
        private control.UC_TabRadio _uC_RadioTab;
        private System.Windows.Forms.TabPage __mode_tabPage;
        private control.UC_TabFlightMode __uC_FlightModeWindow;
        private System.Windows.Forms.TabPage _output_tabPage;
        private control.UC_TabServo _uC_ServoWindow;
        private System.Windows.Forms.TabPage __sensors_tabPage;
        private control.UC_HUD __uc_HUD;
        private System.Windows.Forms.TabPage __reports_tabPage;
        private control.UC_Reports __uC_Reports;
        private System.Windows.Forms.TabPage DEBUG;
        private System.Windows.Forms.Label label1;
        private control.UC_TabDebug __uC_TabDebug;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox _devicename__toolStripTextBox;
        private System.Windows.Forms.ToolStripButton _set_toolStripButton;
        private System.Windows.Forms.ToolStripLabel _size_toolStripLabel;
        private control.UC_TabFirmware __uC_TabFirmware;
        private System.Windows.Forms.ToolStripMenuItem __firmware2;
        private System.Windows.Forms.ToolStripMenuItem __pCManager;
    }
}

