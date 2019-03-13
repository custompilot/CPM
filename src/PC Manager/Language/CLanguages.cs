using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomPilot.Language
{
    static class CLanguages
    {
        public class scountry
        {
            public string Name { set; get; }
            public string Filename { set; get; }
            public string Code { set; get; }

            public scountry(string name, string code, string filename)
            {
                Name = name;
                Filename = filename;
                Code = code;
            }
        }

        private class slines
        {
            public string Text { get; set; } 
            public string Key { get; set; }
            public string Value { get; set; }

            public slines(string text, string key, string value)
            {
                Text = text;
                Key = key;
                Value = value;
            }
        }

        //https://msdn.microsoft.com/en-us/library/ee825488(v=cs.20).aspx
        static public List<scountry> Languages = new List<scountry> { new scountry("한국어", "ko-KR", "ko-KR.csv"), new scountry("English", "en-US", "en-US.csv") };
        static private List<slines>_lines = new List<slines>();

        static public void SetLanguage(int idx)
        {
            if(idx < Languages.Count)
            {
                string pathname = Application.StartupPath + "\\Language\\" + Languages[idx].Filename;
                OpenFile(pathname);
            }
        }

        static private void OpenFile(String filename)
        {
            _lines.Clear();
            foreach(string line in File.ReadLines(filename, System.Text.Encoding.Default))
            {
                string[] words = line.Split(',');
                _lines.Add(new slines(line, words[0], words[1]));
            }
        }

        static public string GetTranslate(string key)
        {
            try
            {
                string value = _lines.Find(x => x.Key == key).Value;
                return value;
            }
            catch
            {
                return "";
            }
        }
    }
}
