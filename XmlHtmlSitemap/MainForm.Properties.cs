using System;
using System.Windows.Forms;
using System.Text;

namespace XmlHtmlSitemap
{
    public enum Language
    {
        English,
        Japanese,
    }

    partial class MainForm
	{
        public string URL { get { return tbURL.Text; } set { tbURL.Text = value; } }

        public string Filter { get { return tbFilter.Text; } set { tbFilter.Text = value; } }
        public string DestinationFolder { get { return tbDestinationFolder.Text; } set { tbDestinationFolder.Text = value; } }

        public ChangeFrequency ChangeFrequency
        {
            get
            {
                if (!cbChangeFrequency.Checked) { return 0; }
                else { return (ChangeFrequency) comboBoxChangeFrequency.SelectedIndex + 1; }
            }
            set
            {
                if (value == 0)
                {
                    cbChangeFrequency.Checked = false;
                    comboBoxChangeFrequency.SelectedIndex = 0;
                }
                else
                {
                    cbChangeFrequency.Checked = true;
                    comboBoxChangeFrequency.SelectedIndex = (int) value - 1;
                }
            }
        }

        public Priority Priority
        {
            get
            {
                if (!cbPriority.Checked) { return 0; }
                else
                {
                    return (Priority) comboBoxPriority.SelectedIndex + 1;
                }
            }
            set
            {
                if (value == 0)
                {
                    cbPriority.Checked = false;
                    comboBoxPriority.SelectedIndex = 0;
                }
                else
                {
                    cbPriority.Checked = true;
                    comboBoxPriority.SelectedIndex = (int) value - 1;
                }
            }
        }
        public LastModification LastModification
        {
            get
            {
                if (!cbLastModification.Checked) { return 0; }
                else
                {
                    return (LastModification) comboBoxLastModification.SelectedIndex + 1;
                }
            }
            set
            {
                if (value == 0)
                {
                    cbLastModification.Checked = false;
                    comboBoxLastModification.SelectedIndex = 0;
                }
                else
                {
                    cbLastModification.Checked = true;
                    comboBoxLastModification.SelectedIndex = (int) value - 1;
                }
            }
        }

        /// <summary>
        /// A null value means that the encoding shoule be guessed.
        /// </summary>
        public Encoding Encoding
        {
            get
            {
                if (comboBoxEncoding.SelectedIndex == 0)
                {
                    return null;
                }
                else
                {
                    return Encoding.GetEncoding(comboBoxEncoding.SelectedItem as string);
                }
            }
            set
            {
                if (value == null) { comboBoxEncoding.SelectedIndex = 0; }
                else
                {
                    // avoid setting SelectedText property
                    for (int i = 1; i < comboBoxEncoding.Items.Count; i++)
                    {
                        if (comboBoxEncoding.Items[i] as string == value.WebName)
                        {
                            comboBoxEncoding.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }

        public PageTitle PageTitle
        {
            get { return (PageTitle) comboBoxPageTitle.SelectedIndex; }
            set { comboBoxPageTitle.SelectedIndex = (int) value; }
        }

        public bool GenerateHtmlFile
        {
            get { return cbGenerateHtmlFile.Checked; }
            set { cbGenerateHtmlFile.Checked = value; }
        }

        public bool GenerateXmlFile
        {
            get { return cbGenerateXmlFile.Checked; }
            set { cbGenerateXmlFile.Checked = value; }
        }

        public string LocalPath
        {
            get { return tbLocalPath.Text; }
            set { tbLocalPath.Text = value; }
        }

        public bool FromLocalFiles
        {
            get { return cbUseLocal.Checked; }
            set { cbUseLocal.Checked = value; }
        }

        public bool IncludeNotFoundFiles
        {
            get { return cbIncludeNotFound.Checked; }
            set { cbIncludeNotFound.Checked = value; }
        }
	}
}
