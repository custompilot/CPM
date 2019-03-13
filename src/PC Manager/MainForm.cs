using CustomPilot.control;
using CustomPilot.core;
using CustomPilot.core.lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using CustomPilot.Language;
using System.Diagnostics;
using System.Security.Principal;

namespace CustomPilot
{
    public partial class MainForm : Form
    {
        Communication _com = new Communication();

        private FileIO  _file = new FileIO();
        private bool    _testmode, _islockname = false;

        public MainForm()
        {
            InitializeComponent();
            loadProperties();
        }        
        
        void OnCOMRefresh(object sender, EventArgs e )
        {
            try  
            {
                if (__uC_TabFirmware.IsBootloadMode)
                    return;
              
                    this.BeginInvoke(new Action(() =>
                    {
                        if (COMPortInfo.GetCOMPortsInfo().Count <= 0)
                        {
                            __com_toolStripComboBox.Items.Clear();
                            __com_toolStripComboBox.Items.Add("NO Device");
                            __com_toolStripComboBox.SelectedIndex = 0;
                            __connect_toolStripButton.Enabled = false;
                            __refresh_toolStripButton.Enabled = true;
                        }
                        else
                        {
                            __com_toolStripComboBox.Enabled = true;
                            __refresh_toolStripButton.Enabled = true;
                            // com 리스트 업데이트
                            __com_toolStripComboBox.Items.Clear();

                            foreach (COMPortInfo com in COMPortInfo.GetCOMPortsInfo())
                                __com_toolStripComboBox.Items.Add(com.Description);

                            for (int i = 0; i < __com_toolStripComboBox.Items.Count; i++)
                            {
                                if (__com_toolStripComboBox.Items[i].ToString() == Properties.Settings.Default.LASTCOMDEVICE)
                                {
                                    __com_toolStripComboBox.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                    }));
            }catch
            {

            }
        }
        
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == UsbNotification.WmDevicechange)
            {
                switch ((int)m.WParam)
                {
                    case UsbNotification.DbtDeviceremovecomplete:
                        refresh_com();
                        COMPortInfo.Refresh_Devices();
                        break;
                    case UsbNotification.DbtDevicearrival:
                        refresh_com();
                        COMPortInfo.Refresh_Devices();
                        break;
                }
            }
            base.WndProc(ref m);
        }
        
        void refresh_com()
        {
            __refresh_toolStripButton.Enabled = false;
            __connect_toolStripButton.Enabled = false;
            __com_toolStripComboBox.Enabled = false;
            __com_toolStripComboBox.Items.Clear();
            __com_toolStripComboBox.Items.Add("  Searching......");
            __com_toolStripComboBox.SelectedIndex = 0;
        }

        void loadProperties()
        {
            __uC_TabFirmware.DownFirmwarePath = Properties.Settings.Default.FirmwareDownloadPath;
            __uC_TabFirmware.UploadFirmwarePath = Properties.Settings.Default.FirmwareUploadPath;
            Communication.Initializecode = UInt64.Parse(Properties.Settings.Default.INITIALIZE_CODE);
        }
        
        private void __com_toolStripComboBox_DropDown(object sender, EventArgs e)
        {
        }

        private void __connect_toolStripButton_Click(object sender, EventArgs e)
        {
            int i = __com_toolStripComboBox.SelectedIndex;
            if (_com.IsOpen)
            {
                _com.SerialStop();
                __connect_toolStripButton.Enabled = false;
                __com_toolStripComboBox.Enabled = false;
            }
            else if (i >= 0)
            {
                _com.SerialConnect(i);
                _com.SerialSend(ECMD.VERSION);
                __com_toolStripComboBox.Enabled = true;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _com.SerialStop();
            Properties.Settings.Default.FirmwareDownloadPath = __uC_TabFirmware.DownFirmwarePath;
            Properties.Settings.Default.FirmwareUploadPath = __uC_TabFirmware.UploadFirmwarePath;
            Properties.Settings.Default.Save();
        }

        DateTime _preTime, _preTime_1s;
        bool _isCalibrationWarning = false;
        bool _isCalibrationWarning_flashing = false;
        int _chktime = 999999999;

        private void __timer_serial_Tick(object sender, EventArgs e)
        {
            if (_com.IsOpen)
            {
                _com.Do_comm();

                List<Serial.s_comstack> packets = _com.Recv();
                if (packets != null)
                    foreach (Serial.s_comstack packet in packets)
                    {
                        switch (packet.cmd)
                        {
                            case ECMD.VERSION:
                                string version = string.Format("{0, 1:D1}.{1, 2:D2}.{2, 3:D3}", packet.data[0], packet.data[1], packet.data[2]);
                                __firmver_toolStripLabel.Text = "Firmware Ver: " + version;
                                __uC_TabFirmware.Version = version;
                                _com.SerialSend(ECMD.EEPROM_RAW);
                                _uC_RadioTab.setRadioSet(packet.data[1]);
                                break;
                            case ECMD.EEPROM_RAW:
                                _islockname = true;
                                Communication.EEPROM.decode(packet.data);
                                _uC_RadioTab.Decode_EEPROM();
                                _uC_ServoWindow.Decode_EEPROM();
                                __uC_FlightModeWindow.Decode_EEPROM();
                                __uC_TabFirmware.pid = Communication.EEPROM.plane.license.ToString();
                                _devicename__toolStripTextBox.Text = Encoding.Unicode.GetString(Communication.EEPROM.plane.name64).Trim();
                                __uC_Mount.Decode_EEPROM();
                                
                                if (Communication.EEPROM.mpu.calibration.accs[2] == 0)
                                {
                                    __uc_HUD.CalibrationWarning = true;
                                    _isCalibrationWarning = true;
                                }
                                else
                                {
                                    __uc_HUD.CalibrationWarning = false;
                                }

                                _islockname = false;

                                break;

                            case ECMD.RADIO_RAW:
                                _uC_RadioTab.Decode_radio(packet.data);
                                _uC_RadioTab.radio_hz = BitConverter.ToInt16(packet.data, 64);
                                _uC_RadioTab.radio_fhz = BitConverter.ToInt16(packet.data, 64 + 2);

                                if (packet.data[64 + 4] != 0)
                                {
                                    _uC_RadioTab.IsFailsafe = true;
                                }
                                else
                                {
                                    _uC_RadioTab.IsFailsafe = false;
                                }                       
                                
                                if(packet.data[64 + 5] != 0)
                                {
                                    _uC_RadioTab.IsNosignal = true;
                                    _uC_ServoWindow.IsFailsafe = true;
                                }else
                                {
                                    _uC_RadioTab.IsNosignal = false;
                                    _uC_ServoWindow.IsFailsafe = false;
                                }

                                break;

                            case ECMD.TMODE:
                                __uC_FlightModeWindow.Decode_raw(packet.data);
                                break;

                            case ECMD.LOOPTIME:
                                // parse looptime
                                ___looptime_toolStripStatusLabel.Text = String.Format("Looptime: {0, 4:D3}", BitConverter.ToInt16(packet.data, 0));
                                
                                
                                if (_isCalibrationWarning && _isCalibrationWarning_flashing)
                                {
                                    __ypr_toolStripStatusLabel.Text = "Calibration Warning!!!";
                                    _isCalibrationWarning_flashing = false;
                                    __ypr_toolStripStatusLabel.BackColor = Color.Red;
                                }
                                else
                                {
                                    __ypr_toolStripStatusLabel.Text = String.Format("ypr:{0, 6:F1}{1, 6:F1}{2, 6:F1}", BitConverter.ToSingle(packet.data, 2), BitConverter.ToSingle(packet.data, 6), BitConverter.ToSingle(packet.data, 10));
                                    __ypr_toolStripStatusLabel.BackColor = this.BackColor;
                                    _isCalibrationWarning_flashing = true;
                                }
                                
                                if (packet.data.Length > 14)
                                {
                                    double voltage = ((float)(UInt16)packet.data[28]) / 10.0;
                                    if (voltage < 4.5)
                                        ___vcc_toolStripStatusLabel.BackColor = Color.Red;
                                    else
                                        ___vcc_toolStripStatusLabel.BackColor = this.BackColor;
                                    ___vcc_toolStripStatusLabel.Text = String.Format("VCC: {0, 3:F1}", voltage);

                                    UInt16 temp = ((UInt16)packet.data[29]);
                                    ___temp_toolStripStatusLabel.Text = String.Format("temp: {0, 2:D2} ℃", temp);
                                    if(temp > 70)
                                        ___temp_toolStripStatusLabel.BackColor = Color.Orange;
                                    else if(temp > 85)
                                        ___temp_toolStripStatusLabel.BackColor = Color.Red;
                                    else
                                        ___temp_toolStripStatusLabel.BackColor = this.BackColor;

                                    UInt16 error_count = BitConverter.ToUInt16(packet.data, 26);
                                    if (error_count > 0)
                                        ___err_toolStripStatusLabel.BackColor = Color.Red;
                                    else
                                        ___err_toolStripStatusLabel.BackColor = this.BackColor;

                                    ___err_toolStripStatusLabel.Text = String.Format("err: {0, 5:D1}", error_count);
                                                                        
                                    ushort wdt = (ushort)packet.data[30];
                                    ushort reports = (ushort)packet.data[31];

                                    if (wdt > 0)
                                        ___report_toolStripStatusLabel.BackColor = Color.Red;
                                    else if (reports > 0)
                                        ___report_toolStripStatusLabel.BackColor = Color.Orange;
                                    else
                                        ___report_toolStripStatusLabel.BackColor = this.BackColor;

                                    ___report_toolStripStatusLabel.Text = String.Format("Reports: {0, 5:D1}", reports + wdt);

                                    if(packet.data.Length > 30)
                                        ___gforce_toolStripStatusLabel.Text = String.Format("G:{0, 6:F1}{1, 6:F1}{2, 6:F1}", BitConverter.ToSingle(packet.data, 14), BitConverter.ToSingle(packet.data, 18), BitConverter.ToSingle(packet.data, 22));
                                }

                                __uc_HUD.Roll = 360 - (BitConverter.ToSingle(packet.data, 2) - 180);
                                __uc_HUD.Pitch = BitConverter.ToSingle(packet.data, 6) - 180;
                                __uc_HUD.Heading = BitConverter.ToSingle(packet.data, 10) - 180;
                                __uc_HUD.Draw();
                                break;

                            case ECMD.SERVO_RAW:
                                _uC_ServoWindow.Decode_Servos(packet.data);
                                if (packet.data[24] != 0)
                                    _uC_ServoWindow.IsFailsafe = true;
                                else
                                    _uC_ServoWindow.IsFailsafe = false;
                                break;

                            case ECMD.ERROR:
                                Console.WriteLine("Error packet received.");
                                break;

                            case ECMD.ROM_RAW:
                                __uC_Reports.DecodeData(packet.data);
                                break;
                        }
                    }

                if (__connect_toolStripButton.Text ==  CLanguages.GetTranslate("MENU_CONNECT"))
                {
                    // com 연결 됨
                    __refresh_toolStripButton.Enabled = false;
                    __connect_toolStripButton.Text =  CLanguages.GetTranslate("MENU_DISCONNECT");
                    __tabControl.Enabled = true;
                    __tabControl.Visible = true;
                    __uC_TabFirmware.Visible = false;
                    __uC_TabFirmware.IsConnected = true;
                    __com_toolStripComboBox.Enabled = false;
                    Properties.Settings.Default.LASTCOMDEVICE = __com_toolStripComboBox.Text;
                    Properties.Settings.Default.Save();
                    __settingSToolStripMenuItem.Enabled = true;
                    __openToolStripMenuItem.Enabled = true;
                    __saveOToolStripMenuItem.Enabled = true;
                    _devicename__toolStripTextBox.Enabled = true;

                    //tabpage_enabled(true);
                }
                else
                {
                    // 2. 현재 탭 정보 요구 0.2초 마다 버젼 정보를 받아온 경우만,,,
                    TimeSpan span = DateTime.Now - _preTime;
                    if (span.TotalMilliseconds >= _chktime)
                    {
                        //return;
                        _preTime = DateTime.Now;
                        // 현재탭 확인
                        if (__tabControl.SelectedTab.Text == CLanguages.GetTranslate("TAB_RADIO"))
                        {
                            // Radio calibration
                            _com.SerialSend(ECMD.RADIO_RAW);
                        }
                        else if (__tabControl.SelectedTab.Text == CLanguages.GetTranslate("TAB_OUTPUT"))
                        {
                            _com.SerialSend(ECMD.SERVO_RAW);
                        }
                        else if (__tabControl.SelectedTab.Text == CLanguages.GetTranslate("TAB_MODE"))
                        {
                            _com.SerialSend(ECMD.TMODE);
                        }
                    }
                    span = DateTime.Now - _preTime_1s;
                    if (span.TotalMilliseconds >= 200)
                    {
                        if (Communication.EEPROM.plane.initialized == Communication.Initializecode)
                        {
                            _preTime_1s = DateTime.Now;
                            _com.SerialSend(ECMD.LOOPTIME);
                            _chktime = 200;
                        }
                        else
                        {
                            // 초기화 안됨
                        }
                    }
                    
                }
            }
            else
            {
                if (__connect_toolStripButton.Text ==  CLanguages.GetTranslate("MENU_DISCONNECT"))
                {
                    // com 끊김
                    __refresh_toolStripButton.Enabled = true;
                    __connect_toolStripButton.Text =  CLanguages.GetTranslate("MENU_CONNECT");
                    __connect_toolStripButton.Enabled = true;
                    __tabControl.SelectedTab = __tabControl.TabPages[0];
                    __com_toolStripComboBox.Enabled = true;
                    __firmver_toolStripLabel.Text = "Firmware Ver. ";
                    __uC_TabFirmware.IsConnected = false;
                    __uC_TabFirmware.Visible = true;
                    __settingSToolStripMenuItem.Enabled = false;
                    _devicename__toolStripTextBox.Enabled = false;

                    __tabControl.Enabled = false;
                    __tabControl.Visible = false;

                    __openToolStripMenuItem.Enabled = false;
                    __saveOToolStripMenuItem.Enabled = false;
                }
            }

            // imu 캘리브레이션 체크
            TimeSpan sp = DateTime.Now - _imuCalc;

            if(sp.TotalSeconds > 0 && sp.TotalSeconds < 2)
            {
                _imuCalc = DateTime.Now.AddMinutes(-1);
                _com.SerialSend(ECMD.EEPROM_RAW);
            }
        }

        private void __connect_toolStripButton_MouseHover(object sender, EventArgs e)
        {
            __connect_toolStripButton.BackColor = SystemColors.ActiveBorder;
        }

        private void __reset_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show( CLanguages.GetTranslate("MESSAGE_WARNING_REPORT_RESET").Replace("{0}", Environment.NewLine),  CLanguages.GetTranslate("MESSAGE_ALERT"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Communication.EEPROM.reset();
                byte[] buf = Communication.EEPROM.encode();
                _com.SerialSend(ECMD.EEPROM_SET, buf);
                _com.SerialSend(ECMD.ROM_RESET);
                _com.SerialSend(ECMD.EEPROM_RAW);
            }
        }

        private void __uC_RadioTab_Protocol_Selected(object sender, EventArgs e)
        {
            byte[] buf = Communication.EEPROM.encode();
            _com.SerialSend(ECMD.EEPROM_SET, buf);

            _com.SerialSend(ECMD.RADIO_PROTOCOL_SET, buf);
        }

        private void __uC_RadioTab_Channel_Selected(object sender, EventArgs e)
        {
            //byte[] buf = new byte[10];
            //Buffer.BlockCopy(Communication.EEPROM.radio.ich, 0, buf, 0, 10);
            //_com.SerialSend(ECMD.EEPROM_RADIO_ICH, buf);
            byte[] buf = Communication.EEPROM.encode();
            _com.SerialSend(ECMD.EEPROM_SET, buf);

        }

        private void __uC_RadioTab_Calibration_Changed(object sender, EventArgs e)
        {
            /*
            byte[] buf = new byte[7];

            buf[0] = BitConverter.GetBytes(Communication.EEPROM.radio.trim.offset)[0];
            buf[1] = BitConverter.GetBytes(Communication.EEPROM.radio.trim.offset)[1];

            buf[2] = BitConverter.GetBytes(Communication.EEPROM.radio.trim.min)[0];
            buf[3] = BitConverter.GetBytes(Communication.EEPROM.radio.trim.min)[1];

            buf[4] = BitConverter.GetBytes(Communication.EEPROM.radio.trim.max)[0];
            buf[5] = BitConverter.GetBytes(Communication.EEPROM.radio.trim.max)[1];

            buf[6] = BitConverter.GetBytes(Communication.EEPROM.radio.trim.direction)[0];
            */

            byte[] buf = Communication.EEPROM.encode();
            _com.SerialSend(ECMD.EEPROM_SET, buf);
        }

        DateTime _imuCalc = DateTime.Now.AddMinutes(-1);
        private void __gyroCalibrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _com.SerialSend(ECMD.IMU_CAL);
            _isCalibrationWarning = false;
            __uc_HUD.CalibrationWarning = false;
            _imuCalc = DateTime.Now;
        }        

        private void __uC_ServoWindow_OnServoSettingChanged(object sender, EventArgs e)
        {
            /*
            // och: 12 + trims: 12 * 7 = 84
            byte[] buf = new byte[12 + 84];

            int o = 0;
            for (int i = 0; i < 12; i++)
                buf[o++] = (byte)Communication.EEPROM.servo.och[i];

            for(int i = 0; i < 12; i++)
            {
                buf[o++] = BitConverter.GetBytes(Communication.EEPROM.servo.trim.channels[i].offset)[0];
                buf[o++] = BitConverter.GetBytes(Communication.EEPROM.servo.trim.channels[i].offset)[1];

                buf[o++] = BitConverter.GetBytes(Communication.EEPROM.servo.trim.channels[i].min)[0];
                buf[o++] = BitConverter.GetBytes(Communication.EEPROM.servo.trim.channels[i].min)[1];

                buf[o++] = BitConverter.GetBytes(Communication.EEPROM.servo.trim.channels[i].max)[0];
                buf[o++] = BitConverter.GetBytes(Communication.EEPROM.servo.trim.channels[i].max)[1];

                buf[o++] = (byte)Communication.EEPROM.servo.trim.channels[i].direction;
            }

            //_com.SerialSend(ECMD.SERVO_SET, buf);//*/

            byte[] buf = Communication.EEPROM.encode();
            _com.SerialSend(ECMD.EEPROM_SET, buf);
        }

        private void __imu_reset_Click(object sender, EventArgs e)
        {
            _com.SerialSend(ECMD.IMU_RESET);
        }

        private void __uC_FlightModeWindow_On_FlightModeChanged(object sender, EventArgs e)
        {
            byte[] buf = Communication.EEPROM.encode();
            _com.SerialSend(ECMD.EEPROM_SET, buf);
        }
        
        private void tabpage_enabled(bool enabled)
        {
            for(int i = 1; i < __tabControl.TabPages.Count; i++)
            {
                ((Control)__tabControl.TabPages[i]).Enabled = enabled;
            }
        }

        private void __uC_TabFirmware_On_DeviceName(object sender, EventArgs e)
        {
            
        }

        private void __com_toolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (__com_toolStripComboBox.SelectedIndex >= 0)
            {
                __uC_TabFirmware.IsSelectCOM = true;
                if (__com_toolStripComboBox.Text.IndexOf("COM") > 0)
                    __connect_toolStripButton.Enabled = true;
                else
                    __connect_toolStripButton.Enabled = false;
            }
        }

        private void firm_dowing()
        {
            __com_toolStripComboBox.Enabled = false;
            __connect_toolStripButton.Enabled = false;
        }

        private void __uC_TabFirmware_On_BootloaderMode(object sender, EventArgs e)
        {
            firm_dowing();
            _com.SerialStop();
            if (__com_toolStripComboBox.SelectedIndex < 0)
                MessageBox.Show( CLanguages.GetTranslate("MESSAGE_COM_SELECT"),  CLanguages.GetTranslate("MESSAGE_ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try {
                    __uC_TabFirmware.COMPORT = COMPortInfo.GetCOMPortsInfo()[__com_toolStripComboBox.SelectedIndex].Name;
                    __uC_TabFirmware.DownloadFirmware();
                }
                catch
                {
                    Console.WriteLine("firmware down 올바른 com 포트가 없습니다.");
                }
            }
        }

        private void __uC_TabFirmware_OnFirmwareDownloadComplete(object sender, EventArgs e)
        {
            refresh_com();
            COMPortInfo.Refresh_Devices();
        }

        private void __uC_TabFirmware_On_BootloaderUploadMode(object sender, EventArgs e)
        {
            firm_dowing();
            _com.SerialStop();
            if (__com_toolStripComboBox.SelectedIndex < 0)
                MessageBox.Show( CLanguages.GetTranslate("MESSAGE_COM_SELECT"),  CLanguages.GetTranslate("MESSAGE_ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try
                {
                    __uC_TabFirmware.COMPORT = COMPortInfo.GetCOMPortsInfo()[__com_toolStripComboBox.SelectedIndex].Name;
                    __uC_TabFirmware.UploadFirmware();
                }catch
                {
                    MessageBox.Show("Please try again in a few minutes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void __tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(__tabControl.TabPages[__tabControl.SelectedIndex].Text ==  CLanguages.GetTranslate("PAGE_REPORTS_REPORTS"))
            {
                _com.SerialSend(ECMD.ROM_RAW);
            }
        }

        private void __clearReportsCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show( CLanguages.GetTranslate("MESSAGE_WARNING_REPORT_RESET").Replace("{0}", Environment.NewLine),  CLanguages.GetTranslate("MESSAGE_ALERT"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _com.SerialSend(ECMD.ROM_RESET);
                _com.SerialSend(ECMD.ROM_RAW);
            }
        }

        private void __uC_TabDebug_On_WDTtest(object sender, EventArgs e)
        {
            _com.SerialSend(ECMD.DEBUG_WDT);
        }

        private void __connect_toolStripButton_MouseLeave(object sender, EventArgs e)
        {
            __connect_toolStripButton.BackColor = SystemColors.ButtonFace;
        }

        private void __uC_Mount_OnSettingChanged(object sender, EventArgs e)
        {
            byte[] buf = Communication.EEPROM.encode();
            _com.SerialSend(ECMD.EEPROM_SET, buf);
        }

        private void ___gforce_toolStripStatusLabel_Click(object sender, EventArgs e)
        {

        }

        private void saveOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // eeprom save
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CPM files | *.cpm";
            sfd.DefaultExt = "cpm";
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                _file.SaveEEPROMDATA(sfd.FileName);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // eeprom load
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CPM files | *.cpm";
            ofd.DefaultExt = "cpm";
            if(_com.IsOpen)
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    if (MessageBox.Show( CLanguages.GetTranslate(".MESSAGE_OVERWRITE_CPM"), "Custompilot", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        Communication.EEPROM.decode(_file.LoadEEPROMDATA(ofd.FileName));
                        _com.SerialSend(ECMD.EEPROM_SET, Communication.EEPROM.encode());
                    }
                }
        }

        private void __onlineSupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string target = "http://custompilot.net";
            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch(Win32Exception err)
            {
                if (err.ErrorCode == 2147467259)
                    MessageBox.Show(err.Message);
            }
            catch(Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        static About __about = new About();
        private void __aboutAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            __about.ShowDialog();
        }

        private bool _skip_language = true;
        private void _languages_toolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_skip_language)
            {
                CLanguages.SetLanguage(_languages_toolStripComboBox.SelectedIndex);

                set_language();
                Properties.Settings.Default.CURRENTLANGUAGE = _languages_toolStripComboBox.SelectedIndex;
                Properties.Settings.Default.Save();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // load languages
            for (int i = 0; i < CLanguages.Languages.Count; i++)
            {
                _languages_toolStripComboBox.Items.Add(CLanguages.Languages[i].Name);
            }


            _languages_toolStripComboBox.SelectedIndex = 0;
            __tabControl.Enabled = false;
            __tabControl.Visible = false;

            refresh_com();
            COMPortInfo.Refresh_Devices();

            // debug 탭 설정
            
            if (Properties.Settings.Default.DEBUG == false)
                __tabControl.TabPages.RemoveAt(6);

            COMPortInfo.OnComRefreshed += OnCOMRefresh;
            CLanguages.SetLanguage(Properties.Settings.Default.CURRENTLANGUAGE);

            set_language();
            _languages_toolStripComboBox.SelectedIndex = Properties.Settings.Default.CURRENTLANGUAGE;
            _skip_language = false;
        }

        private void __exitXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void __installUSBDriverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 관리자 권한 아님 상승하기               
            
            ProcessStartInfo procInfo = new ProcessStartInfo();
            procInfo.UseShellExecute = false;
            procInfo.Arguments = "/c \"" + Application.StartupPath + @"\Driver\dpinst-amd64.exe""";
            procInfo.FileName = "cmd";
            procInfo.WorkingDirectory = Environment.CurrentDirectory;
            procInfo.Verb = "runas";
            procInfo.WindowStyle = ProcessWindowStyle.Hidden;
            procInfo.CreateNoWindow = true;
            Process.Start(procInfo);
            
            //process.WaitForExit();

        }

        private void __refresh_toolStripButton_Click(object sender, EventArgs e)
        {
            refresh_com();
            COMPortInfo.Refresh_Devices();
        }

        private void __connect_toolStripButton_MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripButton b = (ToolStripButton)sender;
            b.Select();
        }

        private void __refresh_toolStripButton_MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripButton b = (ToolStripButton)sender;
            b.Select();
        }

        private bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();

            if(null != identity)
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }

            return false;
        }

        private void __userLanguageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Application.StartupPath + "\\Language");
        }

        private void __manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", "https://docs.google.com/document/d/1eNxeVg-5XNHESJqNeFty4i7Eb2m8jMwpp5SNlR4x_BQ/edit");
        }

        private void __tESTTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_testmode == false)
            {
                __tabControl.Enabled = true;
                __tabControl.Visible = true;
                __uC_TabFirmware.Visible = false;
                tabpage_enabled(true);
                _testmode = true;
            }
            else
            {
                __tabControl.Enabled = false;
                __tabControl.Visible = false;
                __uC_TabFirmware.Visible = true;
                tabpage_enabled(false);
                _testmode = false;
            }
        }

        private void _devicename__toolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            byte[] devicename = System.Text.Encoding.Unicode.GetBytes(_devicename__toolStripTextBox.Text);

            _size_toolStripLabel.Text = String.Format("({0:00}/32 bytes)", devicename.Length);

            if (devicename.Length <= 32)
            {
                if(_islockname == false)
                    _set_toolStripButton.Enabled = true;
            }
            else
            {
                _set_toolStripButton.Enabled = false;
            }
        }

        private void _set_toolStripButton_Click(object sender, EventArgs e)
        {
            //char[] uchar = _devicename__toolStripTextBox.Text.ToCharArray();
            byte[] devicename = System.Text.Encoding.Unicode.GetBytes(_devicename__toolStripTextBox.Text.Trim());

            for (int i = 0; i < devicename.Length; i++)
                Communication.EEPROM.plane.name64[i] = devicename[i];

            for (int i = devicename.Length; i < 32; i += 2)
            {
                Communication.EEPROM.plane.name64[i] = System.Text.Encoding.Unicode.GetBytes(" ")[0];
                Communication.EEPROM.plane.name64[i + 1] = System.Text.Encoding.Unicode.GetBytes(" ")[1];
            }

            /*
            byte[] name_buf = Communication.EEPROM.plane.name64.Select(c => (byte)c).ToArray();
            if (name_buf.Length == 32)
                _com.SerialSend(ECMD.DEVICENAME_SET, name_buf);
            else
                MessageBox.Show("error::DEVICENAME_SET");
                */

            byte[] buf = Communication.EEPROM.encode();
            _com.SerialSend(ECMD.EEPROM_SET, buf);

            this.Select();
            _set_toolStripButton.BackColor = SystemColors.ButtonFace;
            //_set_toolStripButton.Enabled = false;
        }

        private void _set_toolStripButton_MouseHover(object sender, EventArgs e)
        {
            _set_toolStripButton.BackColor = SystemColors.ActiveBorder;
        }

        private void _set_toolStripButton_MouseMove(object sender, MouseEventArgs e)
        {
            _set_toolStripButton.BackColor = SystemColors.ActiveBorder;
            _set_toolStripButton.Select();
        }

        private void _set_toolStripButton_MouseLeave(object sender, EventArgs e)
        {
            _set_toolStripButton.BackColor = SystemColors.ButtonFace;
        }

        private void _set_toolStripButton_MouseUp(object sender, MouseEventArgs e)
        {
            _set_toolStripButton.BackColor = SystemColors.ActiveBorder;
        }

        private void __firmware1_Click(object sender, EventArgs e)
        {
            string target = "https://github.com/custompilot/CPM/tree/master/RADIO1";
            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch (Win32Exception err)
            {
                if (err.ErrorCode == 2147467259)
                    MessageBox.Show(err.Message);
            }
            catch (Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void __firmware2_Click(object sender, EventArgs e)
        {
            string target = "https://github.com/custompilot/CPM/tree/master/RADIO2";
            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch (Win32Exception err)
            {
                if (err.ErrorCode == 2147467259)
                    MessageBox.Show(err.Message);
            }
            catch (Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void __pCManager_Click(object sender, EventArgs e)
        {
            string target = "http://custompilot.co.kr/install/windows/";
            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch (Win32Exception err)
            {
                if (err.ErrorCode == 2147467259)
                    MessageBox.Show(err.Message);
            }
            catch (Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void __uC_Reports_OnResetReport(object sender, EventArgs e)
        {
            _com.SerialSend(ECMD.ROM_RESET);
            _com.SerialSend(ECMD.ROM_RAW);
        }

        private void set_language()
        {
            // main menu
            fileFToolStripMenuItem.Text =  CLanguages.GetTranslate("MENU_FILE");
            __openToolStripMenuItem.Text =  CLanguages.GetTranslate("MENU_OPEN");
            __saveOToolStripMenuItem.Text =  CLanguages.GetTranslate("MENU_SAVE");
            __exitXToolStripMenuItem.Text =  CLanguages.GetTranslate("MENU_EXIT");

            // setting menu
            __settingSToolStripMenuItem.Text =  CLanguages.GetTranslate("MENU_SETTING");
            imutoolStripMenuItem.Text =  CLanguages.GetTranslate("MENU_IMU");
            factoryreset_ToolStripMenuItem.Text =  CLanguages.GetTranslate("MENU_FACTORYRESET");
            __IMUCalibrationToolStripMenuItem.Text =  CLanguages.GetTranslate("MENU_IMU_CAL");
            
            // buttons
            __connect_toolStripButton.Text =  CLanguages.GetTranslate("MENU_CONNECT");
            __firmver_toolStripLabel.Text =  CLanguages.GetTranslate("MENU_FIRMWAREVER");

            // menu help
            __helpHToolStripMenuItem.Text =  CLanguages.GetTranslate("MENU_HELP");
            __aboutAToolStripMenuItem.Text =  CLanguages.GetTranslate("MENU_HELP_ABOUT");
            __onlineSupportToolStripMenuItem.Text =  CLanguages.GetTranslate("MENU_HELP_SUPPORT");
            __installUSBDriverToolStripMenuItem.Text =  CLanguages.GetTranslate("MENU_HELP_DRIVER");
            __tESTTToolStripMenuItem.Text = CLanguages.GetTranslate("MENU_HELP_TEST");

            // support
            __supportToolStripMenuItem.Text = CLanguages.GetTranslate("MENU_SUPPORT");
            __userLanguageToolStripMenuItem.Text = CLanguages.GetTranslate("MENU_USERLANGUAGE");
            __productsToolStripMenuItem.Text = CLanguages.GetTranslate("MENU_PRODUCTS");
            __manualToolStripMenuItem.Text = CLanguages.GetTranslate("MENU_MANUAL");
            __firmware1.Text = CLanguages.GetTranslate("MENU_SUPPORT_FIRMWARE1");
            __firmware2.Text = CLanguages.GetTranslate("MENU_SUPPORT_FIRMWARE2");
            __pCManager.Text = CLanguages.GetTranslate("MENU_SUPPORT_PCMANAGER");

            // tabs
            //__firmware_tabPage.Text =  CLanguages.GetTranslate("TAB_FIRMWARE;
            __radio_tabPage.Text =  CLanguages.GetTranslate("TAB_RADIO");
            __mode_tabPage.Text =  CLanguages.GetTranslate("TAB_MODE");
            _output_tabPage.Text =  CLanguages.GetTranslate("TAB_OUTPUT");
            __sensors_tabPage.Text =  CLanguages.GetTranslate("TAB_SENSOR");
            __reports_tabPage.Text =  CLanguages.GetTranslate("TAB_REPORT");
            __mount_tabPage.Text =  CLanguages.GetTranslate("TAB_BOARD");

            // firmware page set
            __uC_TabFirmware.set_language();

            // radio page set
            _uC_RadioTab.set_language();

            // mode page set
            __uC_FlightModeWindow.set_language();

            // output page set
            _uC_ServoWindow.set_language();

            // reports page set
            __uC_Reports.set_language();

            // mount page set
            __uC_Mount.set_language();
        }
    }
}