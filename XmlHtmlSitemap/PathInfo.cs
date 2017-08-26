using System;
using System.IO;

namespace XmlHtmlSitemap
{
    class PathInfo
    {
        public string LocalRootFile { get; private set; }
        public string LocalRootDir { get { return Path.GetDirectoryName(LocalRootFile); } }
        public Uri HttpRootUri { get; private set; }

        public PathInfo(string httpRoot, string localRootFile)
        {
            HttpRootUri = new Uri(httpRoot);
            LocalRootFile = localRootFile;
        }

        public string LocalFilePathFor(Uri httpUri)
        {
            if (httpUri.AbsoluteUri == HttpRootUri.AbsoluteUri)
            {
                return LocalRootFile;
            }
            else
            {
                string baseUriDir = EliminateFileName(HttpRootUri.AbsoluteUri);
                string relativePath = httpUri.AbsoluteUri.Substring(baseUriDir.Length);
                return Path.Combine(LocalRootDir, relativePath);
            }
        }

        /// <summary>
        /// Returns a string obtained by eliminating a trailing file name from the given URL.
        /// </summary>
        /// <example>
        /// <c>EliminateFileName("http://example.com/foo/bar.html")</c> 
        /// will return <c>"http://example.com/foo"</c>.
        /// </example>
        /// <param name="absoluteUri">The Uri.</param>
        /// <returns></returns>
        public static string EliminateFileName(string absoluteUri)
        {
            int lastIndexOfSlash = absoluteUri.LastIndexOf('/');
            if (lastIndexOfSlash + 1 < absoluteUri.Length)
            {
                return absoluteUri.Remove(lastIndexOfSlash + 1);
            }
            else
            {
                return absoluteUri;
            }
        }

        public static string ExtractFileName(string absoluteUri)
        {
            int lastIndexOfSlash = absoluteUri.LastIndexOf('/');
            return absoluteUri.Substring(lastIndexOfSlash + 1);
        }
    }
}
