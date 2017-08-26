using System;
using System.Text;

namespace XmlHtmlSitemap
{
    class IniFile : IniFileBase
    {
        private MainForm caller;

        public IniFile(string filename, MainForm caller)
            : base(filename)
        {
            this.caller = caller;
        }

        public override void LoadIni(string section)
        {
            string value;

            if (section == secMain)
            {
                value = GetProperty(secMain, keyTop, "60");
                caller.Top = int.Parse(value);

                value = GetProperty(secMain, keyLeft, "40");
                caller.Left = int.Parse(value);

                value = GetProperty(secMain, keyFilter, "*.gif;*.png;*.jpg");
                caller.Filter = value;

                value = GetProperty(secMain, keyURL, "http://");
                caller.URL = value;

                value = GetProperty(secMain, keyGenerateXmlFile, "1");
                caller.GenerateXmlFile = value != "0";

                value = GetProperty(secMain, keyGenerateHtmlFile, "1");
                caller.GenerateHtmlFile = value != "0";

                value = GetProperty(secMain, keyIncludeNotFoundFiles, "0");
                caller.IncludeNotFoundFiles = value != "0";

                value = GetProperty(secMain, keyFileLocation, Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                caller.DestinationFolder = value;

                value = GetProperty(secMain, keyChangeFrequency, "0");
                caller.ChangeFrequency = (ChangeFrequency)int.Parse(value);

                value = GetProperty(secMain, keyPriority, "0");
                caller.Priority = (Priority)int.Parse(value);

                value = GetProperty(secMain, keyLastModification, "0");
                caller.LastModification = (LastModification)int.Parse(value);

                value = GetProperty(secMain, keyPageTitle, "0");
                caller.PageTitle = (PageTitle)int.Parse(value);

                value = GetProperty(secMain, keyEncoding, "0");
                caller.Encoding = (int.Parse(value) == 0) ? null : Encoding.GetEncoding(int.Parse(value));

                value = GetProperty(secMain, keyFromLocal, "0");
                caller.FromLocalFiles = value != "0";

                value = GetProperty(secMain, keyLocalPath, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "index.html"));
                caller.LocalPath = value;
            }
            else if (section == secLang)
            {
                value = GetProperty(secLang, keyUICulture, "Neutral");
                if (value == "ja-JP" || value == "en-US")
                {
                    Program.SetUICulture(value);
                    Program.SetCulture(value);
                }
                // else, follow the environment
            }
        }

        public override void SaveIni()
        {
            string value;

            if (caller.WindowState == System.Windows.Forms.FormWindowState.Normal)
            {
                value = caller.Top.ToString();
                SetProperty(secMain, keyTop, value);

                value = caller.Left.ToString();
                SetProperty(secMain, keyLeft, value);
            }

            value = caller.Filter;
            SetProperty(secMain, keyFilter, value);

            value = caller.URL;
            SetProperty(secMain, keyURL, value);

            value = caller.DestinationFolder;
            SetProperty(secMain, keyFileLocation, value);

            value = caller.GenerateXmlFile ? "1" : "0";
            SetProperty(secMain, keyGenerateXmlFile, value);

            value = caller.GenerateHtmlFile ? "1" : "0";
            SetProperty(secMain, keyGenerateHtmlFile, value);

            value = caller.IncludeNotFoundFiles ? "1" : "0";
            SetProperty(secMain, keyIncludeNotFoundFiles, value);

            value = ((int)caller.ChangeFrequency).ToString();
            SetProperty(secMain, keyChangeFrequency, value);

            value = ((int)caller.Priority).ToString();
            SetProperty(secMain, keyPriority, value);

            value = ((int)caller.LastModification).ToString();
            SetProperty(secMain, keyLastModification, value);

            value = ((int)caller.PageTitle).ToString();
            SetProperty(secMain, keyPageTitle, value);

            value = (caller.Encoding == null) ? "0" : caller.Encoding.CodePage.ToString();
            SetProperty(secMain, keyEncoding, value);

            value = Program.GetUICulture();
            SetProperty(secLang, keyUICulture, value);

            value = caller.FromLocalFiles ? "1" : "0";
            SetProperty(secMain, keyFromLocal, value);

            value = caller.LocalPath;
            SetProperty(secMain, keyLocalPath, value);
        }

        string secMain = "Main";
        string keyTop = "Top";
        string keyLeft = "Left";
        string keyFilter = "Filter";
        string keyChangeFrequency = "ChangeFrequency";
        string keyPriority = "Priority";
        string keyLastModification = "LastModification";
        string keyEncoding = "Encoding";
        string keyURL = "URL";
        string keyFileLocation = "FileLocation";
        string keyGenerateXmlFile = "GenerateXmlFile";
        string keyGenerateHtmlFile = "GenerateHtmlFile";
        string keyIncludeNotFoundFiles = "IncludeNotFoundFiles";
        string keyPageTitle = "PageTitle";
        string keyFromLocal = "FromLocal";
        string keyLocalPath = "LocalPath";

        string secLang = "Lang";
        string keyUICulture = "UICulture";
    }
}
