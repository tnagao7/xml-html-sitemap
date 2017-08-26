using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace XmlHtmlSitemap
{
    using XmlHtmlSitemap.Properties;

    public partial class MainForm : Form
    {
        private const string IniFileName = "settings.ini";
        private IniFile iniFile;

        public MainForm()
        {
            iniFile = new IniFile(IniFileName, this);
            iniFile.LoadIni("Lang");

            InitializeComponent();
            InitializeEncoding();
            InitializeMainMenu();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            iniFile.LoadIni("Main");
            cbGenerateXmlFile_CheckedChanged(sender, e);
            cbGenerateHtmlFile_CheckedChanged(sender, e);
            cbUseLocal_CheckedChanged(sender, e);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            iniFile.SaveIni();
        }

        private void InitializeEncoding()
        {
            comboBoxEncoding.Items.Add(Resources.String42);
            List<EncodingInfo> encInfoList = new List<EncodingInfo>();
            encInfoList.AddRange(Encoding.GetEncodings());
            encInfoList.Sort((EncodingInfo a, EncodingInfo b) =>
            {
                return string.Compare(a.GetEncoding().WebName, b.GetEncoding().WebName);
            });
            foreach (EncodingInfo encInfo in encInfoList)
            {
                comboBoxEncoding.Items.Add(encInfo.GetEncoding().WebName);
            }
        }

        private void btnBrouseDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog()
            {
                Description = Resources.String43,
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.DestinationFolder = dialog.SelectedPath;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            this.ExecuteSitemapGeneration();
        }

        private void cbLastModification_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxLastModification.Enabled = cbLastModification.Enabled && cbLastModification.Checked;
            dateTimePicker.Enabled = cbLastModification.Enabled && cbLastModification.Checked && comboBoxLastModification.SelectedIndex == 1;
        }

        private void cbChangeFrequency_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxChangeFrequency.Enabled = cbChangeFrequency.Enabled && cbChangeFrequency.Checked;
        }

        private void cbPriority_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxPriority.Enabled = cbPriority.Enabled && cbPriority.Checked;
        }

        private void comboBoxLastModified_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePicker.Enabled = cbLastModification.Checked && comboBoxLastModification.SelectedIndex == 1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbGenerateXmlFile_CheckedChanged(object sender, EventArgs e)
        {
            cbChangeFrequency.Enabled = cbLastModification.Enabled = cbPriority.Enabled = cbGenerateXmlFile.Checked;
            btnRun.Enabled = GenerateHtmlFile || GenerateXmlFile;
        }

        private void cbChangeFrequency_EnabledChanged(object sender, EventArgs e)
        {
            cbChangeFrequency_CheckedChanged(sender, e);
        }

        private void cbPriority_EnabledChanged(object sender, EventArgs e)
        {
            cbPriority_CheckedChanged(sender, e);
        }

        private void cbLastModification_EnabledChanged(object sender, EventArgs e)
        {
            cbLastModification_CheckedChanged(sender, e);
        }

        private void cbGenerateHtmlFile_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxPageTitle.Enabled = cbGenerateHtmlFile.Checked;
            btnRun.Enabled = GenerateHtmlFile || GenerateXmlFile;
            lbPageTitle.Enabled = cbGenerateHtmlFile.Checked;
        }

        private void cbUseLocal_CheckedChanged(object sender, EventArgs e)
        {
            lbLocalPath.Enabled = cbUseLocal.Checked;
            tbLocalPath.Enabled = cbUseLocal.Checked;
            btnBrowseLocalPath.Enabled = cbUseLocal.Checked;
        }

        private void btnBrowseLocalPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "*.html;*.htm;*.shtml;*.php;*.cgi|*.html;*.htm;*.shtml;*.php;*.cgi|*.*|*.*";

            if (Directory.Exists(LocalPath))
            {
                dialog.InitialDirectory = Path.GetDirectoryName(LocalPath);
                dialog.FileName = Path.GetFileName(LocalPath);
            }
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbLocalPath.Text = dialog.FileName;
            }
        }
    }
}
