using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace System
{
    public static class __Proxy
    {
        public static String ToLocalized(this String input, String @default = null)
        {
            var language = HttpContext.Current.Request.Cookies["language"];

            var english = HoloXPLOR.Data.INI.English.Localization.GetValue(input ?? String.Empty, input);
            if (String.IsNullOrWhiteSpace(english) || english.Equals("<-=MISSING=->", StringComparison.InvariantCultureIgnoreCase)) english = @default;
            if (String.IsNullOrWhiteSpace(english) || english.Equals("<-=MISSING=->", StringComparison.InvariantCultureIgnoreCase)) english = input;

            if (language != null)
            {
                switch (language.Value)
                {
                    case "de":
                        var german = HoloXPLOR.Data.INI.German.Localization.GetValue(input ?? String.Empty, english);
                        if (String.IsNullOrWhiteSpace(german) || german.Equals("<-=MISSING=->", StringComparison.InvariantCultureIgnoreCase)) german = english;
                        return german;
                    case "fr":
                        var french = HoloXPLOR.Data.INI.French.Localization.GetValue(input ?? String.Empty, english);
                        if (String.IsNullOrWhiteSpace(french) || french.Equals("<-=MISSING=->", StringComparison.InvariantCultureIgnoreCase)) french = english;
                        return french;
                }
            }
            
            return english;
        }
    }
}

namespace HoloXPLOR.Data.INI
{
    public static class English
    {
        private static Object _localizationLock = new Object();
        private static Dictionary<String, String> _localization;
        public static Dictionary<String, String> Localization
        {
            get
            {
                if (English._localization == null)
                {
                    lock (_localizationLock)
                    {
                        if (English._localization == null)
                        {
                            var buffer = new Dictionary<String, String>(StringComparer.InvariantCultureIgnoreCase)
                            {

                            };

                            DirectoryInfo languageDir = new DirectoryInfo(HttpContext.Current.Server.MapPath(@"~/App_Data/English"));

                            foreach (FileInfo file in languageDir.GetFiles("*.ini", SearchOption.AllDirectories))
                            {
                                Regex iniParser = new Regex("^([^=]+)=(.*)$");

                                foreach (var line in File.ReadAllLines(file.FullName))
                                {
                                    var match = iniParser.Match(line);
                                    buffer[match.Groups[1].Value] = match.Groups[2].Value;
                                }
                            }

                            English._localization = buffer;

                            return English._localization;
                        }
                    }
                }

                return English._localization;
            }
        }
    }

    public static class French
    {
        private static Object _localizationLock = new Object();
        private static Dictionary<String, String> _localization;
        public static Dictionary<String, String> Localization
        {
            get
            {
                if (French._localization == null)
                {
                    lock (_localizationLock)
                    {
                        if (French._localization == null)
                        {
                            var buffer = new Dictionary<String, String>(StringComparer.InvariantCultureIgnoreCase) { };

                            DirectoryInfo languageDir = new DirectoryInfo(HttpContext.Current.Server.MapPath(@"~/App_Data/French"));

                            foreach (FileInfo file in languageDir.GetFiles("*.ini", SearchOption.AllDirectories))
                            {
                                Regex iniParser = new Regex("^([^=]+)=(.*)$");

                                foreach (var line in File.ReadAllLines(file.FullName))
                                {
                                    var match = iniParser.Match(line);
                                    buffer[match.Groups[1].Value] = match.Groups[2].Value;
                                }
                            }

                            French._localization = buffer;

                            return French._localization;
                        }
                    }
                }

                return French._localization;
            }
        }
    }

    public static class German
    {
        private static Object _localizationLock = new Object();
        private static Dictionary<String, String> _localization;
        public static Dictionary<String, String> Localization
        {
            get
            {
                if (German._localization == null)
                {
                    lock (_localizationLock)
                    {
                        if (German._localization == null)
                        {
                            var buffer = new Dictionary<String, String>(StringComparer.InvariantCultureIgnoreCase) { };

                            DirectoryInfo languageDir = new DirectoryInfo(HttpContext.Current.Server.MapPath(@"~/App_Data/German"));

                            foreach (FileInfo file in languageDir.GetFiles("*.ini", SearchOption.AllDirectories))
                            {
                                Regex iniParser = new Regex("^([^=]+)=(.*)$");

                                foreach (var line in File.ReadAllLines(file.FullName))
                                {
                                    var match = iniParser.Match(line);
                                    buffer[match.Groups[1].Value] = match.Groups[2].Value;
                                }
                            }

                            German._localization = buffer;

                            return German._localization;
                        }
                    }
                }

                return German._localization;
            }
        }
    }
}
