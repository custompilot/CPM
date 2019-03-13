using CustomPilot.core.lib;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomPilot.core
{
    class Serial
    {
        SerialPort _sp = new SerialPort();
        private int _step = 0;
        public byte[] DAT;
        public UInt16 CMD = 0;
        public UInt16 Size = 0;

        public struct s_comstack
        {
            public ECMD cmd;
            public byte[] data;

            public s_comstack(ECMD cmd, byte[] data)
            {
                this.cmd = cmd;
                this.data = data;
            }
        }

        private volatile List<s_comstack> _list_send = new List<s_comstack>();
        public void AddSend(ECMD cmd, byte[] data)
        {
            _list_send.Add(new s_comstack(cmd, data));
        }

        private volatile List<s_comstack> _list_recv = new List<s_comstack>();

        public bool IsOpen
        {
            get
            {
                return _sp.IsOpen;
            }
        }

        public List<s_comstack> Recv()
        {
            if (_list_recv.Count > 0)
            {
                List<s_comstack> recv = new List<s_comstack>();
                recv.Add(_list_recv.Last());
                _list_recv.Remove(_list_recv.Last());
                return recv;
            }
            return null;
        }

        public Serial()
        {
        }

        public void do_com()
        {  
            if (_sp.IsOpen)
            {
                if(_sp.BytesToRead > 0 && do_recv(_sp) > 0)
                {
                    /*
                    Console.Write(_sp.BytesToRead + "\t" + _sp.BytesToWrite + "\n");
                    
                    System.Console.Write("recv: " + _list_recv.Count);
                    System.Console.Write(" cmd: " + ((ECMD)CMD).ToString());
                    System.Console.WriteLine(" size: " + Size.ToString());
                    */

                    _list_recv.Add(new s_comstack((ECMD)CMD, DAT));
                }

                if (_list_send.Count > 0)
                {
                    Send(_sp, _list_send[0].cmd, _list_send[0].data);
                    /*
                    Console.Write(_sp.BytesToRead + "\t" + _sp.BytesToWrite + "\n");

                    Console.Write("send: " + _list_send.Count);
                    Console.Write(" cmd: " + _list_send[0].cmd.ToString());
                    Console.WriteLine(_list_send[0].data == null ? " size: 0" : " size: " + _list_send[0].data.Length.ToString());
                    */
                    _list_send.RemoveAt(0);
                }
            }

        }

        private int read_bytes(SerialPort sp, byte[] buf, int size)
        {
            if (sp.BytesToRead >= size)
            {
                sp.Read(buf, 0, size);
                return size;
            }
            else
                return 0;
        }

        public void Connect(int i)
        {
            _sp.DtrEnable = true;
            _sp.RtsEnable = true;
            _sp.ReadBufferSize = 1024;
            _sp.WriteBufferSize = 1024;
            _sp.PortName = COMPortInfo.GetCOMPortsInfo()[i].Name;
            _sp.BaudRate = 115200;
            try
            {
                _sp.Open();
            }
            catch 
            { }
        }

        private void Send(SerialPort sp, ECMD command, byte[] data)
        {
            if(command == ECMD.RADIO_PROTOCOL_SET)
            {
                Console.WriteLine("pset");
            }

            if (data == null)
                Send(sp, command, null, 0, 0);
            else
                Send(sp, command, data, 0, data.Length);
        }
        public void Send(SerialPort sp, ECMD command, byte[] data, int startidx, int length)
        {
            if (sp.IsOpen == false)
                return;

            byte[] packet;
            UInt16 size = (UInt16)length;
            UInt16 cmd = (UInt16)command;

            // {0: stx, 1: datasize, 3: command, 4:data, etx}
            if (data != null)
            {
                packet = new byte[6 + size];
                Array.Copy(data, startidx, packet, 5, size);
            }
            else
            {
                packet = new byte[6];
                size = 0;
            }

            // stx
            packet[0] = 0x02;
            // size
            packet[1] = BitConverter.GetBytes(size)[0];
            packet[2] = BitConverter.GetBytes(size)[1];

            // command
            packet[3] = BitConverter.GetBytes(cmd)[0];
            packet[4] = BitConverter.GetBytes(cmd)[1];

            // etx
            packet[size + 5] = 0x03;
            if (sp.IsOpen)
                sp.Write(packet, 0, packet.Length);
        }

        public void Close()
        {
            _sp.Close();
            _sp.Dispose();
        }

        public int do_recv(SerialPort sp)
        {
            switch (_step)
            {
                case 0:
                    // stx 읽기
                    byte[] stx = new byte[1];
                    if (read_bytes(sp, stx, 1) == 1 && stx[0] == 0x02)
                    {
                        _step++;
                        Size = 0;
                        goto case 1;
                    }
                    else if (sp.BytesToRead > 0)
                        goto case 0;
                    break;

                case 1:
                    // size 읽기
                    byte[] size = new byte[2];
                    if (read_bytes(sp, size, 2) == 2)
                    {
                        Size = BitConverter.ToUInt16(size, 0);
                        _step++;
                        goto case 2;
                    }
                    break;

                case 2:
                    // command 읽기
                    byte[] command = new byte[2];
                    if (read_bytes(sp, command, 2) == 2)
                    {
                        CMD = BitConverter.ToUInt16(command, 0);

                        if (Size > 0)
                        {
                            DAT = new byte[Size];
                            _step++;
                            goto case 3;
                        }
                        else
                        {
                            _step += 2;
                            goto case 4;
                        }
                    }
                    break;

                case 3:
                    // data 읽기
                    if (read_bytes(sp, DAT, Size) == Size)
                    {
                        _step++;
                        goto case 4;
                    }
                    break;
                case 4:
                    // etx 읽기
                    byte[] etx = new byte[1];
                    if (read_bytes(sp, etx, 1) == 1)
                    {
                        // step 초기화
                        _step = 0;
                        if (etx[0] == 0x03)
                        {
                            // 정상 패킷 도착
                            /*
                            if(DAT == null || Size == 0)
                                Console.WriteLine("packet recv - cmd: " + (int)CMD + " , size: " + Size + " , dat: " + "\n");
                            else
                                Console.WriteLine("packet recv - cmd: " + (int)CMD + " , size: " + Size + " , dat: " + System.Text.Encoding.Default.GetString(DAT) + "\n");
                                */
                            return CMD;
                        }
                        else
                        {
                            // 패킷 에러
                            Console.WriteLine("data parse Error:");
                            return -1;
                        }
                    }
                    break;
            }
            return 0;
        }
    }
}
