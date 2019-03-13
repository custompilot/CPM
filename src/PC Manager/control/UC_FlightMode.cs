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

namespace CustomPilot.control
{
    public partial class UC_FlightMode : UserControl
    {
        public UC_FlightMode()
        {
            InitializeComponent();
        }
        
        //private int _current_mixmode;

        private ushort parse_tmode_topdigit(int tmode)
        {
            if (tmode >= 100)
                return (ushort)(tmode - (tmode % 100));
            else if (tmode >= 10)
                return (ushort)(tmode - (tmode % 10));
            return (ushort)tmode;
        }

        public bool SetEnabled
        {
            set
            {
                __set_button.Enabled = value;
            }
        }

        private bool _ActiveMode = false;
        public bool ActiveMode
        {
            set
            {
                if (value)
                    __modename_label.BackColor = Color.SkyBlue;
                else
                    __modename_label.BackColor = SystemColors.ButtonFace;
                
            }

            get
            {
                return _ActiveMode;
            }
        }

        /*
        public int Current_Mixmode
        {
            set
            {
                _current_mixmode = value;

                if (value != 0 && value != MIXMODE)
                    __set_button.Enabled = true;                
                else
                    __set_button.Enabled = false;

                if (parse_tmode_topdigit(value) == parse_tmode_topdigit(MIXMODE) && MIXMODE > 0)
                    __modename_label.BackColor = Color.SkyBlue;
                else
                    __modename_label.BackColor = SystemColors.ButtonFace;
            }

            get
            {
                return _current_mixmode;
            }
        }*/

        public string MODE_NAME
        {
            set
            {
                __modename_label.Text = value;
            }

            get
            {
                return __modename_label.Text;
            }
        }

        public int MIXMODE
        {
            set
            {
                __mixmode_label.Text = value.ToString();

                if(value == 0)
                    __del_button.Enabled = false;
                else
                    __del_button.Enabled = true;
            }
            get
            {
                return int.Parse(__mixmode_label.Text);
            }
        }
        
        private void __set_button_Click(object sender, EventArgs e)
        {
            if (On_AddMode != null)
                On_AddMode(this, e);
        }

        private void __del_button_Click(object sender, EventArgs e)
        {
            if (On_DelMode != null)
                On_DelMode(this, e);
        }

        public event EventHandler On_AddMode;
        public event EventHandler On_DelMode;
        
    }
}
