using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPilot.core
{
    class FileIO
    {
        public void SaveEEPROMDATA(string pathname)
        {
            using (BinaryWriter b = new BinaryWriter(File.Open(pathname, FileMode.Create)))
            {
                b.Write(Communication.EEPROM.encode());
            }
        }

        public byte[] LoadEEPROMDATA(string pathname)
        {
            using (BinaryReader b = new BinaryReader(File.Open(pathname, FileMode.Open)))
            {
                int length = (int)b.BaseStream.Length;
                return b.ReadBytes(length);
            }
        }
    }
}