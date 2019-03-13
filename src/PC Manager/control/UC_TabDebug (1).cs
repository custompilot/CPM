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

namespace CustomPilot.control
{
    public partial class UC_TabDebug : UserControl
    {
        public UC_TabDebug()
        {
            InitializeComponent();

            avrdude.OnConsoleReceived += Avrdude_OnConsoleReceived;
            avrdude.OnFirmwareDownloadComplete += Avrdude_OnFirmwareDownloadComplete;
            avrdude.OnStateChanged += Avrdude_OnStateChanged;
        }

        private String _consoleBuf;

        private void Avrdude_OnStateChanged(object sender, EventArgs e)
        {
            EventArgs_StateChanged ea = (EventArgs_StateChanged)e;
            __downState_label.Invoke(new Action(() =>
            {
                __downState_label.Text = ea.State;
                __down_progressBar.Value = ea.percent;
            }));
        }

        private void Avrdude_OnFirmwareDownloadComplete(object sender, EventArgs e)
        {
            __downState_label.BeginInvoke(new Action(() => {
                __firmware_dowload_button.Enabled = true;
                __console_textBox.AppendText(_consoleBuf);

                _consoleBuf = "";
            }));
        }

        private void Avrdude_OnConsoleReceived(object sender, EventArgs e)
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

        private void UC_TabDebug_Load(object sender, EventArgs e)
        {
            __firmware_download_textBox.Text = Properties.Settings.Default.ProgrammerDownPath;
            __firmware_upload_textBox.Text = Properties.Settings.Default.ProgrammerUpPath;

            __programmer_comboBox.SelectedIndex = 0;
        }
        
        public event EventHandler On_WDTtest;

        private void __get_button_Click(object sender, EventArgs e)
        {
            if (On_WDTtest != null)
                On_WDTtest(this, e);
        }

        private NAvrdudeProgrammer avrdude = new NAvrdudeProgrammer();
        // firmware area
        private void __firmware_down_open_file_button_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Binary Files | *.bin";
            dlg.DefaultExt = "bin";

            dlg.CheckPathExists = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                __firmware_download_textBox.Text = dlg.FileName;
            }
        }

        private void __firmware_dowload_button_Click(object sender, EventArgs e)
        {
            avrdude.doanloadFirmware(__firmware_download_textBox.Text, __programmer_comboBox.Text);
        }
    }
}
