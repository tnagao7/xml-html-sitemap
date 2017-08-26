using System;
using System.Windows.Forms;

namespace XmlHtmlSitemap
{
    using XmlHtmlSitemap.Properties;

	partial class MainForm
	{
        private const string HelpDocumentLocation = @"doc\index.html";
        private const string HelpDocumentLocationJa = @"doc\index.ja.html";

        void InitializeMainMenu()
        {
            //
            // miFile
            //
            miExit = new MenuItem(Resources.String5);
            miExit.Click += (sender, eventArgs) =>
            {
                this.Close();
            };

            miFile = new MenuItem(Resources.String4);
            miFile.MenuItems.AddRange(new MenuItem[]
            {
                miExit
            });
           
            //
            // miOptions
            //
            miJapanese = new MenuItem(Resources.String17);
            miJapanese.Click += (sender, eventArgs) =>
            {
                if (!miJapanese.Checked)
                {
                    MessageBox.Show(Resources.String16, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Program.SetUICulture("ja-JP");
                }
            };

            miEnglish = new MenuItem(Resources.String18);
            miEnglish.Click += (sender, eventArgs) =>
            {
                if (!miEnglish.Checked)
                {
                    MessageBox.Show(Resources.String16, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Program.SetUICulture("en-US");
                }
            };

            miLanguage = new MenuItem("&Languages");
            miLanguage.MenuItems.AddRange(new MenuItem[] 
            {
                miEnglish, miJapanese, 
            });
            miLanguage.Popup += (sender, eventArgs) =>
            {
                miJapanese.Checked = miEnglish.Checked = false;
                switch (Program.GetUICulture())
                {
                    case "ja-JP":
                        miJapanese.Checked = true;
                        break;
                    default:
                        miEnglish.Checked = true;
                        break;
                }
            };

            miOptions = new MenuItem(Resources.String49);
            miOptions.MenuItems.AddRange(new MenuItem[]
            {
                miLanguage,
            });

            //
            // miHelp
            //
            miViewHelp = new MenuItem(Resources.String20);
            miViewHelp.Shortcut = Shortcut.F1;
            miViewHelp.Click += (sender, eventArgs) =>
            {
                try
                {
                    switch (Program.GetUICulture())
                    {
                        case "ja-JP":
                            System.Diagnostics.Process.Start(HelpDocumentLocationJa);
                            break;
                        default:
                            System.Diagnostics.Process.Start(HelpDocumentLocation);
                            break;
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, Resources.String8, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            miAbout = new MenuItem(Resources.String7);
            miAbout.Click += (sender, eventArgs) =>
            {
                using (AboutDialog dialog = new AboutDialog())
                {
                    dialog.ShowDialog();
                }
            };

            miHelp = new MenuItem(Resources.String6);
            miHelp.MenuItems.AddRange(new MenuItem[]
            {
                miViewHelp, miAbout
            });

            //
            // mainMenu
            //
            mainMenu = new MainMenu();
            mainMenu.MenuItems.AddRange(new MenuItem[]
            {
                miFile, miOptions,  miHelp
            });

            //
            // MainForm
            //
            this.Menu = mainMenu;
        }

        //
        // MainMenuItems
        //
        MenuItem miFile;
        MenuItem miExit;

        MenuItem miOptions;
        MenuItem miLanguage;
        MenuItem miJapanese;
        MenuItem miEnglish;

        MenuItem miHelp;
        MenuItem miViewHelp;
        MenuItem miAbout;

        MainMenu mainMenu;
	}
}