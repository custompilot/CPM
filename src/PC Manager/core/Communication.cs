using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomPilot.core
{
    enum ECMD
    {
        VERSION                 = 10000,
        DEVICENAME              = 10100,
        DEVICENAME_SET          = 10200,

        RADIO_RAW               = 20100,
        RADIO_PROTOCOL_SET      = 20200,        //data[01]  - protocol
        RADIO_CAL_SET           = 20400,
        
        EEPROM_RAW              = 30000,
        EEPROM_SET              = 30100,
        EEPROM_RADIO_ICH        = 30200,

        ROM_RAW                 = 35000,
        ROM_RESET               = 35100,

        SERVO_RAW               = 40100,
        SERVO_SET               = 40200,

        IMU_CAL                 = 50000,
        IMU_RESET               = 50100,

        LOOPTIME                = 60000,
        UNKNOWN                 = 60100,
        ERROR                   = 60200,

        DEBUG_WDT               = 61000,

        TMODE                   = 1100,
    }    

    public struct S_EEPROM
    {
        public struct s_channel
        {
            public UInt16 offset, min, max;
            public sbyte direction;
        }
        public struct s_trim_sources
        {
            public s_channel[] channels;
        }
        public struct s_trim
        {
            public s_trim_sources servo;
        }
        public struct s_calibratioin
        {
            public Int16[] accs, gyros;
        }
        public struct s_mount
        {
            public bool backward, reversed;
        }
        public struct s_mpu
        {
            public s_calibratioin calibration;
            public s_mount mount;
        }
        public struct s_servo
        {
            public byte[] och;
            public s_trim_sources trim;
        }
        public struct s_radio{
            public byte protocol;
            public byte[] ich;
            public s_channel trim;
        }
        public struct s_mode
        {
            public UInt16[] modes;
        }
        public struct s_plane
        {
            public UInt64 initialized;
            public UInt64 license;
            public byte []name64;
        }

        public s_radio radio;
        public s_servo servo;
        public s_mpu mpu;
        public s_plane plane;
        public s_mode mode;

        public void decode(byte[] buf)
        { 
            int offset = 0;

            radio.protocol = buf[offset++];

            // 1

            for (int i = 0; i < 10; i++)
                radio.ich[i] = buf[offset++];
            // 1 + 10 = 11
            
            radio.trim.offset = BitConverter.ToUInt16(buf, offset);
            offset += 2;
            radio.trim.min = BitConverter.ToUInt16(buf, offset);
            offset += 2;
            radio.trim.max = BitConverter.ToUInt16(buf, offset);
            offset += 2;
            radio.trim.direction = (sbyte)buf[offset];
            offset ++;
            // 7 + 11 = 18

            for (int i = 0; i < 12; i++)
                servo.och[i] = (byte)buf[offset++];
            // 12 + 18 = 30

            for (int i = 0; i < 12; i++)
            {
                servo.trim.channels[i].offset = BitConverter.ToUInt16(buf, offset);
                offset += 2;
                servo.trim.channels[i].min = BitConverter.ToUInt16(buf, offset);
                offset += 2;
                servo.trim.channels[i].max = BitConverter.ToUInt16(buf, offset);
                offset += 2;
                servo.trim.channels[i].direction = (sbyte)buf[offset];
                offset++;
            }
            // 7 * 12 = 84 + 30 = 114
            
            for (int i = 0; i < 3; i++)
            {
                mpu.calibration.accs[i] = BitConverter.ToInt16(buf, offset);
                offset += 2;
            }
            // 6 + 114 = 120

            for (int i = 0; i < 3; i++)
            {
                mpu.calibration.gyros[i] = BitConverter.ToInt16(buf, offset);
                offset += 2;
            }
            // 6 + 120 = 126

            mpu.mount.backward = BitConverter.ToBoolean(buf, offset++);
            mpu.mount.reversed = BitConverter.ToBoolean(buf, offset++);
            // 2 + 126 = 128

            for (int i = 0; i < 7; i++)
            {
                mode.modes[i] = BitConverter.ToUInt16(buf, offset);
                offset += 2;
            }
            // 14 + 128 = 142

            plane.initialized = BitConverter.ToUInt64(buf, offset);
            // 8 + 142 = 150
            offset += 8;

            plane.license = BitConverter.ToUInt64(buf, offset);
            offset += 8;
            // 8 + 150 = 158

            for (int i = 0; i < 32; i++)
                plane.name64[i] = buf[offset++];
            // 32 + 158 = 190
        }

        public byte[] encode()
        {
            byte[] buf = new byte[190];

            int offset = 0;
            
            buf[offset++] = radio.protocol;
            // 1            

            // input channel roles
            for (int i = 0; i < 10; i++)
                buf[offset++] = (byte)radio.ich[i];
            // 10 + 1 = 11
            
            buf[offset++] = BitConverter.GetBytes(radio.trim.offset)[0];
            buf[offset++] = BitConverter.GetBytes(radio.trim.offset)[1];

            buf[offset++] = BitConverter.GetBytes(radio.trim.min)[0];
            buf[offset++] = BitConverter.GetBytes(radio.trim.min)[1];

            buf[offset++] = BitConverter.GetBytes(radio.trim.max)[0];
            buf[offset++] = BitConverter.GetBytes(radio.trim.max)[1];

            buf[offset++] = BitConverter.GetBytes(radio.trim.direction)[0];
            // 7 + 11 = 18
            
            for(int i = 0; i < 12; i++)
                buf[offset++] = (byte)servo.och[i];
            // 12 + 18 = 30

            for (int i = 0; i < 12; i++)
            {
                buf[offset++] = BitConverter.GetBytes(servo.trim.channels[i].offset)[0];
                buf[offset++] = BitConverter.GetBytes(servo.trim.channels[i].offset)[1];

                buf[offset++] = BitConverter.GetBytes(servo.trim.channels[i].min)[0];
                buf[offset++] = BitConverter.GetBytes(servo.trim.channels[i].min)[1];

                buf[offset++] = BitConverter.GetBytes(servo.trim.channels[i].max)[0];
                buf[offset++] = BitConverter.GetBytes(servo.trim.channels[i].max)[1];

                buf[offset++] = BitConverter.GetBytes(servo.trim.channels[i].direction)[0];
            }

            // 7 * 12 = 84 + 30 = 114
            for (int i = 0; i < 3; i++)
            {
                // 2byte converter
                buf[offset++] = BitConverter.GetBytes(mpu.calibration.accs[i])[0];
                buf[offset++] = BitConverter.GetBytes(mpu.calibration.accs[i])[1];
            }

            // 6 + 114 = 120
            for (int i = 0; i < 3; i++)
            {
                buf[offset++] = BitConverter.GetBytes(mpu.calibration.gyros[i])[0];
                buf[offset++] = BitConverter.GetBytes(mpu.calibration.gyros[i])[1];
            }

            // 6 + 120 = 126
            buf[offset++] = BitConverter.GetBytes(mpu.mount.backward)[0];
            buf[offset++] = BitConverter.GetBytes(mpu.mount.reversed)[0];
            
            // 2 + 126 = 128
            for (int i = 0; i < 7; i++)
            {
                buf[offset++] = BitConverter.GetBytes(mode.modes[i])[0];
                buf[offset++] = BitConverter.GetBytes(mode.modes[i])[1];
            }

            // 14 + 128 = 142
            for (int i = 0; i < 8; i++)
                buf[offset++] = BitConverter.GetBytes(plane.initialized)[i];

            // 8 + 142 = 150
            for (int i = 0; i < 8; i++)
                buf[offset++] = BitConverter.GetBytes(plane.license)[i];

            // 8 + 150 = 158
            for (int i = 0; i < 32; i++)
                buf[offset++] = (byte)plane.name64[i];

            // 32 + 158 = 190
            return buf;
        }

        public enum ICH
        {
            THR = 0, AIL, ELE, RUD, AGAIN, EGAIN, FSRONE, MODE, MODEB, MODEC, NA = 255
        }

        public enum OCH
        {
            AIL1, ELE, THR, RUD, AIL2, VTAIL1, VTAIL2, ELEVON1, ELEVON2, CH01,
            CH02 = 10, CH03, CH04, CH05, CH06, CH07, CH08, CH09, CH10, CH11,
            CH12 = 20, CH13, CH14, CH15, CH16, NA = 255
        }

        public enum FLIGHTMODE
        {
            NA, MANUAL, STABILIZATION, TAKEOFF, HOVERING, REVERSE, KNIFEEDGE, STABILIZATION2
        }

        public void reset_ich()
        {
            radio.ich[(int)ICH.AIL]         = 0;
            radio.ich[(int)ICH.ELE]         = 1;
            radio.ich[(int)ICH.THR]         = 2;
            radio.ich[(int)ICH.RUD]         = 3;
            radio.ich[(int)ICH.MODE]        = 4;
            radio.ich[(int)ICH.AGAIN]       = 5;
            radio.ich[(int)ICH.EGAIN]       = 6;
            radio.ich[(int)ICH.FSRONE]      = (byte)ICH.NA;
            radio.ich[(int)ICH.MODEB]       = (byte)ICH.NA;
            radio.ich[(int)ICH.MODEC]       = (byte)ICH.NA;
            /*
            radio.ich[(int)ICH.CH01]        = (byte)ICH.NA;
            radio.ich[(int)ICH.CH02]        = (byte)ICH.NA;
            radio.ich[(int)ICH.CH03]        = (byte)ICH.NA;
            radio.ich[(int)ICH.CH04]        = (byte)ICH.NA;
            radio.ich[(int)ICH.CH05]        = (byte)ICH.NA;
            radio.ich[(int)ICH.CH06]        = (byte)ICH.NA;
            radio.ich[(int)ICH.CH07]        = (byte)ICH.NA;
            radio.ich[(int)ICH.CH08]        = (byte)ICH.NA;
            radio.ich[(int)ICH.CH09]        = (byte)ICH.NA;
            radio.ich[(int)ICH.CH10]        = 9;
            radio.ich[(int)ICH.CH11]        = 10;
            radio.ich[(int)ICH.CH12]        = 11;
            radio.ich[(int)ICH.CH13]        = 12;
            radio.ich[(int)ICH.CH14]        = 13;
            radio.ich[(int)ICH.CH15]        = 14;
            radio.ich[(int)ICH.CH16]        = 15;
            */
        }

        public void reset_och()
        {
            for (int i = 0; i < 12; i++)
            {
                if (i < 5)
                    servo.och[i] = (byte)i;
                else
                    servo.och[i] = (byte)(i + 11);
            }
        }
        public void reset_mode()
        {
            // mix mode reset to 0
            for (int i = 0; i < 7; i++)
                mode.modes[i] = (ushort)i;
        }

        public void reset()
        {
            radio.protocol = 0;
            reset_ich();

            radio.trim.direction = 1;
            radio.trim.max = 2012;
            radio.trim.min = 988;
            radio.trim.offset = 1500;

            for (int i = 0; i < 12; i++)
            {
                servo.trim.channels[i].direction = 1;
                servo.trim.channels[i].max = 2012;
                servo.trim.channels[i].min = 988;
                servo.trim.channels[i].offset = 1500;
            }

            reset_och();

            plane.initialized = Communication.Initializecode;
            plane.license = 0;

            for (int i = 0; i < 3; i++)
            {
                mpu.calibration.accs[i] = 0;
                mpu.calibration.gyros[i] = 0;
            }

            mpu.mount.reversed = false;
            mpu.mount.backward = false;

            reset_mode();

            plane.name64 = System.Text.Encoding.Unicode.GetBytes("CustomPilotMicro");
        }
    }

    class Communication
    {
        private Serial _serial = new Serial();
        public static S_EEPROM EEPROM = new S_EEPROM();
        public static UInt64 Initializecode;

        public Communication()
        {
            EEPROM.servo.trim.channels = new S_EEPROM.s_channel[12];
            EEPROM.servo.och = new byte[12];

            EEPROM.mpu.calibration.accs = new Int16[3];
            EEPROM.mpu.calibration.gyros = new Int16[3];

            EEPROM.radio.ich = new byte[10];
            EEPROM.plane.initialized = Initializecode;

            EEPROM.mode.modes = new UInt16[7];
            EEPROM.plane.name64 = new byte[32];
        }

        public void Do_comm()
        {
            _serial.do_com();
        }

        public bool IsOpen
        {
            get
            {
                return _serial.IsOpen;
            }
        }

        public void SerialConnect(int i)
        {
            _serial.Connect(i);
        }

        public void SerialStop()
        {
            _serial.Close();
        }

        public void SerialSend(ECMD cmd)
        {
            SerialSend(cmd, null);
        }
        public void SerialSend(ECMD cmd, byte[] dat)
        {
            _serial.AddSend(cmd, dat);
        }
        public List<Serial.s_comstack> Recv()
        {
            return _serial.Recv();
        }
    }
}
