using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPilot.core.lib
{
    class NTimer
    {
        private DateTime _preTime;
        private double _span;
        public NTimer(float span)
        {
            _preTime = DateTime.Now;
            _span = span / 1000.0f;
        }

        public bool IsTime
        {
            get
            {
                DateTime now = DateTime.Now;
                TimeSpan span = now - _preTime;

                if (span.TotalMilliseconds > _span)
                {
                    _preTime = now;
                    return true;
                }
                else
                    return false;
            }
        }
    }
}
