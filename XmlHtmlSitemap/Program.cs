using System;
using System.Windows.Forms;
using System.Reflection;

namespace XmlHtmlSitemap
{
    class Program
    {
        public static string Title { get; set; }
        public static string Copyright { get; set; }
        public static int VersionMajor { get; set; }
        public static int VersionMinor { get; set; }
        public static int VersionBuild { get; set; }

        static Program()
        {
            Title = ((AssemblyTitleAttribute) Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyTitleAttribute))).Title;
            Copyright = ((AssemblyCopyrightAttribute) Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyCopyrightAttribute))).Copyright;

            VersionMajor = Assembly.GetExecutingAssembly().GetName().Version.Major;
            VersionMinor = Assembly.GetExecutingAssembly().GetName().Version.Minor;
            VersionBuild = Assembly.GetExecutingAssembly().GetName().Version.Build;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }

        public static void SetUICulture(string culture)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);
        }

        public static void SetCulture(string culture)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
        }

        public static string GetUICulture()
        {
            return System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
        }
    }
}
