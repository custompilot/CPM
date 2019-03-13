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
    public partial class UC_TabFlightMode : UserControl
    {
        private Label[] _mode_labels = new Label[3];
        private UC_FlightMode[] _uc_flightmodes = new UC_FlightMode[7];

        public UC_TabFlightMode()
        {
            InitializeComponent();

            _modes.modes = new int[3];
            _mode_labels[0] = __mode_label;
            _mode_labels[1] = __modeB_label;
            _mode_labels[2] = __modeC_label;

            _uc_flightmodes[0] = __uC_FlightMode1;
            _uc_flightmodes[1] = __uC_FlightMode2;
            _uc_flightmodes[2] = __uC_FlightMode3;
            _uc_flightmodes[3] = __uC_FlightMode4;
            _uc_flightmodes[4] = __uC_FlightMode5;
            _uc_flightmodes[5] = __uC_FlightMode6;
            _uc_flightmodes[6] = __uC_FlightMode7;

            _uc_flightmodes[0].MODE_NAME = "MANUAL";
            _uc_flightmodes[1].MODE_NAME = "STABILIZATION";
            _uc_flightmodes[2].MODE_NAME = "TAKE OFF";
            _uc_flightmodes[3].MODE_NAME = "HOVERING";
            _uc_flightmodes[4].MODE_NAME = "REVERSE";
            _uc_flightmodes[5].MODE_NAME = "KNIFE EDGE";
            _uc_flightmodes[6].MODE_NAME = "STABILIZATION2";
        }

        public void set_language()
        {
            _modechannels_groupBox.Text = Languages.PAGE_MODE_MODECHANNELS;
            _mode1_label.Text = Languages.PAGE_MODE_A;
            _mode2_label.Text = Languages.PAGE_MODE_B;
            _mode3_label.Text = Languages.PAGE_MODE_C;
            _modeSetting_groupBox.Text = Languages.PAGE_MODE_SETTING;
            _mixMode_label.Text = Languages.PAGE_MODE_MIX;
            __default_button.Text = Languages.PAGE_MODE_DEFAULT;
        }

        struct s_modes
        {
            public int []modes;
            public int tmode;

            public int Mode
            {
                set
                {
                    modes[0] = value;
                }
                get
                {
                    return modes[0];
                }
            }

            public int ModeB
            {
                set
                {
                    modes[1] = value;
                }
                get
                {
                    return modes[1];
                }
            }

            public int ModeC
            {
                set
                {
                    modes[2] = value;
                }
                get
                {
                    return modes[2];
                }
            }
            
        }
        s_modes _modes = new s_modes();

        public void Decode_EEPROM()
        {
            // mode a, b, c 채널 찾아 적용
            _modes.Mode = _modes.ModeB = _modes.ModeC = -1;
            for (int i = 0; i < Communication.EEPROM.radio.ich.Length; i++)
            {
                switch (Communication.EEPROM.radio.ich[i])
                {
                    case (byte)S_EEPROM.ICH.MODE:
                        _modes.Mode = Communication.EEPROM.radio.ich[i];
                        break;

                    case (byte)S_EEPROM.ICH.MODEB:
                        _modes.ModeB = Communication.EEPROM.radio.ich[i];
                        break;

                    case (byte)S_EEPROM.ICH.MODEC:
                        _modes.ModeC = Communication.EEPROM.radio.ich[i];
                        break;
                }
            }

            // 비행모드 표시하기
            for(int i = 0; i < Communication.EEPROM.mode.modes.Length; i++)
            {
                if (Communication.EEPROM.mode.modes[i] != 0)
                    _uc_flightmodes[i].MIXMODE = Communication.EEPROM.mode.modes[i];
                else
                    _uc_flightmodes[i].MIXMODE = 0;
            }
        }
        
        public void Decode_raw(byte[] buf)
        {
            for (int i = 0; i < 3; i++)
            {
                _modes.modes[i] = BitConverter.ToUInt16(buf, i * 2);
                _mode_labels[i].Text = _modes.modes[i].ToString();
            }

            _modes.tmode = BitConverter.ToUInt16(buf, 6);
            __mode_mix_Label.Text = _modes.tmode.ToString();

            int activeMode = BitConverter.ToInt16(buf, 8) - 1;
            for(int i = 0; i < Communication.EEPROM.mode.modes.Length; i++)
            {
                if (activeMode != i)
                    _uc_flightmodes[i].ActiveMode = false;
                else
                    _uc_flightmodes[i].ActiveMode = true;                

                if (_modes.tmode == 0)
                    _uc_flightmodes[i].SetEnabled = false;
                else if (i > 0 && activeMode != i)
                    _uc_flightmodes[i].SetEnabled = true;
                else
                    _uc_flightmodes[i].SetEnabled = false;
            }
        }
        
        private void __uC_FlightMode7_On_AddMode(object sender, EventArgs e)
        {
            int idx = find_mode_index(sender);

            _uc_flightmodes[idx].MIXMODE = parse_tmode_topbit();
            Communication.EEPROM.mode.modes[idx] = parse_tmode_topbit();

            if (On_FlightModeChanged != null)
                On_FlightModeChanged(this, e);
        }

        private void __uC_FlightMode7_On_DelMode(object sender, EventArgs e)
        {
            int idx = find_mode_index(sender);

            _uc_flightmodes[idx].MIXMODE = 0;
            Communication.EEPROM.mode.modes[idx] = 0;

            if (On_FlightModeChanged != null)
                On_FlightModeChanged(this, e);
        }

        private ushort parse_tmode_topbit()
        {
            if (_modes.tmode >= 100)
            {
                return (ushort)(_modes.tmode - (_modes.tmode % 100));
            }
            else if (_modes.tmode >= 10)
            {
                return (ushort)(_modes.tmode - (_modes.tmode % 10));
            }
            return (ushort)_modes.tmode;
        }

        private int find_mode_index(object sender)
        {
            for (int i = 0; i < Communication.EEPROM.mode.modes.Length; i++)
            {
                if (sender == _uc_flightmodes[i])
                    return i;
            }
            return -1;
        }

        public event EventHandler On_FlightModeChanged;
        
        private void __default_button_Click(object sender, EventArgs e)
        {
            Communication.EEPROM.reset_mode();
            if (On_FlightModeChanged != null)
                On_FlightModeChanged(this, e);
        }
    }
}