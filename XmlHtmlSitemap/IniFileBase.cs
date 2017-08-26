using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace XmlHtmlSitemap
{
    abstract class IniFileBase
    {
        readonly string path;
        const int size = 1024;

        public IniFileBase(string filename)
        {
            string directory = Directory.GetCurrentDirectory();
            if (directory[directory.Length - 1] != '\\')
            {
                directory = directory + @"\";
            }
            path = directory + filename;
        }

        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileStringA")]
        extern static int GetPrivateProfileString(
            String lpSectName,
            String lpKeyName,
            String lpDefault,
            StringBuilder lpReturnedString,
            int nSize,
            String lpFileName);


        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileStringA")]
        extern static int WritePrivateProfileString(
            String lpSectName,
            String lpKeyName,
            String lpValue,
            String lpFileName);

        public abstract void LoadIni(string section);
        public abstract void SaveIni();

        protected string GetProperty(string section, string key, string defaultValue)
        {
            StringBuilder strBldr = new StringBuilder(size);

            GetPrivateProfileString(section, key, defaultValue, strBldr, size, path);
            return strBldr.ToString();
        }

        protected void SetProperty(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, path);
        }
    }
}
