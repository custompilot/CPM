using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomPilot.core.lib
{
    class NAvrdudeProgrammer : AvrdudeBase
    {
        public void doanloadFirmware(string firmwarePathname, string programmer)
        {
            _sp.PortName = programmer;
            _avg = "-v true -patmega32u4 -cavr109 -PORT -b115200 -D -Uflash:w:\"" + firmwarePathname + "\":r";
            _avg = @"-v - patmega32u4 - cusbasp - Pusb - e - Ulock:w: 0x3F:m - Uefuse:w: 0xcb:m - Uhfuse:w: 0xd8:m - Ulfuse:w: 0xff:m";
            _avg = @"-v - patmega32u4 - cusbasp - Pusb - e - Ulock:r: 0x3F:m - Uefuse:r: 0xcb:m - Uhfuse:w: 0xd8:m - Ulfuse:w: 0xff:m";
            _udloading = "uploading";
            _udPercent = 0.42f;

            // 
            Thread thread = new Thread(Thread_Avrdude);
            thread.Start();
        }

        private void startProgrammingMode()
        {

        }

        public void Thread_Avrdude()
        {
            startAvrdude(_sp.PortName);
        }
    }
}
