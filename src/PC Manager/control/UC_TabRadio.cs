using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomPilot.core;
using CustomPilot.Language;

namespace CustomPilot.control
{
    public enum ___RADIO_PROTOCOL1
    {
        SBUS = 0,
        PPM = 3,
        IBUS = 5
    }

    public enum ___RADIO_PROTOCOL0
    {
        //SUMD = 2,
        DSMX = 1,
        DSM = 4
    }

    public partial class UC_TabRadio : UserControl
    {
        ComboBox[]          _ich_comboBoxs = new ComboBox[16];
        UC_ChannelMonitor[] _ch_monitors = new UC_ChannelMonitor[16];
        Label[]             _ch_labels = new Label[16];
        private int _pSet = 0;

        public bool IsFailsafe
        {
            set
            {
                __failsafe_label1.Visible = value;
            }
        }

        public bool IsNosignal
        {
            set
            {
                __nosignal_label.Visible = value;
            }
        }


        public void set_language()
        {
            _protocol_groupBox.Text =  CLanguages.GetTranslate("PAGE_RADIO_PROTOCOL");
            _hz_label.Text =  CLanguages.GetTranslate("PAGE_RADIO_RADIOHZ");
            _input_label.Text =  CLanguages.GetTranslate("PAGE_RADIO_INPUTCHANNELS");
            _calibration_groupBox.Text =  CLanguages.GetTranslate("PAGE_RADIO_CALIBRATION");
            _min_label.Text =  CLanguages.GetTranslate("PAGE_RADIO_MIN");
            _center_label.Text =  CLanguages.GetTranslate("PAGE_RADIO_CENTER");
            _max_label.Text =  CLanguages.GetTranslate("PAGE_RADIO_MAX");

            _default_button.Text = _ich_default_button.Text =  CLanguages.GetTranslate("PAGE_RADIO_DEFAULT");
            _save_radio_button.Text =  CLanguages.GetTranslate("PAGE_RADIO_SAVE");
        }
        
        public UC_TabRadio()
        {
            InitializeComponent();

            _ich_comboBoxs[0] = __ch1_comboBox;
            _ich_comboBoxs[1] = __ch2_comboBox;
            _ich_comboBoxs[2] = __ch3_comboBox;
            _ich_comboBoxs[3] = __ch4_comboBox;
            _ich_comboBoxs[4] = __ch5_comboBox;
            _ich_comboBoxs[5] = __ch6_comboBox;
            _ich_comboBoxs[6] = __ch7_comboBox;
            _ich_comboBoxs[7] = __ch8_comboBox;
            _ich_comboBoxs[8] = __ch9_comboBox;
            _ich_comboBoxs[9] = __ch10_comboBox;
            _ich_comboBoxs[10] = __ch11_comboBox;
            _ich_comboBoxs[11] = __ch12_comboBox;
            _ich_comboBoxs[12] = __ch13_comboBox;
            _ich_comboBoxs[13] = __ch14_comboBox;
            _ich_comboBoxs[14] = __ch15_comboBox;
            _ich_comboBoxs[15] = __ch16_comboBox;

            _ch_monitors[0] = __uC_ChannelMonitor1;
            _ch_monitors[1] = __uC_ChannelMonitor2;
            _ch_monitors[2] = __uC_ChannelMonitor3;
            _ch_monitors[3] = __uC_ChannelMonitor4;
            _ch_monitors[4] = __uC_ChannelMonitor5;
            _ch_monitors[5] = __uC_ChannelMonitor6;
            _ch_monitors[6] = __uC_ChannelMonitor7;
            _ch_monitors[7] = __uC_ChannelMonitor8;
            _ch_monitors[8] = __uC_ChannelMonitor9;
            _ch_monitors[9] = __uC_ChannelMonitor10;
            _ch_monitors[10] = __uC_ChannelMonitor11;
            _ch_monitors[11] = __uC_ChannelMonitor12;
            _ch_monitors[12] = __uC_ChannelMonitor13;
            _ch_monitors[13] = __uC_ChannelMonitor14;
            _ch_monitors[14] = __uC_ChannelMonitor15;
            _ch_monitors[15] = __uC_ChannelMonitor16;

            _ch_labels[0] = __ch1_label;
            _ch_labels[1] = __ch2_label;
            _ch_labels[2] = __ch3_label;
            _ch_labels[3] = __ch4_label;
            _ch_labels[4] = __ch5_label;
            _ch_labels[5] = __ch6_label;
            _ch_labels[6] = __ch7_label;
            _ch_labels[7] = __ch8_label;
            _ch_labels[8] = __ch9_label;
            _ch_labels[9] = __ch10_label;
            _ch_labels[10] = __ch11_label;
            _ch_labels[11] = __ch12_label;
            _ch_labels[12] = __ch13_label;
            _ch_labels[13] = __ch14_label;
            _ch_labels[14] = __ch15_label;
            _ch_labels[15] = __ch16_label;

            int i = 0;
            foreach (ComboBox combo in _ich_comboBoxs)
            {
                combo.DataSource = Enum.GetValues(typeof(S_EEPROM.ICH));

                if (i == 8)
                    i += 10;
                combo.SelectedIndex = (int)S_EEPROM.ICH.MODEC;
            }

            __protocol_comboBox.DataSource = Enum.GetValues(typeof(___RADIO_PROTOCOL1));
            __protocol_comboBox.SelectedIndex = 0;

        }

        private void decode_ich()
        {
            is_event = false;
            bool[] is_used = new bool[16];
            for (int i = 0; i < 16; i++)
            {
                is_used[i] = false;
            }

            //모든 콤보 na로 셋팅하기
            for (int role = 0; role <= (int)S_EEPROM.ICH.MODEC; role++)
            {
                set_ich(role, (int)Communication.EEPROM.radio.ich[role], ref is_used);
            }

            for (int i = 0; i < 16; i++)
            {
                if (is_used[i] == false)
                    _ich_comboBoxs[i].SelectedItem = S_EEPROM.ICH.NA;
            }
            is_event = true;
        }

        public void Decode_EEPROM()
        {
            _lockevent = true;
            if (Communication.EEPROM.plane.initialized != Communication.Initializecode)
                return;
            
            decode_ich();
            
            for(int i = 0; i < 16; i++)
            {
                //_ch_monitors[i].Low = Communication.EEPROM.radio.trim.min;
                //_ch_monitors[i].High = Communication.EEPROM.radio.trim.max;
                //_ch_monitors[i].Center = Communication.EEPROM.radio.trim.offset;
            }

            __max_textBox.Text = Communication.EEPROM.radio.trim.max.ToString();
            __min_textBox.Text = Communication.EEPROM.radio.trim.min.ToString();
            __center_textBox.Text = Communication.EEPROM.radio.trim.offset.ToString();

            //if (Communication.EEPROM.radio.protocol < __protocol_comboBox.Items.Count)
            for (int i = 0; i < __protocol_comboBox.Items.Count; i++)
                if (_pSet == 1)
                    //if ((___RADIO_PROTOCOL1)__protocol_comboBox.Items[i] == (___RADIO_PROTOCOL1)Communication.EEPROM.radio.protocol)
                    __protocol_comboBox.SelectedItem = (___RADIO_PROTOCOL1)Communication.EEPROM.radio.protocol;
                else
                    __protocol_comboBox.SelectedItem = (___RADIO_PROTOCOL0)Communication.EEPROM.radio.protocol;
                       
            _lockevent = false;
        }

        public void setRadioSet(int i)
        {
            if (i % 2 == 1)
            {
                __protocol_comboBox.DataSource = Enum.GetValues(typeof(___RADIO_PROTOCOL1));
            }else
                __protocol_comboBox.DataSource = Enum.GetValues(typeof(___RADIO_PROTOCOL0));

            _pSet = i % 2;
        }

        public int radio_hz
        {
            set
            {
                __hz_textBox.Text = value.ToString();

                if (value >= 100)
                    __hz_textBox.BackColor = Color.DarkGreen;
                else if (value >= 40)
                    __hz_textBox.BackColor = Color.GreenYellow;
                else
                    __hz_textBox.BackColor = Color.Pink;
            }
        }

        public int radio_fhz
        {
            set
            {
                __fhz_textBox.Text = value.ToString();

                if (value >= 100)
                    __fhz_textBox.BackColor = Color.DarkGreen;
                else if (value >= 40)
                    __fhz_textBox.BackColor = Color.GreenYellow;
                else
                    __fhz_textBox.BackColor = Color.Pink;
            }
        }

        private void set_ich(int role, int ch, ref bool[] is_used)
        {
            if (ch >= 0 && ch <= 15)
            {
                if (role <= (int)S_EEPROM.ICH.MODEC)
                {
                    _ich_comboBoxs[ch].SelectedIndex = role;
                    is_used[ch] = true;
                }
                else
                    is_used[ch] = false;
            }
        }

        private bool _lockevent = false;
        public void Decode_radio(byte[] radio)
        {
            _lockevent = true;
            for (int i = 0; i < 16; i++)
            {
                _ch_monitors[i].Current = BitConverter.ToInt16(radio, 0 + i * 2);
                _ch_labels[i].Text = BitConverter.ToInt16(radio, 0 + i * 2).ToString();
            }
            _lockevent = false;
        }

        public event EventHandler Protocol_Selected;
        private void __protocol_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Protocol_Selected != null && _lockevent == false)
            {
                if (_pSet == 1)
                    Communication.EEPROM.radio.protocol = (byte)(___RADIO_PROTOCOL1)__protocol_comboBox.SelectedItem;
                else
                    Communication.EEPROM.radio.protocol = (byte)(___RADIO_PROTOCOL0)__protocol_comboBox.SelectedItem;
                Protocol_Selected(sender, e);
            }
        }
        
        
        public event EventHandler Channel_Selected;
        private bool is_event = false;
        private void __ch16_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (is_event == false)
                return;

            // 현재 채널 번호 역할을 NA로
            byte[] roles = new byte[(int)S_EEPROM.ICH.MODEC + 1];
            for (int i = 0; i <= (int)S_EEPROM.ICH.MODEC; i++)
                roles[i] = (int)S_EEPROM.ICH.NA;

            // 현재 선택 콤보 번호 찾기
            int combo_idx = 0, combo_selected = ((ComboBox)sender).SelectedIndex;
            for (int i = 0; i < 16; i++)
            {
                if (sender == _ich_comboBoxs[i])
                {
                    combo_idx = i;
                }
            }

            // 다른 콤보에 같은 역할이 있으면 N/A로 교체, NA가 아닌경우만 확인
            is_event = false;
            if (combo_selected != (int)S_EEPROM.ICH.NA)
            {
                for (int i = 0; i < 16; i++)
                {
                    if (i == combo_idx)
                    {
                        continue;
                    }
                    else if (_ich_comboBoxs[i].SelectedIndex == combo_selected /*|| i_selected + 10 == selected || i_selected - 10 == selected*/)
                    {
                        _ich_comboBoxs[i].SelectedItem = S_EEPROM.ICH.NA;
                    }
                }
            }            
            is_event = true;
            int role = 255;
            // 선택 채널 찾기
            //for(int i = 0; i <= (int)S_EEPROM.ICH.MODEC; i++)
            for (int i = 0; i < 16; i++)
            {
                role = (int)_ich_comboBoxs[i].SelectedItem;

                if (role < (int)S_EEPROM.ICH.NA)
                    roles[role] = (byte)i;

                Console.WriteLine(role);
            }

            for (int i = 0; i <= (int)S_EEPROM.ICH.MODEC; i++)
                Communication.EEPROM.radio.ich[i] = roles[i];

            decode_ich();
            
            // eeprom update
            if (Channel_Selected != null)
                Channel_Selected(sender, e);                    
            
        }

        private void __ich_default_button_Click(object sender, EventArgs e)
        {
            Communication.EEPROM.reset_ich();
            decode_ich();

            if (Channel_Selected != null)
                Channel_Selected(sender, e);
        }

        private void __default_button_Click(object sender, EventArgs e)
        {
            __min_textBox.Text = "988";
            __max_textBox.Text = "2012";
            __center_textBox.Text = "1500";

            __save_radio_button_Click(this, null);
        }

        public event EventHandler Calibration_Changed;
        private void __save_radio_button_Click(object sender, EventArgs e)
        {
            ushort min = ushort.Parse(__min_textBox.Text);
            ushort cen = ushort.Parse(__center_textBox.Text);
            ushort max = ushort.Parse(__max_textBox.Text);

            if(min < 700 || max > 2300 ||
                min > cen ||
                cen > max
                )
            {
                min = 988;
                cen = 1500;
                max = 2008;

                __default_button_Click(null, null);

                MessageBox.Show("Radio 값은 700(min) ~ 2300(max) 이며,\n max는 center, min 보다 커야 하며,\n min은 center, max 보다 작아야 합니다.", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            for (int i = 0; i < 16; i++)
            {
                //_ch_monitors[i].Low = min;
                //_ch_monitors[i].Center = cen;
                //_ch_monitors[i].High = max;
            }

            Communication.EEPROM.radio.trim.min = min;
            Communication.EEPROM.radio.trim.max = max;
            Communication.EEPROM.radio.trim.offset = cen;

            Calibration_Changed(sender, e);
        }

        private void UC_TabRadio_Load(object sender, EventArgs e)
        {

        }
    }
}
