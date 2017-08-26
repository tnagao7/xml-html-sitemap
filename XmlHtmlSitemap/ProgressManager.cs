//using System;

//namespace XmlHtmlSitemap
//{
//    using XmlHtmlSitemap.Properties;

//    public class ProgressManager
//    {
//        // System.ComponentModel.BackgroundWorker.ReportProgress is the model
//        public delegate void ReportProgressEventHandler(int percentage, object state);

//        public event ReportProgressEventHandler ReportProgressEvent;


//        public void OnReportProgressEvent(int percentage, object state)
//        {
//            if (this.ReportProgressEvent != null)
//            {
//                this.ReportProgressEvent(percentage, state);
//            }
//        }

//        public void ReportProgress(int percentage, string message)
//        {
//            this.OnReportProgressEvent(percentage, (object)message);
//        }
//    }
//}
