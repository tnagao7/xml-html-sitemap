using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using XmlHtmlSitemap.Properties;

namespace XmlHtmlSitemap
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();

            // label1
            //
            AssemblyName assemblyName = Assembly.GetExecutingAssembly().GetName();
            string sVersion = string.Format("{0}.{1}.{2}", Program.VersionMajor, Program.VersionMinor, Program.VersionBuild);
            label1.Text = Program.Title.Replace("&", "&&") + " " + sVersion;
            //
            // label2
            //
            label2.Text = Program.Copyright;
            //
            // linkLabel1
            //
            linkLabel1.Text = "Visit the project website";
            linkLabel1.LinkClicked += (object sender, LinkLabelLinkClickedEventArgs eventArgs) =>
            {
                linkLabel1.LinkVisited = true;
                System.Diagnostics.Process.Start(Resources.URL);
            };
            //
            // pbIcon
            //
            pbIcon.Image = new Icon(Resources.ProgramIcon, pbIcon.Size).ToBitmap();
        }

    }
}
