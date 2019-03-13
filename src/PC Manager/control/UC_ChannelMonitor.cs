using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace CustomPilot.control
{
    
    public partial class UC_ChannelMonitor : UserControl
    {
        struct SVALUE
        {
            public float Min, Max, Low, High, Center, Current;
        }

        private SVALUE _values;

        public int Low
        {
            set
            {
                if (_values.Low != (float)value)
                {
                    _values.Low = (float)value;
                    Invalidate();
                }
            }

            get
            {
                return (int)_values.Low;
            }
        }

        public int High
        {
            set
            {
                if (_values.High != (float)value)
                {
                    _values.High = (float)value;
                    Invalidate();
                }
            }

            get
            {
                return (int)_values.High;
            }
        }

        public int Center
        {
            set
            {
                if (_values.Center != (float)value)
                {
                    _values.Center = (float)value;
                    Invalidate();
                }
            }

            get
            {
                return (int)_values.Center;
            }
        }

        public int Current
        {
            set
            {
                if (_values.Current != (float)value)
                {
                    _values.Current = (float)value;                    
                    Invalidate();
                }
            }

            get
            {
                return (int)_values.Current;
            }
        }
        
        public UC_ChannelMonitor()
        {
            InitializeComponent();
            DoubleBuffered = true;

            _values.Min = 700;
            _values.Max = 2300;

            _values.Low = 988;
            _values.High = 2012;
            _values.Center = 1500;
            _values.Current = 1500;
        }

        private Bitmap _bitmap;
        private Graphics _g;
        private void UC_ChannelMonitor_Paint(object sender, PaintEventArgs e)
        {
            if (_bitmap == null)
            {
                _bitmap = new Bitmap(Width, Height);
                _g = Graphics.FromImage(_bitmap);
            }        
            Brush white_brush = new SolidBrush(Color.White);

            _g.PageUnit = GraphicsUnit.Pixel;

            _g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            _g.FillRectangle(white_brush, -1, -1, Width, Height);
            
            Pen green_pen = new Pen(Color.Green, 2);
            Pen red_pen = new Pen(Color.Red, 2);
            Pen black_pen = new Pen(Color.FromArgb(255, 0, 0, 0), 1);
            Pen gray_pen = new Pen(Color.Gray, 1);
            Brush gray_brush = new SolidBrush(Color.Gray);

            // draw low
            float left = (float)((_values.Low - 700.0) / 1600.0) * Width;
            _g.FillRectangle(gray_brush, -1, -1, left, Height);

            // draw high
            left = (float)((_values.High - 700) / 1600.0) * Width;
            _g.FillRectangle(gray_brush, left + 2, -1, Width - left, Height);

            // draw center
            left = (float)((_values.Center - 700.0) / 1600.0) * Width;
            
            if(_values.Center == _values.Current)
                _g.DrawLine(green_pen, left, -1, left, Height);
            else
                _g.DrawLine(red_pen, left, -1, left, Height);

            // draw current
            if (_values.Current > 0)
            {
                left = (float)((_values.Current - 700.0) / 1600.0) * Width;
                _g.DrawRectangle(black_pen, left - 1, -1, 3, Height);
            }

            Graphics graphics = this.CreateGraphics();
            e.Graphics.DrawImage(_bitmap, 0, 0, Width, Height);
            
        }
    }
}
