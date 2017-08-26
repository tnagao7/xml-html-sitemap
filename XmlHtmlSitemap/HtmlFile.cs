using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Web;

namespace XmlHtmlSitemap
{
    /// <summary>
    /// Represents an HTML File.
    /// </summary>
    class HtmlFile
    {
        HtmlAgilityPack.HtmlDocument htmlDocument;

        public Uri Uri { get; set; }
        public string TitleElement { get; set; }
        public string H1Element { get; set; }
        public DateTime SavedDate { get; set; }
        public double Priority { get; set; }
        public string ContentType { get; set; }

        public HtmlFile(Uri uri)
        {
            this.Uri = uri;
            this.TitleElement = this.Uri.AbsolutePath;
            this.H1Element = this.Uri.AbsolutePath;
        }

        public void Fetch(Encoding encoding, bool inquiryLastModified, bool fromLocal, PathInfo localPathInfo)
        {
            string url = fromLocal ? localPathInfo.LocalFilePathFor(Uri) : Uri.AbsoluteUri;

            WebRequest request = WebRequest.Create(url);
            using (WebResponse response = request.GetResponse())
            {
                this.ContentType = response.ContentType;

                if (inquiryLastModified)
                {
                    if (fromLocal)
                    {
                        FileInfo fi = new FileInfo(url);
                        this.SavedDate = fi.LastWriteTime;
                    }
                    else
                    {
                        this.SavedDate = (response as HttpWebResponse).LastModified;
                    }
                }
            }

            if (this.ContentType.Contains("text") || fromLocal)
            {
                HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
                this.htmlDocument = new HtmlAgilityPack.HtmlDocument();

                if (encoding == null)
                {
                    web.AutoDetectEncoding = true;
                    htmlDocument = web.Load(url);
                }
                else
                {
                    web.AutoDetectEncoding = false;
                    web.OverrideEncoding = encoding;
                    htmlDocument = web.Load(url);
                }

                this.TitleElement = this.GetTitleElement(this.htmlDocument);
                this.H1Element = this.GetH1Element(this.htmlDocument);
            }
        }

        private string GetTitleElement(HtmlAgilityPack.HtmlDocument doc)
        {
            HtmlAgilityPack.HtmlNodeCollection nodes =
                doc.DocumentNode.SelectNodes("/html[1]/head[1]/title");
            if (nodes != null && nodes.Count > 0)
            {
                return HttpUtility.HtmlDecode(nodes[0].InnerText);
            }
            else
            {
                return this.Uri.AbsolutePath;
            }
        }

        private string GetH1Element(HtmlAgilityPack.HtmlDocument doc)
        {
            HtmlAgilityPack.HtmlNodeCollection nodes =
                  doc.DocumentNode.SelectNodes("/html[1]/body[1]//h1");
            if (nodes != null && nodes.Count > 0)
            {
                return HttpUtility.HtmlDecode(nodes[0].InnerText);
            }
            else
            {
                return this.Uri.AbsolutePath;
            }
        }

        public IEnumerable<Uri> GetLinkUrls()
        {
            List<Uri> absoluteUriList = new List<Uri>();

            if (this.htmlDocument == null)
            {
                return absoluteUriList;
            }

            HtmlAgilityPack.HtmlNodeCollection nodes =
                 this.htmlDocument.DocumentNode.SelectNodes("/html[1]/body[1]//a");

            if (nodes == null)
            {
                return absoluteUriList;
            }

            foreach (HtmlAgilityPack.HtmlNode node in nodes)
            {
                string matchedUrl = node.GetAttributeValue("href", "");

                // remove substring from # 
                int sharpIndex = matchedUrl.IndexOf('#');  // if not found, -1
                if (sharpIndex != -1)
                {
                    matchedUrl = matchedUrl.Remove(sharpIndex);
                }

                Uri newUri = new Uri(this.Uri, matchedUrl);

                if (!absoluteUriList.Exists(u => u.AbsoluteUri == newUri.AbsoluteUri))
                {
                    absoluteUriList.Add(newUri);
                }
            }

            return absoluteUriList;
        }

        public int CountSlashesInAbsoluteUrl()
        {
            return this.Uri.AbsoluteUri.Length - this.Uri.AbsoluteUri.Replace("/", "").Length;
        }
    }
}
