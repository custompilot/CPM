using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomPilot.Language;
using System.IO;
using CustomPilot.core;

namespace CustomPilot.control
{
    public partial class UC_Reports : UserControl
    {

        struct s_report
        {
            public ushort FID;
            public ushort idx_data;
            public ushort report_count;
            public ushort wdt;
            public s_report_data[] histories;
        };

        struct s_report_data
        {
            public ushort   FID;
            public uint     time;
            public ushort   wire_error_count;
            public byte     loc;

            public ushort   voltage,
                            temperature,
                            radio_hz;
            public byte     triggers;
        };


        private s_report _report = new s_report();

        public void set_language()
        {
            _reports_groupBox.Text = Languages.PAGE_REPORTS_REPORTS;
            __export_button.Text = Languages.PAGE_REPORTS_EXPORT;
            ___reset_button.Text = Languages.PAGE_REPORTS_RESET;
        }

        public UC_Reports()
        {
            InitializeComponent();

            _report.histories = new s_report_data[20];

            DataGridViewCellStyle header_style = new DataGridViewCellStyle();

            header_style.BackColor = Color.Beige;
            header_style.Font = new Font("Verdana", 8, FontStyle.Bold);
            __dataGridView.ColumnHeadersDefaultCellStyle = header_style;
            __dataGridView.RowHeadersWidth = 50;

            /*
            string[] row1 = new string[] { "a", "b", "c", "d", "e", "f" };
            __dataGridView.Rows.Add(row1);
            */
        }

        public void DecodeData(byte[] dat)
        {
            // FID
            _report.FID = BitConverter.ToUInt16(dat, 0);
            _report.idx_data = (ushort)dat[2];
            _report.report_count = (ushort)dat[3];
            _report.wdt = (ushort)dat[4];

            if (_report.wdt > 0)
            {
                __WDT_label.BackColor = Color.Red;
                __WDT_label.Text = ((ushort)_report.wdt).ToString();
            }
            else
            {
                __WDT_label.BackColor = this.BackColor;
                __WDT_label.Text = "SAFE";
            }


            __dataGridView.Rows.Clear();

            __fid_label.Text = String.Format("{0, 5:D5}", _report.FID);
            __count_label.Text = String.Format("{0}", (UInt16)_report.report_count);

            int idx = 5;
            for (int i = 0; i < 20; i++)
            {
                // time
                _report.histories[i].FID = BitConverter.ToUInt16(dat, idx);
                idx += 2;

                _report.histories[i].time = BitConverter.ToUInt32(dat, idx);
                idx += 4;

                // wire error count
                _report.histories[i].wire_error_count = BitConverter.ToUInt16(dat, idx);
                idx += 2;

                // voltage
                _report.histories[i].voltage = dat[idx];
                idx++;

                // temperature
                _report.histories[i].temperature = dat[idx];
                idx++;

                // radio hz
                _report.histories[i].radio_hz = dat[idx];
                idx++;

                // location
                _report.histories[i].loc = dat[idx];
                idx++;

                // triggers
                _report.histories[i].triggers = dat[idx];
                idx++;
            }

            idx = _report.idx_data - 1;

            if (idx < 0)
                idx = 19;
            for(int i = 0; i < _report.report_count; i++)
            {
                string
                    t_radio = "",
                    t_vcc = "",
                    t_temp = "",
                    t_error = "",
                    t_wdt = "";

                //trigger 체크
                // 1. radio
                byte flag = _report.histories[idx].triggers;
                if((flag & 1) != 0)
                    t_radio = "√";
                
                if((flag & 2) != 0)
                    t_vcc = "√";

                if((flag & 4) != 0)
                    t_temp = "√";

                if((flag & 8) != 0)
                    t_error = "√";

                if((flag & 16)!=0)
                    t_wdt = "√";

                // data grid drawing
                string[] row = new string[] {
                    String.Format("{0, 5:D5}", _report.histories[idx].FID),
                    String.Format("{0:#,###}", 
                        _report.histories[idx].time
                    ),
                    String.Format("{0}", (ushort)_report.histories[idx].radio_hz),
                    String.Format("{0, 3:F1}", ((ushort)_report.histories[idx].voltage) / 10.0),
                    String.Format("{0}", (ushort)_report.histories[idx].temperature),
                    _report.histories[idx].wire_error_count.ToString(),
                    _report.histories[idx].loc.ToString(),
                    t_radio,
                    t_vcc,
                    t_temp,
                    t_error,
                    t_wdt
                    };

                __dataGridView.Rows.Add(row);
                __dataGridView.Rows[i].HeaderCell.Value = String.Format("{0, 2:D2}", i);

                idx--;
                if (idx < 0)
                    idx = 19;
            }
        }

        private FileIO _file = new FileIO();
        private void __export_button_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CPM log files | *.cpl";
            sfd.DefaultExt = "cpl";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (BinaryWriter b = new BinaryWriter(File.Open(sfd.FileName, FileMode.Create)))
                {
                    b.Write("fid,time,radiohz,voltage,temperature,i2c error, loc, R, V, T, E, W\n");

                    int idx = _report.idx_data - 1;

                    if (idx < 0)
                        idx = 19;
                    for (int i = 0; i < 20; i++)
                    {
                        string
                            t_radio = "",
                            t_vcc = "",
                            t_temp = "",
                            t_error = "",
                            t_wdt = "";

                        //trigger 체크
                        // 1. radio
                        byte flag = _report.histories[idx].triggers;
                        if ((flag & 1) != 0)
                            t_radio = "√";

                        if ((flag & 2) != 0)
                            t_vcc = "√";

                        if ((flag & 4) != 0)
                            t_temp = "√";

                        if ((flag & 8) != 0)
                            t_error = "√";

                        if ((flag & 16) != 0)
                            t_wdt = "√";

                        // data grid drawing
                        string line = String.Format("{0, 5:D5}", _report.histories[idx].FID) + "," +
                                        String.Format("{0:#,###}", _report.histories[idx].time) + "," +
                                        String.Format("{0}", (ushort)_report.histories[idx].radio_hz) + "," +
                                        String.Format("{0, 3:F1}", ((ushort)_report.histories[idx].voltage) / 10.0) + "," +
                                        String.Format("{0}", (ushort)_report.histories[idx].temperature) + "," +
                                        _report.histories[idx].wire_error_count.ToString() + "," +
                                        _report.histories[idx].loc.ToString() + "," +
                                        t_radio + "," +
                                        t_vcc + "," +
                                        t_temp + "," +
                                        t_error + "," +
                                        t_wdt + System.Environment.NewLine;

                        b.Write(line);

                        idx--;
                        if (idx < 0)
                            idx = 19;
                    }
                    b.Close();
                }
            }
        }

        public event EventHandler OnResetReport;
        private void __reset_button_Click(object sender, EventArgs e)
        {
            if (OnResetReport != null)
                OnResetReport(sender, e);
        }
    }
}
