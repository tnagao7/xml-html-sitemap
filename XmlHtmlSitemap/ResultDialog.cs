using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace XmlHtmlSitemap
{
    public partial class ResultDialog : Form
    {
        public string MainMessage
        {
            get { return lbMessage.Text; }
            set { lbMessage.Text = value; }
        }

        public string Details
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public string Directory { get; set; }
        public new Icon Icon { get; set; }
        public SystemSound Sound { get; set; } 

        public ResultDialog()
        {
            InitializeComponent();
            MainMessage = string.Empty;
            Details = string.Empty;
            Directory = null;
            Icon = SystemIcons.Information;
            Sound = SystemSounds.Asterisk;
        }

        private void ResultDialog_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawIcon(this.Icon, 15, 10);
        }

        private void ResultDialog_Load(object sender, EventArgs e)
        {
            if (Directory == null)
            {
                btnOpenFolder.Enabled = false;
            }

            this.Sound.Play();
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(this.Directory);
        }
    }
}
