using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomPilot.control
{
    public partial class UC_ChannelSet : UserControl
    {
        public UC_ChannelSet()
        {
            InitializeComponent();
        }

        public bool NOPULSE
        {
            set
            {
                if (value)
                    __current_TextBox.BackColor = Color.Red;
                else
                    __current_TextBox.BackColor = this.BackColor;
            }
        }

        private Color _bgColor = new Color();
        public Color BColor{
            set
            {
                _bgColor = value;
                this.BackColor = value;
                __current_TextBox.BackColor = value;
                __min_textBox.BackColor = value;
                __max_textBox.BackColor = value;
                __mid_textBox.BackColor = value;
                __reverse_checkBox.BackColor = value;

                __min_down_button.BackColor = value;
                __min_up_button.BackColor = value;

                __mid_down_button.BackColor = value;
                __mid_up_button.BackColor = value;

                __max_down_button.BackColor = value;
                __max_up_button.BackColor = value;
            }

            get
            {
                return _bgColor;
            }
        }

        public event EventHandler On_Changed;

        public bool Reverse
        {
            set
            {
                lock_event();
                __reverse_checkBox.Checked = value;
                unlock_event();
            }

            get
            {
                return __reverse_checkBox.Checked;
            }
        }

        public int Low
        {
            set
            {
                lock_event();
                __min_textBox.Text = value.ToString();
                __uC_ChannelMonitor1.Low = value;
                unlock_event();
            }

            get
            {
                return __uC_ChannelMonitor1.Low;
            }
        }

        public int High
        {
            set
            {
                lock_event();
                __max_textBox.Text = value.ToString();
                __uC_ChannelMonitor1.High = value;
                unlock_event();
            }

            get
            {
                return __uC_ChannelMonitor1.High;
            }
        }

        public int Current
        {
            set
            {
                lock_event();
                __uC_ChannelMonitor1.Current = value;
                __current_TextBox.Text = value.ToString();
                unlock_event();
            }

            get
            {
                return __uC_ChannelMonitor1.Current;
            }
        }

        public int Mid
        {
            set
            {
                lock_event();
                __uC_ChannelMonitor1.Center = value;
                __mid_textBox.Text = value.ToString();
                unlock_event();
            }
            get
            {
                return __uC_ChannelMonitor1.Center;
            }
        }

        private bool _is_lock_event = false;
        private void lock_event()
        {
            _is_lock_event = true;
        }

        private void unlock_event()
        {
            _is_lock_event = false;
        }

        private void __min_down_button_Click(object sender, EventArgs e)
        {
            lock_event();
            int v = int.Parse(__min_textBox.Text);
            v--;
            __min_textBox.Text = v.ToString();
            __uC_ChannelMonitor1.Low = v;
            unlock_event();
            raise_changed(sender, e);
        }

        private void __min_up_button_Click(object sender, EventArgs e)
        {
            lock_event();
            int v = int.Parse(__min_textBox.Text);
            v++;
            __min_textBox.Text = v.ToString();
            __uC_ChannelMonitor1.Low = v;
            unlock_event();
            raise_changed(sender, e);
        }

        private void __max_down_button_Click(object sender, EventArgs e)
        {
            lock_event();
            int v = int.Parse(__max_textBox.Text);
            v--;
            __max_textBox.Text = v.ToString();
            __uC_ChannelMonitor1.High = v;
            unlock_event();
            raise_changed(sender, e);
        }

        private void __max_up_button_Click(object sender, EventArgs e)
        {
            lock_event();
            int v = int.Parse(__max_textBox.Text);
            v++;
            __max_textBox.Text = v.ToString();
            __uC_ChannelMonitor1.High = v;
            unlock_event();
            raise_changed(sender, e);
        }

        private void __mid_down_button_Click(object sender, EventArgs e)
        {
            lock_event();
            int v = int.Parse(__mid_textBox.Text);
            v--;
            __mid_textBox.Text = v.ToString();
            __uC_ChannelMonitor1.Center = v;
            unlock_event();
            raise_changed(sender, e);
        }

        private void __mid_up_button_Click(object sender, EventArgs e)
        {
            lock_event();
            int v = int.Parse(__mid_textBox.Text);
            v++;
            __mid_textBox.Text = v.ToString();
            __uC_ChannelMonitor1.Center = v;
            unlock_event();
            raise_changed(sender, e);
        }
        
        private void __min_textBox_Leave(object sender, EventArgs e)
        {
            lock_event();
            int v = int.Parse(__min_textBox.Text);
            __min_textBox.Text = v.ToString();
            __uC_ChannelMonitor1.Low = v;
            unlock_event();
            raise_changed(sender, e);
        }

        private void __max_textBox_Leave(object sender, EventArgs e)
        {
            lock_event();
            int v = int.Parse(__max_textBox.Text);
            __max_textBox.Text = v.ToString();
            __uC_ChannelMonitor1.High = v;
            unlock_event();
            raise_changed(sender, e);
        }
        

        private void __reverse_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            raise_changed(sender, e);
        }

        private void raise_changed(object sender, EventArgs e)
        {
            _timer.Enabled = true;
        }

        private void UC_ChannelSet_Load(object sender, EventArgs e)
        {
            _timer.Enabled = false;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            _timer.Enabled = false;
            if (_is_lock_event == false)
            {
                On_Changed(sender, e);
            }
        }

        private void __min_textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            int v;
            int.TryParse(tb.Text, out v);
            if (v > 900 && v < 2100)
            {
                raise_changed(sender, e);
                __min_textBox.Text = v.ToString();
                __uC_ChannelMonitor1.Low = v;
            }
        }

        private void __max_textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            int v;
            int.TryParse(tb.Text, out v);
            if (v > 900 && v < 2100)
            {
                raise_changed(sender, e);
                __max_textBox.Text = v.ToString();
                __uC_ChannelMonitor1.High = v;
            }
        }

        private void __mid_textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            int v;
            int.TryParse(tb.Text, out v);
            if (v > 900 && v < 2100)
            {
                raise_changed(sender, e);
                __mid_textBox.Text = v.ToString();
                __uC_ChannelMonitor1.Center= v;
            }
        }
    }
}
