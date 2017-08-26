using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace XmlHtmlSitemap
{
    using System.IO;
    using XmlHtmlSitemap.Properties;

    partial class MainForm
    {
        SitemapGenerator generator;
        BackgroundWorker bw;
        ProgressDialog progressDialog;
        Logger logger;
        string filter;
        string fileLocation;
        string culture;

        private DialogResult CheckDestinationExistence()
        {
            string destXmlFilePath = Path.Combine(DestinationFolder, SitemapGenerator.XmlSitemapName);
            string destHtmlFilePath = Path.Combine(DestinationFolder, SitemapGenerator.HtmlSitemapName);

            bool xmlAlreadyExists = File.Exists(destXmlFilePath);
            bool htmlAlreadyExists = File.Exists(destHtmlFilePath);

            if (xmlAlreadyExists && htmlAlreadyExists)
            {
                string message = string.Format(Resources.String25, 
                    SitemapGenerator.XmlSitemapName, SitemapGenerator.HtmlSitemapName);
                return MessageBox.Show(message, Resources.String26, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            else if (xmlAlreadyExists)
            {
                string message = string.Format(Resources.String24, SitemapGenerator.XmlSitemapName);
                return MessageBox.Show(message, Resources.String26, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            else if (htmlAlreadyExists)
            {
                string message = string.Format(Resources.String24, SitemapGenerator.HtmlSitemapName);
                return MessageBox.Show(message, Resources.String26, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            else
            {
                return DialogResult.OK;
            }
        }

        private void ExecuteSitemapGeneration()
        {
            try
            {
                btnRun.Enabled = false;

                if (CheckDestinationExistence() != DialogResult.OK)
                {
                    btnRun.Enabled = true;
                    return;
                }

                filter = this.Filter;
                fileLocation = this.DestinationFolder;
                culture = Program.GetUICulture();

                logger = new Logger()
                {
                    OmitDuplicatedLog = true,
                };

                bw = new BackgroundWorker()
                {
                    WorkerReportsProgress = true,
                    WorkerSupportsCancellation = true,
                };

                generator = new SitemapGenerator(this.URL, this.bw)
                {
                    LastModification = this.LastModification,
                    ChangeFrequency = this.ChangeFrequency,
                    Priority = this.Priority,
                    FileEncoding = this.Encoding,
                    GenerateHtmlFile = this.GenerateHtmlFile,
                    GenerateXmlFile = this.GenerateXmlFile,
                    IncludeNotFoundFiles = this.IncludeNotFoundFiles,
                    Logger = this.logger,
                    SpecifiedDate = this.dateTimePicker.Value,
                    PageTitle = this.PageTitle,
                    FromLocalFiles = this.FromLocalFiles,
                };

                if (FromLocalFiles)
                {
                    PathInfo localPathInfo = new PathInfo(this.URL, this.LocalPath);
                    generator.LocalPathInfo = localPathInfo;
                }

                bw.DoWork += DoSitemapGenerationBackground;
                bw.RunWorkerAsync();

                progressDialog = new ProgressDialog(bw);
                progressDialog.Progress = this.logger;
                progressDialog.Text = Resources.String19;

                ProgressDialogResult result = progressDialog.ShowDialog();

                if (result == ProgressDialogResult.Success)
                {
                    if (logger.LogIsEmpty)
                    {
                        ResultDialog resultDialog = new ResultDialog()
                        {
                            Text = Resources.String9,
                            MainMessage = Resources.String10,
                            Details = Resources.String12 + Environment.NewLine,
                            Directory = this.DestinationFolder,
                            Icon = SystemIcons.Information,
                            Sound = System.Media.SystemSounds.Asterisk,
                        };

                        resultDialog.ShowDialog();
                    }
                    else
                    {
                        ResultDialog resultDialog = new ResultDialog()
                        {
                            Text = Resources.String9,
                            MainMessage = Resources.String10,
                            Details = Resources.String11 + Environment.NewLine + Environment.NewLine + logger.Log,
                            Directory = this.DestinationFolder,
                            Icon = SystemIcons.Information,
                            Sound = System.Media.SystemSounds.Asterisk,
                        };

                        resultDialog.ShowDialog();
                    }
                }
                else if (result == ProgressDialogResult.Failure)
                {
                    ResultDialog resultDialog = new ResultDialog()
                    {
                        Directory = null,
                        Text = Resources.String8,
                        MainMessage = Resources.String13,
                        Details = Resources.String11 + Environment.NewLine + Environment.NewLine + logger.Log,
                        Icon = SystemIcons.Error,
                        Sound = System.Media.SystemSounds.Hand,
                    };
                    
                    resultDialog.ShowDialog();
                }
            }
            catch (Exception e)
            {
                ResultDialog resultDialog = new ResultDialog()
                {
                    Directory = null,
                    Text = Resources.String8,
                    MainMessage = Resources.String13,
                    Details = Resources.String11 + Environment.NewLine + Environment.NewLine + e.Message,
                    Icon = SystemIcons.Hand,
                    Sound = System.Media.SystemSounds.Hand,
                };

                resultDialog.ShowDialog();
            }
            finally
            {
                btnRun.Enabled = true;
                btnRun.Focus();
            }
        }

        void DoSitemapGenerationBackground(object sender, DoWorkEventArgs eventArgs)
        {
            try
            {
                Program.SetUICulture(culture);
                Program.SetCulture(culture);
                generator.SetExcludedPattern(filter);
                generator.GenerateSitemap(fileLocation);
            }
            catch (Exception)
            {
                throw;  // progress dialog will catch 
            }
        }
    }
}
