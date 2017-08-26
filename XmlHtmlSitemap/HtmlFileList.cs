using System;
using System.Collections.Generic;

namespace XmlHtmlSitemap
{
    /// <summary>
    /// Represents a list of HTML files.
    /// </summary>
    class HtmlFileList : List<HtmlFile>
    {
        /// <summary>
        /// Sorts elements of the current object according to URLs.
        /// </summary>
        /// <param name="exceptFirstItem">If <c>true</c>, the first element will not be moved.</param>
        public void SortByUrl(bool exceptFirstItem = false)
        {
            HtmlFile firstItem = null;

            if (exceptFirstItem && this.Count > 0)
            {
                firstItem = this[0];
                this.RemoveAt(0);
            }

            this.Sort((HtmlFile a, HtmlFile b) =>
            {
                // compare directory first so that, e.g.,
                // ["/c.html", "/b/b.html", "/a.html"] is sorted into
                // ["/a.html", "/c.html", "/b/b.html"] 
                // instead of ["/a.html", "/b/b.html", "/c.html"] 

                string _a = PathInfo.EliminateFileName(a.Uri.AbsoluteUri);
                string _b = PathInfo.EliminateFileName(b.Uri.AbsoluteUri);
                int diff = string.Compare(_a, _b);

                if (diff != 0)
                {
                    return diff;
                }
                else
                {
                    return string.Compare(a.Uri.AbsoluteUri, b.Uri.AbsoluteUri);
                }
            });

            if (exceptFirstItem && firstItem != null)
            {
                this.Insert(0, firstItem);
            }
        }

        /// <summary>
        /// Determines whether the current object contains an element with the specified URI.
        /// </summary>
        /// <param name="absoluteUri">The URI.</param>
        /// <returns>Returns <c>true</c> if the current object contains an element <c>e</c> such that <c>e.Url.AbsoluteUri</c> equals the given URI; <c>false</c> otherwise.</returns>
        public bool ContainsUri(string absoluteUri)
        {
            return this.Exists(e => e.Uri.AbsoluteUri == absoluteUri);
        }
    }
}
