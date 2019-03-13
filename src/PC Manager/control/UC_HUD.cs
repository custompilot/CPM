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
    public partial class UC_HUD : UserControl
    {
        public UC_HUD()
        {
            InitializeComponent();
        }

        public float Roll
        {
            set
            {
                __hud.Roll = (float)Math.Round(value, 1);
            }
        }

        public float Pitch
        {
            set
            {
                try
                {
                    __hud.Pitch = (float)Math.Round(value, 1);
                    __hor.Pitch = (float)Math.Round(value, 1);
                }
                catch { }
            }
        }

        public float Altitude
        {
            set
            {
                __hud.Altitude = (float)Math.Round(value, 1);
            }
        }

        public float Heading
        {
            set
            {
                __hud.Heading = (float)Math.Round(value, 1);
                __comp.Heading = (float)Math.Round(value, 1);
            }
        }

        public void Draw()
        {
            try
            {
                __hud.Draw();
            }
            catch { }
        }

        public bool CalibrationWarning
        {
            set
            {
                __imuCal_label.Visible = value;
            }
            get
            {
                return __imuCal_label.Visible;
            }
        }

        private void UC_HUD_Load(object sender, EventArgs e)
        {
        }
    }
}
