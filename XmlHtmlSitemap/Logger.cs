using System;
using System.Collections.Generic;

namespace XmlHtmlSitemap
{
    using XmlHtmlSitemap.Properties;

    public class Logger
    {
        public List<string> logs;

        public bool LogIsEmpty { get { return String.IsNullOrEmpty(Log); } }
        public bool OmitDuplicatedLog { get; set; }

        public string Log
        {
            get { return String.Join(Environment.NewLine + Environment.NewLine, logs.ToArray()); }
        }

        public Logger()
        {
            logs = new List<string>();
            OmitDuplicatedLog = false;
        }

        public void AddLog(Exception exception)
        {
            string message = exception.Message;

            if (!OmitDuplicatedLog || !logs.Contains(message))
            {
                logs.Add(exception.Message);
            }
        }

        public void AddLog(string message)
        {
            if (!OmitDuplicatedLog || !logs.Contains(message))
            {
                logs.Add(message);
            }
        }

        public void AddLog(Exception exception, string submessage)
        {
            string message = submessage + ": " + exception.Message;

            if (!OmitDuplicatedLog || !logs.Contains(message))
            {
                logs.Add(message);
            }
        }
    }
}
