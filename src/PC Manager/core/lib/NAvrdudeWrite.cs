using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPilot.core.lib
{
    class NAvrdudeWrite: AvrdudeBase
    {
        public void UploadFirmware(string portName, string firmwarePath)
        {
            _sp.PortName = portName;
            _avg = "-v true -patmega32u4 -cavr109 -PORT -b115200 -D -Uflash:w:\"" + firmwarePath + "\":r";
            _udloading = "uploading";
            _udPercent = 0.42f;

            State = ESTATE.DOING;
            Find_bootloader_port();
        }
    }
}
