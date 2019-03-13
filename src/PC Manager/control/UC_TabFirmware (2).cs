using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomPilot.core.lib;
using System.IO;
using System.Resources;
using CustomPilot.Language;
using System.Threading;

namespace CustomPilot.control
{
    public partial class UC_TabFirmware : UserControl
    {
        private NAvrdudeRead _avrDown = new NAvrdudeRead();
        private NAvrdudeWrite _avrUp = new NAvrdudeWrite();

        private bool _isDownfirmware_selected = false;
        private bool _isComSelected = false;
        private bool _isUpfirmware_selected = false;

        private bool _isFirmwareDoing = false;
        public bool IsBootloadMode = false;

        public bool IsFirmwareDoing
        {
            get
            {
                return _isFirmwareDoing;
            }
        }
           

        public String Version
        {
            set
            {
                __version_label.Text = value;
            }

            get
            {
                return __version_label.Text;
            }
        }

        public bool IsSelectCOM
        {
            set
            {
                _isComSelected = true;

                checkDownloadButton();
                checkUpButton();
            }
        }

        public String pid
        {
            set
            {
                __pid_label.Text = value;
            }

            get
            {
                return __pid_label.Text;
            }
        }

        string _comPort;
        public string COMPORT
        {
            set
            {
                _comPort = value;
            }

            get
            {
                return _comPort;
            }
        }

        public string UploadFirmwarePath
        {
            set
            {
                __firmware_upload_textBox.Text = value;
            }

            get
            {
                return __firmware_upload_textBox.Text;
            }
        }

        public string DownFirmwarePath
        {
            set
            {
                __firmware_download_textBox.Text = value;
            }

            get
            {
                return __firmware_download_textBox.Text;
            }
        }

        public UC_TabFirmware()
        {
            InitializeComponent();

            _avrDown.OnFirmwareDownloadComplete += _avr_OnFirmwareDownloadComplete;
            _avrDown.OnStateChanged += _avr_OnDownStateChanged;
            _avrDown.OnConsoleReceived += _avr_OnConsoleReceived;
            _avrDown.OnError += _avrDown_OnError;

            _avrUp.OnFirmwareDownloadComplete += _avrUp_OnFirmwareUploadComplete;
            _avrUp.OnStateChanged += _avrUp_OnUpStateChanged;
            _avrUp.OnConsoleReceived += _avr_OnConsoleReceived;
            _avrUp.OnError += _avrUp_OnError;
        }

        private void _avrUp_OnError(object sender, EventArgs e)
        {
            this.Invoke(new Action(()=>
            {
                __upState_label.Text = "Error";
                checkDownloadButton();
                checkUpButton();

                MessageBox.Show(((EventArgs_StateChanged)e).message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (OnFirmwareDownloadComplete != null)
                    OnFirmwareDownloadComplete(this, e);

                IsBootloadMode = false;
            }));
            
        }

        private void _avrDown_OnError(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                __downState_label.Text = "Error";
                checkDownloadButton();
                checkUpButton();

                if (OnFirmwareDownloadComplete != null)
                    OnFirmwareDownloadComplete(this, e);

                MessageBox.Show(((EventArgs_StateChanged)e).message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IsBootloadMode = false;
            }));
        }

        private void _avrUp_OnUpStateChanged(object sender, EventArgs e)
        {
            EventArgs_StateChanged ea = (EventArgs_StateChanged)e;
            __upState_label.Invoke(new Action(() =>
            {
                __upState_label.Text = ea.State;
                __up_progressBar.Value = ea.percent;
                if (ea.message.Length > 0)
                    __console_textBox.AppendText("@event: " + ea.message + "\r\n");

            }));
        }

        private void _avrUp_OnFirmwareUploadComplete(object sender, EventArgs e)
        {
            __upState_label.BeginInvoke(new Action(() => {
                try
                {
                    __console_textBox.AppendText(_consoleBuf);
                    _firmware_upload_button.Enabled = true;
                    _consoleBuf = "";
                    _isFirmwareDoing = false;
                    IsBootloadMode = false;


                    if (OnFirmwareDownloadComplete != null)
                        OnFirmwareDownloadComplete(this, e);

                    // COMPortInfo.Refresh_Devices();

                    checkDownloadButton();
                    checkUpButton();
                }catch(Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }));
        }

        private String _consoleBuf;
        private void _avr_OnConsoleReceived(object sender, EventArgs e)
        {
            EventArgs_ConsoleRead ea = (EventArgs_ConsoleRead)e;

            _consoleBuf += ea.DataRead;
            if (_consoleBuf.Length >= 7 || ea.DataRead == "#")
            {
                __console_textBox.BeginInvoke(new Action(() =>
                {
                    __console_textBox.AppendText(_consoleBuf);
                    //__console_textBox.SelectionStart = __console_textBox.TextLength;
                    //__console_textBox.ScrollToCaret();
                    _consoleBuf = "";
                }));
            }
        }

        private void _avr_OnDownStateChanged(object sender, EventArgs e)
        {
            EventArgs_StateChanged ea = (EventArgs_StateChanged)e;
            __downState_label.Invoke(new Action(() =>
            {
                __downState_label.Text = ea.State;
                __down_progressBar.Value = ea.percent;
                if(ea.message.Length > 0)
                    __console_textBox.AppendText("@event: " + ea.message + "\r\n");
            }));
        }

        private void _avr_OnFirmwareDownloadComplete(object sender, EventArgs e)
        {
            string version = GetFirmwareVersion(__firmware_download_textBox.Text);

            if (version == "")
                version = "ERROR";

            __downState_label.BeginInvoke(new Action(() => {
                __firmdownload_file_version.Text = version;
                __console_textBox.AppendText(_consoleBuf);

                if (OnFirmwareDownloadComplete != null)
                    OnFirmwareDownloadComplete(this, e);

                _isFirmwareDoing = false;
                IsBootloadMode = false;

                _consoleBuf = "";

                checkDownloadButton();
                checkUpButton();
            }));
        }
        
        int _percent = 0;

        public int Percent
        {
            get
            {
                return _percent;
            }
        }

        private void __down_button_Click(object sender, EventArgs e)
        {
            if (__firmware_download_textBox.Text == "")
            {
                MessageBox.Show("Select filepath, First");
                return;
            }

            __console_textBox.Clear();

            if (On_BootloaderDownloadMode != null)
            {
                On_BootloaderDownloadMode(this, e);
            }
        }

        public void DownloadFirmware()
        {
            IsBootloadMode = true;
            _isFirmwareDoing = true;
            _avrDown.DownloadFirmware(_comPort, __firmware_download_textBox.Text);
            checkDownloadButton();
            checkUpButton();
        }

        public void UploadFirmware()
        {
            IsBootloadMode = true;
            _isFirmwareDoing = true;
            _avrUp.UploadFirmware(_comPort, __firmware_upload_textBox.Text);
            checkDownloadButton();
            checkUpButton();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Binary Files | *.bin";
            dlg.DefaultExt = "bin";

            dlg.CheckPathExists = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                __firmware_download_textBox.Text = dlg.FileName;
                _isDownfirmware_selected = true;
            }
            else
                _isDownfirmware_selected = false;
            
            checkDownloadButton();
        }

        private void __nameset_button_Click(object sender, EventArgs e)
        {
            if (On_DeviceName != null)
                On_DeviceName(this, e);

            //__nameset_button.Enabled = false;
        }

        /*
        public char[] DeviceName
        {
            get
            {
                return __mname_TextBox.Text.ToCharArray();
            }

            set
            {
                __mname_TextBox.Text = new string(value).Trim();
                __nameset_button.Enabled = false;
            }
        }
        */

        public event EventHandler On_DeviceName;
        public bool IsConnected
        {
            set
            {
                if(value)
                {
                    // connected
                    //__mname_TextBox.Enabled = true;
                }
                else
                {
                    // disconected
                    //__mname_TextBox.Enabled = false;
                    __pid_label.Text = __version_label.Text = __version_label.Text =  CLanguages.GetTranslate("PAGE_FIRM_DISCONNECTED");

                }
            }
        }

        private void checkDownloadButton()
        {
            if ((_avrDown.State == AvrdudeBase.ESTATE.WAIT || _avrDown.State == AvrdudeBase.ESTATE.COMPLETE) && (_avrUp.State == AvrdudeBase.ESTATE.WAIT || _avrUp.State == AvrdudeBase.ESTATE.COMPLETE))
            {
                if (_isDownfirmware_selected && _isComSelected)
                    _firmware_dowload_button.Enabled = true;
                else
                    _firmware_dowload_button.Enabled = false;
                _firmware_down_open_file_button.Enabled = true;
            }
            else
                allDisabled();
        }

        private void checkUpButton()
        {
            if ((_avrDown.State == AvrdudeBase.ESTATE.WAIT || _avrDown.State == AvrdudeBase.ESTATE.COMPLETE) && (_avrUp.State == AvrdudeBase.ESTATE.WAIT || _avrUp.State == AvrdudeBase.ESTATE.COMPLETE))
            {
                if (_isUpfirmware_selected && _isComSelected)
                    _firmware_upload_button.Enabled = true;
                else
                    _firmware_upload_button.Enabled = false;
                _firmware_up_open_file_button.Enabled = true;
            }
            else
                allDisabled();
        }

        private void __firmware_up_open_file_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Binary Files | *.bin";
            ofd.DefaultExt = "bin";
            string version = "";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                version = GetFirmwareVersion(ofd.FileName);
                if (version == "")
                {
                    _isUpfirmware_selected = false;
                    __firmupload_file_version.Text = "ERROR";
                    MessageBox.Show("Invalid file.", "Custom pilot", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else
                {
                    __firmware_upload_textBox.Text = ofd.FileName;
                    _isUpfirmware_selected = true;
                    __firmupload_file_version.Text = version;
                }

                // debug
                
                checkUpButton();
            }
        }

        private void allDisabled()
        {
            _firmware_down_open_file_button.Enabled = false;
            _firmware_up_open_file_button.Enabled = false;
            _firmware_upload_button.Enabled = false;
            _firmware_dowload_button.Enabled = false;
        }

        private void allEnabled()
        {
            _firmware_down_open_file_button.Enabled = true;
            _firmware_up_open_file_button.Enabled = true;
            _firmware_upload_button.Enabled = true;
            _firmware_dowload_button.Enabled = true;
        }

        private string GetFirmwareVersion(String pathname)
        {
            // 파일 버젼 찾기
            if (File.Exists(pathname) == false)
                return "";

            FileStream fs = new FileStream(@pathname, FileMode.Open, FileAccess.Read);

            int i = 0;
            string version = "";

            if (fs.Length < 40000)
            {
                while (i < fs.Length)
                {
                    char c = (char)fs.ReadByte();
                    i++;

                    if (c == 'V')
                    {
                        char[] chars = new char[3];
                        for (int j = 0; j < 3; j++)
                        {
                            chars[j] = (char)fs.ReadByte();
                            i++;
                        }

                        if (chars[0] == 'E' && chars[1] == 'R' && chars[2] == ':')
                        {
                            // version 위치 찾음
                            byte[] ver = new byte[3];
                            fs.Read(ver, 0, 3);
                            //version = System.Text.Encoding.Default.GetString(ver);
                            version = String.Format("{0}.{1, 2:D2}.{2, 3:D3}", ver[0], ver[1], ver[2]);
                            break;
                        }
                    }
                }
            }            
            fs.Close();
            return version;         
        }
        
        private void __mname_TextBox_TextChanged(object sender, EventArgs e)
        {
            //__nameset_button.Enabled = true;
        }

        public event EventHandler OnFirmwareDownloadComplete;
        

        private void __firmware_upload_button_Click(object sender, EventArgs e)
        {
            if (__firmware_upload_textBox.Text == "")
            {
                MessageBox.Show("Select filepath, First");
                return;
            }

            __console_textBox.Clear();
            _firmware_upload_button.Enabled = false;

            if (On_BootloaderUploadMode != null)
                On_BootloaderUploadMode(this, e);
        }

        public void set_language()
        {
            _information_groupBox.Text =  CLanguages.GetTranslate("PAGE_FIRM_INFORMATION");
            _id_label.Text =  CLanguages.GetTranslate("PAGE_FIRM_PRODUCTID");
            _firmware_label.Text =  CLanguages.GetTranslate("PAGE_FIRM_FIRMWARE");
            //_name_label.Text =  CLanguages.GetTranslate("PAGE_FIRM_NAME");

            _firmwareBackup_groupBox.Text =  CLanguages.GetTranslate("PAGE_FIRM_FIRMWAREBACKUP");
            _file_label1.Text =  CLanguages.GetTranslate("PAGE_FIRM_FILE");
            _firmware_down_open_file_button.Text =  CLanguages.GetTranslate("PAGE_FIRM_SAVE");
            _ver_label1.Text =  CLanguages.GetTranslate("PAGE_FIRM_VER");
            _state_label1.Text =  CLanguages.GetTranslate("PAGE_FIRM_STATE");
            _firmware_dowload_button.Text =  CLanguages.GetTranslate("PAGE_FIRM_DOWNLOAD");

            _firmwareUpload_groupBox.Text =  CLanguages.GetTranslate("PAGE_FIRM_FIRMWAREUPLOAD");
            _file_label2.Text =  CLanguages.GetTranslate("PAGE_FIRM_FILE");
            _firmware_up_open_file_button.Text =  CLanguages.GetTranslate("PAGE_FIRM_OPEN");
            _ver_label2.Text =  CLanguages.GetTranslate("PAGE_FIRM_VER");
            _state_label2.Text =  CLanguages.GetTranslate("PAGE_FIRM_STATE");
            _firmware_upload_button.Text =  CLanguages.GetTranslate("PAGE_FIRM_UPLOAD");

            _console_groupBox.Text =  CLanguages.GetTranslate("PAGE_FIRM_CONSOLE");
        }

        public event EventHandler On_BootloaderDownloadMode;
        public event EventHandler On_BootloaderUploadMode;
    }
}
