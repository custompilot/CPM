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
    public partial class UC_TabServo : UserControl
    {
        private UC_ChannelSet[] _uc_channels = new UC_ChannelSet[12];
        private Label[] _ch_labels = new Label[12];
        private ComboBox []_ch_combos = new ComboBox[12];
        private bool _is_changed = false;
        private bool _lock_event = true;

        public void set_language()
        {
            _channel_groupBox.Text =  CLanguages.GetTranslate("PAGE_OUTPUT_CHANNEL");
            _ich_default_button.Text =  CLanguages.GetTranslate("PAGE_OUTPUT_DEFAULT");
            _output_groupBox.Text =  CLanguages.GetTranslate("PAGE_OTUPUT_OUTPUT");
            _pulse_label.Text =  CLanguages.GetTranslate("PAGE_OUTPUT_PULSE");
            _min_label.Text =  CLanguages.GetTranslate("PAGE_OUTPUT_MIN");
            _max_label.Text =  CLanguages.GetTranslate("PAGE_OUTPUT_MAX");
            _center_label.Text =  CLanguages.GetTranslate("PAGE_OUTPUT_CENTER");
            _default_trim_button.Text =  CLanguages.GetTranslate("PAGE_OUTPUT_DEFAULT");
            //_save_button.Text = Languages.PAGE_OUTPUT_SAVE;
        }

        public bool IsFailsafe
        {
            set
            {
                if (__failsafe_label1.Visible != value)
                {
                    __failsafe_label1.Visible = value;
                }
            }
        }

        private bool is_changed
        {
            set
            {
                _is_changed = value;
                //_save_button.Enabled = true;
            }

            get
            {
                return _is_changed;
            }
        }

        public UC_TabServo()
        {
            InitializeComponent();

            _uc_channels[0] = __uC_ChannelSet1;
            _uc_channels[1] = __uC_ChannelSet2;
            _uc_channels[2] = __uC_ChannelSet3;
            _uc_channels[3] = __uC_ChannelSet4;
            _uc_channels[4] = __uC_ChannelSet5;
            _uc_channels[5] = __uC_ChannelSet6;
            _uc_channels[6] = __uC_ChannelSet7;
            _uc_channels[7] = __uC_ChannelSet8;
            _uc_channels[8] = __uC_ChannelSet9;
            _uc_channels[9] = __uC_ChannelSet10;
            _uc_channels[10] = __uC_ChannelSet11;
            _uc_channels[11] = __uC_ChannelSet12;

            _ch_combos[0] = __ch1_comboBox;
            _ch_combos[1] = __ch2_comboBox;
            _ch_combos[2] = __ch3_comboBox;
            _ch_combos[3] = __ch4_comboBox;
            _ch_combos[4] = __ch5_comboBox;
            _ch_combos[5] = __ch6_comboBox;
            _ch_combos[6] = __ch7_comboBox;
            _ch_combos[7] = __ch8_comboBox;
            _ch_combos[8] = __ch9_comboBox;
            _ch_combos[9] = __ch10_comboBox;
            _ch_combos[10] = __ch11_comboBox;
            _ch_combos[11] = __ch12_comboBox;

            //_save_button.Enabled = false;
            default_channels();
            _lock_event = false;
        }

        private bool _skip_event = false;
        public void Decode_EEPROM()
        {
            try
            {
                _skip_event = true;
                for (int i = 0; i < 12; i++)
                {
                    _uc_channels[i].Low = Communication.EEPROM.servo.trim.channels[i].min;
                    _uc_channels[i].Mid = Communication.EEPROM.servo.trim.channels[i].offset;
                    _uc_channels[i].High = Communication.EEPROM.servo.trim.channels[i].max;
                    _ch_combos[i].SelectedItem = (S_EEPROM.OCH)Communication.EEPROM.servo.och[i];

                    if (_ch_combos[i].SelectedIndex == (int)S_EEPROM.OCH.NA)
                    {
                        _uc_channels[i].NOPULSE = true;
                        _uc_channels[i].Current = 0;
                    }
                    else
                        _uc_channels[i].NOPULSE = false;

                    if (Communication.EEPROM.servo.trim.channels[i].direction == -1)
                        _uc_channels[i].Reverse = true;
                    else
                        _uc_channels[i].Reverse = false;
                }
                _skip_event = false;
            }
            catch { }

            //_save_button.Enabled = false;
        }

        public void Decode_Servos(byte[] buf)
        {
            for(int i = 0; i < 12; i++)
            {
                int value = BitConverter.ToUInt16(buf, i * 2);

                if (value < 900)
                {
                    _uc_channels[i].NOPULSE = true;
                    _uc_channels[i].Current = 0;
                }
                else
                {
                    _uc_channels[i].NOPULSE = false;
                    _uc_channels[i].Current = BitConverter.ToUInt16(buf, i * 2);
                }
            }
        }

        private void default_channels()
        {
            int i = 0;
            foreach (ComboBox combo in _ch_combos)
            {
                combo.DataSource = Enum.GetValues(typeof(S_EEPROM.OCH));

                if (i == 5)
                    i = 16;
                combo.SelectedIndex = i++;
            }
        }

        private void default_trims()
        {
            _skip_event = true;
            foreach(UC_ChannelSet cset in _uc_channels)
            {
                cset.Low = 988;
                cset.High = 2012;
                cset.Mid = 1500;
            }
            _skip_event = false;
        }

        private void __ich_default_button_Click(object sender, EventArgs e)
        {
            _skip_event = true;
            default_channels();
            _skip_event = false;
            encode_EEPROM();
            raise_changed(sender, e);
            
            //is_changed = true;
        }

        void encode_EEPROM()
        {
            if (_skip_event == false)
            {
                for (int i = 0; i < 12; i++)
                {
                    Communication.EEPROM.servo.och[i] = (byte)(int)_ch_combos[i].SelectedItem;
                    Communication.EEPROM.servo.trim.channels[i].min = (ushort)_uc_channels[i].Low;
                    Communication.EEPROM.servo.trim.channels[i].offset = (ushort)_uc_channels[i].Mid;
                    Communication.EEPROM.servo.trim.channels[i].max = (ushort)_uc_channels[i].High;

                    if (_uc_channels[i].Reverse)
                        Communication.EEPROM.servo.trim.channels[i].direction = -1;
                    else
                        Communication.EEPROM.servo.trim.channels[i].direction = 0;
                }
            }
        }

        public event EventHandler OnServoSettingChanged;

        private void __uC_ChannelSet12_On_Changed(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            
            for (int i = 0; i < _ch_combos.Length; i++)
            {
                if (cb == _ch_combos[i])
                    if(cb.SelectedItem == (object)S_EEPROM.OCH.NA)
                        _uc_channels[i].NOPULSE = true;
                    else
                        _uc_channels[i].NOPULSE = false;
            }

            if (_lock_event == false)
            {
                encode_EEPROM();
                raise_changed(sender, e);
            }
        }

        private void __uC_ChannelSet_On_Changed(object sender, EventArgs e)
        {
            if (!_lock_event)
            {
                encode_EEPROM();
                raise_changed(sender, e);
            }
        }

        private void __save_button_Click(object sender, EventArgs e)
        {
            //is_changed = false;
            //_save_button.Enabled = false;
            encode_EEPROM();
            raise_changed(sender, e);
        }

        private void __default_trim_button_Click(object sender, EventArgs e)
        {
            default_trims();
            encode_EEPROM();
            raise_changed(sender, e);
        }

        private void raise_changed(object sender, EventArgs e)
        {
            if(_skip_event == false)
                if (OnServoSettingChanged != null)
                    OnServoSettingChanged(this, e);
        }
    }
}
