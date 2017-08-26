using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using System.Web;

namespace XmlHtmlSitemap
{
    using System.ComponentModel;
    using XmlHtmlSitemap.Properties;

    public enum LastModification
    {
        None = 0,
        Server = 1,
        Specified = 2,
    }

    public enum ChangeFrequency
    {
        None = 0,
        Always = 1,
        Hourly = 2,
        Daily = 3,
        Weekly = 4,
        Monthly = 5,
        Yearly = 6,
        Never = 7,
    }

    public enum Priority
    {
        None = 0,
        Depth = 1,
    }

    public enum PageTitle
    {
        TitleElement = 0,
        H1Element = 1,
        AbsoluteUrl = 2,
        FileName = 3,
    }

    /// <summary>
    /// Represents a sitemap.
    /// </summary>
    class SitemapGenerator
    {
        public const string XmlSitemapName = "sitemap.xml";
        public const string HtmlSitemapName = "sitemap.html";
        public const string HtmlTemplateName = "template.html";

        public LastModification LastModification { get; set; }
        public ChangeFrequency ChangeFrequency { get; set; }
        public Priority Priority { get; set; }
        public PageTitle PageTitle { get; set; }
        public Encoding FileEncoding { get; set; }
        public bool GenerateHtmlFile { get; set; }
        public bool GenerateXmlFile { get; set; }
        public bool IncludeNotFoundFiles { get; set; }
        public Logger Logger { get; set; }
        public DateTime SpecifiedDate { get; set; }
        public bool FromLocalFiles { get; set; }
        public PathInfo LocalPathInfo { get; set; }
        public BackgroundWorker bw { get; private set; }

        List<Regex> ExcludedPatternList { get; set; }

        readonly Uri baseUrl;

        HtmlFileList htmlFileList = new HtmlFileList();
        List<Uri> erroredFileUris = new List<Uri>();

        public SitemapGenerator(string baseUriString, BackgroundWorker bw)
        {
            FileEncoding = null;
            ExcludedPatternList = new List<Regex>();
            GenerateXmlFile = false;
            GenerateHtmlFile = false;
            IncludeNotFoundFiles = false;
            Logger = null;
            this.baseUrl = new Uri(baseUriString);
            this.bw = bw;
        }

        public void CheckCanceledOrNot()
        {
            if (bw.CancellationPending)
            {
                throw new OperationCanceledException(Resources.String40);
            }
        }

        public void GenerateSitemap(string destDirectory)
        {
            bw.ReportProgress(0, Resources.String3 + Environment.NewLine + this.baseUrl);
            CheckCanceledOrNot();
            
            bw.ReportProgress(0, Resources.String3 + Environment.NewLine + this.baseUrl);
            CheckCanceledOrNot();

            ListUpUrls(this.baseUrl);

            bw.ReportProgress(0, Resources.String35);
            CheckCanceledOrNot();

            htmlFileList.SortByUrl(true);

            if (GenerateXmlFile)
            {
                if (Priority != Priority.None)
                {
                    SetHtmlFilePriority();
                }

                bw.ReportProgress(0, Resources.String1);
                CheckCanceledOrNot();

                SaveXmlSitemap(destDirectory);
            }

            if (GenerateHtmlFile)
            {
                bw.ReportProgress(0, Resources.String2);
                CheckCanceledOrNot();

                SaveHtmlSitemap(destDirectory);
            }
        }

        private void ListUpUrls(Uri baseUri)
        {
            Queue<Uri> pending = new Queue<Uri>();
            pending.Enqueue(baseUri);

            while (pending.Count > 0)
            {
                Uri currentUri = pending.Dequeue();
                HtmlFile file = null;

                bw.ReportProgress(0, Resources.String3 + Environment.NewLine + currentUri.AbsolutePath);
                CheckCanceledOrNot();

                try
                {
                    file = new HtmlFile(currentUri);
                    file.Fetch(FileEncoding, LastModification == LastModification.Server && GenerateXmlFile, FromLocalFiles, LocalPathInfo);

                    if (LastModification == LastModification.Specified)
                    {
                        file.SavedDate = this.SpecifiedDate;
                    }
                    htmlFileList.Add(file);

                    foreach (Uri newUri in file.GetLinkUrls())
                    {
                        if (!htmlFileList.Exists(f => f.Uri.AbsoluteUri == newUri.AbsoluteUri) &&
                          !erroredFileUris.Exists(u => u.AbsoluteUri == newUri.AbsoluteUri) &&
                          !pending.Contains(newUri) &&
                          !MatchPattern(newUri.AbsolutePath, this.ExcludedPatternList) &&
                          newUri.AbsoluteUri.Contains(PathInfo.EliminateFileName(this.baseUrl.AbsoluteUri)))
                        {
                            pending.Enqueue(newUri);
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
                catch (Exception e)
                {
                    if (IncludeNotFoundFiles && file != null)
                    {
                        htmlFileList.Add(file);
                    }
                    erroredFileUris.Add(currentUri);
                    Logger.AddLog(e, currentUri.AbsolutePath);
                }
            }
        }

        private bool MatchPattern(string path, IEnumerable<Regex> excludedPatternList)
        {
            foreach (Regex regex in excludedPatternList)
            {
                if (regex.IsMatch(path))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Saves "sitemap.xml" in the Sitemap 0.90 format.
        /// </summary>
        /// <param name="destDirectory">The directory to save the sitemap.xml.</param>
        private void SaveXmlSitemap(string destDirectory)
        {
            try
            {
                string destFilePath = Path.Combine(destDirectory, XmlSitemapName);

                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings()
                {
                    // avoid Encoding.UTF8 as it refers to UTF-8 with BOM
                    Encoding = new UTF8Encoding(false),
                    Indent = true,
                    IndentChars = "\t",
                    NewLineChars = Environment.NewLine,
                };

                using (XmlWriter xw = XmlWriter.Create(destFilePath, xmlWriterSettings))
                {
                    xw.WriteStartDocument();

                    // <urlset xmlns="...">
                    xw.WriteStartElement("urlset", "http://www.sitemaps.org/schemas/sitemap/0.9");

                    for (int i = 0; i < htmlFileList.Count; i++)
                    {
                        // <url>
                        xw.WriteStartElement("url");

                        // <loc>path</loc>
                        xw.WriteElementString("loc", HttpUtility.HtmlEncode(htmlFileList[i].Uri.AbsoluteUri));

                        // <lastmod>datetime</lastmod>
                        if (LastModification != LastModification.None)
                        {
                            xw.WriteElementString("lastmod", htmlFileList[i].SavedDate.ToString("yyyy-MM-dd'T'HH:mm:sszzz"));
                        }

                        // <changefreq>changefreq</changefreq>
                        if (ChangeFrequency != ChangeFrequency.None)
                        {
                            xw.WriteElementString("changefreq", Enum.GetName(typeof(ChangeFrequency), this.ChangeFrequency).ToLower());
                        }

                        // <priority>priority</priority>
                        if (Priority != Priority.None)
                        {
                            xw.WriteElementString("priority", string.Format("{0:0.0}", htmlFileList[i].Priority));
                        }

                        // <url>
                        xw.WriteEndElement();
                    }

                    // </urlset>
                    xw.WriteEndElement();

                    xw.WriteEndDocument();
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        string GenerateAnchorElement(HtmlFile targetFile, PageTitle pageTitle)
        {
            string href = targetFile.Uri.AbsoluteUri;
            string element = String.Empty;
            if (PageTitle == PageTitle.TitleElement) { element = targetFile.TitleElement; }
            else if (PageTitle == PageTitle.H1Element) { element = targetFile.H1Element; }
            else if (PageTitle == PageTitle.FileName)
            {
                element = Regex.Match(targetFile.Uri.AbsoluteUri, @"(?<fname>[^/\\]*?)$", RegexOptions.Singleline).Value;
                if (element == "") { element = "(index)"; }
            }
            else { element = targetFile.Uri.AbsoluteUri; }


            return string.Format("<a href=\"{0}\">{1}</a>", HttpUtility.HtmlEncode(href), HttpUtility.HtmlEncode(element));
        }

        string sitemapHtml()
        {
            string sitemap = "";
            string baseDirectory = PathInfo.EliminateFileName(htmlFileList[0].Uri.AbsoluteUri);
            string currentDirectory = PathInfo.EliminateFileName(htmlFileList[0].Uri.AbsoluteUri);
            int baseDepth = htmlFileList[0].CountSlashesInAbsoluteUrl();
            int currentDepth = baseDepth;

            sitemap += "<ul>" + Environment.NewLine + "<li>" + currentDirectory + "<br />";

            sitemap += GenerateAnchorElement(htmlFileList[0], PageTitle) + "<br />" + Environment.NewLine;

            for (int i = 1; i < htmlFileList.Count; i++)
            {
                if (PathInfo.EliminateFileName(htmlFileList[i].Uri.AbsoluteUri) != currentDirectory)
                {
                    currentDirectory = PathInfo.EliminateFileName(htmlFileList[i].Uri.AbsoluteUri);

                    int diff;
                    if ((diff = htmlFileList[i].CountSlashesInAbsoluteUrl() - currentDepth) > 0)
                    {
                        for (int j = 0; j < diff; j++)
                        {
                            sitemap += "<ul>" + Environment.NewLine;
                            currentDepth++;
                        }
                        sitemap += "<li>" + HttpUtility.HtmlEncode(currentDirectory.Replace(baseDirectory, "")) + "<br />";
                    }
                    else if ((diff = htmlFileList[i].CountSlashesInAbsoluteUrl() - currentDepth) < 0)
                    {
                        sitemap += "</li>" + Environment.NewLine;
                        for (int j = 0; j > diff; j--)
                        {
                            sitemap += "</ul>" + Environment.NewLine + "</li>" + Environment.NewLine;
                            currentDepth--;
                        }
                        sitemap += "<li>" + HttpUtility.HtmlEncode(currentDirectory.Replace(baseDirectory, "")) + "<br />";
                    }
                    else
                    {
                        sitemap += "</li>" + Environment.NewLine;
                        sitemap += "</ul>" + Environment.NewLine;
                        sitemap += "<ul>" + Environment.NewLine;
                        sitemap += "<li>" + HttpUtility.HtmlEncode(currentDirectory.Replace(baseDirectory, "")) + "<br />" + Environment.NewLine;
                    }
                }

                sitemap += GenerateAnchorElement(htmlFileList[i], PageTitle) + "<br />" + Environment.NewLine;
            }

            for (; currentDepth >= baseDepth; currentDepth--)
            {
                sitemap += "</li>" + Environment.NewLine + "</ul>" + Environment.NewLine;
            }

            return sitemap;
        }

        void SaveHtmlSitemap(string destDirectory)
        {
            try
            {
                string map = sitemapHtml();
                
                string html;
                using (StreamReader sr = new StreamReader(HtmlTemplateName, Encoding.UTF8))
                {
                    html = sr.ReadToEnd();
                }

                html = Regex.Replace(html, @"\<!--COMMENT.*?--\>", "", RegexOptions.Singleline); 

                html = ReplaceSpecialTags(html, map);

                string destFilePath = Path.Combine(destDirectory, HtmlSitemapName);

                using (StreamWriter sw = new StreamWriter(destFilePath, false, Encoding.UTF8))
                {
                    sw.Write(html);
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception exception)
            {
                Logger.AddLog(exception);
                Logger.AddLog(Resources.String36);
            }
        }

        private string ReplaceSpecialTags(string html, string sitemap)
        {
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");

            foreach (Match match in Regex.Matches(html, @"\<%sitemap .*?/\>"))
            {
                html = html.Replace(match.Value, sitemap);
            }

            foreach (Match match in Regex.Matches(html, @"\<%home_title .*?/\>"))
            {
                html = html.Replace(match.Value, HttpUtility.HtmlEncode(htmlFileList[0].TitleElement));
            }

            foreach (Match match in Regex.Matches(html, @"\<%(date|time) .*?format=['""](?<fmt>.*?)['""].*?\>"))
            {
                string fmt = match.Result("${fmt}");
                string rep = DateTime.Now.ToString(fmt, ci);
                html = html.Replace(match.Value, rep);
            }

            return html;
        }

        public void SetExcludedPattern(string excludedPatternString)
        {
            string[] patterns =
                excludedPatternString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string pattern in patterns)
            {
                string regexPattern = pattern.Trim();
                regexPattern = regexPattern.Replace(@".", @"\.");
                string[] beforeEscape = { "{", "}", "(", ")", "[", "]", "-", "+" };
                string[] afterEscape = { @"\{", @"\}", @"\(", @"\)", @"\[", @"\]", @"\-", @"\+" };
                for (int i = 0; i < beforeEscape.Length; i++)
                {
                    regexPattern = regexPattern.Replace(beforeEscape[i], afterEscape[i]);
                }
                regexPattern = regexPattern.Replace(@"?", @".{1}");
                regexPattern = regexPattern.Replace(@"*", @".*");
                regexPattern = @"^" + regexPattern + @"$";
                ExcludedPatternList.Add(new Regex(regexPattern));
            }
        }

        private void SetHtmlFilePriority()
        {
            bw.ReportProgress(0, Resources.String39);
            CheckCanceledOrNot();

            if (Priority == Priority.Depth)
            {
                if (htmlFileList.Count > 0) {
                    int depthOfHome = htmlFileList[0].CountSlashesInAbsoluteUrl();

                    foreach (HtmlFile file in htmlFileList)
                    {
                        int depth = file.CountSlashesInAbsoluteUrl();
                        file.Priority = CalculatePriority(file, depth - depthOfHome);
                    }
                }
            }
        }
        
        public static double CalculatePriority(HtmlFile file, int relativeDepth)
        {
            string fileName = Path.GetFileNameWithoutExtension(PathInfo.ExtractFileName(file.Uri.AbsoluteUri));

            if (fileName.Equals("") ||
                fileName.Equals("index", StringComparison.OrdinalIgnoreCase) || 
                fileName.Equals("default", StringComparison.OrdinalIgnoreCase))
            {
                return Math.Max(1.0 - 0.1 * relativeDepth, 0.4);
            }
            else
            {
                return Math.Max(0.8 - 0.1 * relativeDepth, 0.4);
            }
        }
    }
}
