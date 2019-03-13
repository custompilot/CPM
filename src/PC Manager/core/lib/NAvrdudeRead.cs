using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomPilot.core.lib
{
    class NAvrdudeRead: AvrdudeBase
    {   
        public void DownloadFirmware(string portName, string firmwarePathname)
        {
            _sp.PortName = portName;
            _avg = "-v true -patmega32u4 -cavr109 -PORT -b115200 -D -Uflash:r:\"" + firmwarePathname + "\":r";
            _udloading = "downloading";
            _udPercent = 0.7f;

            State = ESTATE.DOING;
            Find_bootloader_port();
        }  
    }
}
