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
    public class AvrdudeBase
    {
        public enum ESTATE
        {
            WAIT, DOING, COMPLETE
        }

        protected SerialPort _sp = new SerialPort();
        protected string _bootloaderPortName = "";
        protected List<String> _consoles = new List<string>();
        protected Process _avrdude = new Process();
        private string StrConsole = "";
        protected String _udloading = "";
        private int _percent = 0;
        public String ConsoleRead { get; set; }
        protected String _avg;
        protected float _udPercent = 0.5f;
        public ESTATE State = ESTATE.WAIT;

        public AvrdudeBase()
        {
            _sp.BaudRate = 1200;
        }

        static List<COMPortInfo> _ports = new List<COMPortInfo>();
                
        protected List<COMPortInfo> update_ports()
        {
            _ports.Clear();
            Thread t1 = new Thread(new ThreadStart(Run));
            t1.Start();

            DateTime st = DateTime.Now;

            TimeSpan ts;
            do
            {
                System.Threading.Thread.Sleep(10);
                ts = DateTime.Now - st;
            } while (ts.TotalSeconds < 1 && _ports.Count == 0);

            t1.Abort();

            //Console.Write("{");
            //foreach (COMPortInfo com in ports)
            //{
            //Console.Write(com.Name);
            //Console.Write(", ");
            //}
            //Console.WriteLine("}");

            return _ports;
        }

        void Run()
        {
            lock (_ports)
            {
                _ports = COMPortInfo.GetCOMPortsDirect();
            }
        }

        protected void Find_bootloader_port()
        {
            raiseEvent("rebooting", 0);
            Thread thread = new Thread(Thread_StartBootloader);
            thread.Start();
        }

        // thread start
        private void Thread_StartBootloader()
        {
            //Thread.Sleep(1000);
            raiseEvent("port scan", 5, "a");
            DateTime sTime = DateTime.Now;

            // 현재 포트 리스트 작성
            List<COMPortInfo> prePorts = update_ports();
            List<COMPortInfo> ports;

            //Thread.Sleep(1000);
            raiseEvent("reboot", 10, "b");
            _sp.Close();
            _sp.Open();
            //System.Threading.Thread.Sleep(100);
            //_sp.Close();
            bool isExist = false;

            DateTime stime = DateTime.Now;
            TimeSpan ts;
            bool isNull = true;

            // 기존 포트 있을 동안 대기하기
            do
            {
                System.Threading.Thread.Sleep(200);
                ts = DateTime.Now - stime;

                if (ts.TotalSeconds >= 10)
                {
                    State = ESTATE.COMPLETE;
                    EventArgs_StateChanged e = new EventArgs_StateChanged();
                    e.message = "Port not found.";

                    Thread.Sleep(100);
                    OnError(this, e);
                    return;
                }

                isExist = false;
                foreach (COMPortInfo com in update_ports())
                {
                    isNull = false;
                    //Console.WriteLine(com.Name);
                    if (com.Name == _sp.PortName)
                        isExist = true;
                }
            } while (isExist || isNull);

            //Thread.Sleep(1000);
            raiseEvent("reboot", 15, "d");

            // 새로운 포트 찾기
            do
            {
                System.Threading.Thread.Sleep(10);
                ports = update_ports();
                _percent++;
            } while (ports.Count < prePorts.Count);

            //Thread.Sleep(1000);
            raiseEvent("finding", 20, "e");
            foreach (COMPortInfo com in ports)
            {
                _percent++;
                bool found = false;
                foreach (COMPortInfo preCom in prePorts)
                {
                    if (com.Name == preCom.Name)
                    {
                        found = true;
                        break;
                    }
                }

                // 추정 포트 찾음
                if (found == false)
                {
                    startAvrdude(com.Name);
                    return;
                }
            }
        }
        
        protected void startAvrdude(String portName)
        {
            //Thread.Sleep(1000);
            raiseEvent(_udloading, 25, "f");
            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath);
            _avrdude.StartInfo.FileName = dir.FullName + "\\avrdude.exe";
            _avrdude.StartInfo.Arguments = _avg.Replace("-PORT", "-P" + portName);
            //_avrdude.StartInfo.Arguments = _avg.Replace("115200", "57600");
            //_avrdude.StartInfo.Arguments += " >> log.txt";
            //"avrdude -p atmega32u4 -cavr109 -P" + portName + " -b57600 -e -U flash:" + _args + ":\"" + _firmwarePath + "\"" + _args2;
            Console.WriteLine(_avrdude.StartInfo.Arguments);
            _avrdude.StartInfo.UseShellExecute = false;
            _avrdude.StartInfo.RedirectStandardOutput = true;
            _avrdude.StartInfo.RedirectStandardError = true;
            _avrdude.StartInfo.CreateNoWindow = true;

            if (_avrdude.Start())
            {
                raiseEvent(_udloading, 30, "g");
                consoleRead();
            }
        }

        private void raiseEvent(String state, int percent, String message = "")
        {
            if (percent > 100)
            {
                Console.Write(percent);
                percent = 100;
            }

            _percent = percent;

            if(OnStateChanged != null)
            {
                EventArgs_StateChanged e = new EventArgs_StateChanged();
                e.percent = percent;
                e.State = state;
                e.message = message;
                OnStateChanged(this, e);
            }
        }

        private void consoleRead()
        {
            StrConsole = "";
            float pc = 30.0f;
            DateTime _pre = DateTime.Now;

            while (_avrdude.HasExited == false)
            {
                int c = 0;
                do
                {
                    //StrConsole += (char)c;
                    StrConsole += (char)c;

                    c = _avrdude.StandardError.Read();
                    //Console.Write((char)c);

                    if (c < 0)
                        System.Threading.Thread.Sleep(1);
                    else
                    {
                        if ((char)c == '#')
                            pc = pc + _udPercent;

                        //Console.WriteLine(pc);

                        raiseEvent(_udloading, (int)pc);

                        TimeSpan sp = DateTime.Now - _pre;
                        if (OnConsoleReceived != null && sp.TotalMilliseconds >= 10)
                        {
                            EventArgs_ConsoleRead ea = new EventArgs_ConsoleRead();
                            ea.DataRead = StrConsole;
                            StrConsole = "";
                            OnConsoleReceived(this, ea);
                        }
                    }
                } while (c >= 0);
            }

            raiseEvent("done", 100, "h");

            State = ESTATE.COMPLETE;
            if (OnFirmwareDownloadComplete != null)
                OnFirmwareDownloadComplete(this, null);
        }

        public event EventHandler OnFirmwareDownloadComplete;
        public event EventHandler OnStateChanged;
        public event EventHandler OnConsoleReceived;
        public event EventHandler OnError;
    }

    public class EventArgs_BootloaderPortFound : EventArgs
    {
        public String PortName { get; set; }
        public int state { get; set; }
    }

    public class EventArgs_StateChanged : EventArgs
    {
        public String State { get; set; }
        public int percent;
        public String message;
    }

    public class EventArgs_ConsoleRead : EventArgs
    {
        public String DataRead { get; set; }
    }
}
