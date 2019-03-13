using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CustomPilot.Language
{
    public class LanguageManager
    {
        public static void SetLanguage(CultureInfo culture)
        {
            Languages.Culture = culture;
        }
    }

    public struct CLanguages
    {
        public const string KOREAN = "한국어";
        public const string ENGLISH = "English";
        public const string JAPANESS = "日本語";

        public static string[] GetByArray()
        {
            return new string[] { KOREAN, ENGLISH, JAPANESS };
        }

        public static CultureInfo GetLanguageCulture(string lang)
        {
            switch (lang)
            {
                case KOREAN:
                    return new CultureInfo("ko-KR");

                case ENGLISH:
                    return new CultureInfo("en-US");

                default:
                    return new CultureInfo("en-US");
            }
        }
    }
}
