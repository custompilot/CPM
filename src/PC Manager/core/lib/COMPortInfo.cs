//https://dariosantarelli.wordpress.com/2010/10/18/c-how-to-programmatically-find-a-com-port-by-friendly-name/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomPilot.core.lib
{
    public class COMPortInfo
    {
        internal class ProcessConnection
        {

            public static ConnectionOptions ProcessConnectionOptions()
            {
                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = ImpersonationLevel.Impersonate;
                options.Authentication = AuthenticationLevel.Default;
                options.EnablePrivileges = true;
                return options;
            }

            public static ManagementScope ConnectionScope(string machineName, ConnectionOptions options, string path)
            {
                ManagementScope connectScope = new ManagementScope();
                connectScope.Path = new ManagementPath(@"\\" + machineName + path);
                connectScope.Options = options;
                connectScope.Connect();
                return connectScope;
            }
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public COMPortInfo() { }

        private static List<COMPortInfo> _comPortInfoList = new List<COMPortInfo>();
        public static List<COMPortInfo> GetCOMPortsInfo()
        {
            return _comPortInfoList;
        }

        public static List<COMPortInfo> GetCOMPortsDirect()
        {
            
            List<COMPortInfo> list = new List<COMPortInfo>();
            /*
            ConnectionOptions options = ProcessConnection.ProcessConnectionOptions();
            ManagementScope connectionScope = ProcessConnection.ConnectionScope(Environment.MachineName, options, @"\root\CIMV2");

            ObjectQuery objectQuery = new ObjectQuery("SELECT * FROM Win32_PnPEntity WHERE ConfigManagerErrorCode = 0");
            ManagementObjectSearcher comPortSearcher = new ManagementObjectSearcher(connectionScope, objectQuery);

            int i = 0;

            using (comPortSearcher)
            {
                string caption = null;
                
                foreach (ManagementObject obj in comPortSearcher.Get())
                {
                    i++;
                    if (obj != null)
                    {
                        object captionObj = obj["Caption"];
                        if (captionObj != null)
                        {
                            caption = captionObj.ToString();
                            if (caption.Contains("(COM"))
                            {
                                COMPortInfo comPortInfo = new COMPortInfo();
                                comPortInfo.Name = caption.Substring(caption.LastIndexOf("(COM")).Replace("(", string.Empty).Replace(")",
                                                                        string.Empty);
                                comPortInfo.Description = caption;
                                list.Add(comPortInfo);
                            }
                        }
                    }
                }
            }*/

            var instances = new ManagementClass("Win32_SerialPort").GetInstances();
            foreach (ManagementObject port in instances)
            {
                COMPortInfo c = new COMPortInfo();
                c.Description = (string)port["name"];
                c.Name = (string)port["deviceid"];
                list.Add(c);
                Console.WriteLine("{0}: {1}", port["deviceid"], port["name"]);
            }

            return list;
        }
        
        public static void Refresh_Devices()
        {
            Thread newThread = new Thread(COMPortInfo.Thread_Devices);
            newThread.Start();
        }

        public static void Thread_Devices()
        {
            _comPortInfoList.Clear();
            
            /*
            ConnectionOptions options = ProcessConnection.ProcessConnectionOptions();
            ManagementScope connectionScope = ProcessConnection.ConnectionScope(Environment.MachineName, options, @"\root\CIMV2");

            ObjectQuery objectQuery = new ObjectQuery("SELECT * FROM Win32_PnPEntity WHERE ConfigManagerErrorCode = 0");
            ManagementObjectSearcher comPortSearcher = new ManagementObjectSearcher(connectionScope, objectQuery);

            using (comPortSearcher)
            {
                string caption = null;
                foreach (ManagementObject obj in comPortSearcher.Get())
                {
                    if (obj != null)
                    {
                        object captionObj = obj["Caption"];
                        if (captionObj != null)
                        {
                            caption = captionObj.ToString();
                            if (caption.Contains("(COM"))
                            {
                                COMPortInfo comPortInfo = new COMPortInfo();
                                comPortInfo.Name = caption.Substring(caption.LastIndexOf("(COM")).Replace("(", string.Empty).Replace(")",
                                                                        string.Empty);
                                comPortInfo.Description = caption;
                                _comPortInfoList.Add(comPortInfo);
                            }
                        }
                    }
                }
            }//*/

            var instances = new ManagementClass("Win32_SerialPort").GetInstances();
            foreach (ManagementObject port in instances)
            {
                COMPortInfo c = new COMPortInfo();
                c.Description = (string)port["name"];
                c.Name = (string)port["deviceid"];
                _comPortInfoList.Add(c);
                Console.WriteLine("{0}: {1}", port["deviceid"], port["name"]);
            }

            if (OnComRefreshed != null)
                OnComRefreshed(null, null);
        }
        

        static private BackgroundWorker _bw = new BackgroundWorker();
        static public event EventHandler OnComRefreshed;
    }
}
