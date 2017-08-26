using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace XmlHtmlSitemap
{
    using XmlHtmlSitemap.Properties;

    public enum ProgressDialogResult
    {
        None = 0,
        Success = 1,
        Failure = 2,
    }

    public partial class ProgressDialog : Form
    {
        BackgroundWorker bw;
        public Logger Progress { get; set; }
        public ProgressDialogResult ProgressDialogResult { get; set; }

        public ProgressDialog(BackgroundWorker bw)
        {
            this.bw = bw;
            this.bw.ProgressChanged += bw_ProgressChanged;
            this.bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            ProgressDialogResult = ProgressDialogResult.None;
            InitializeComponent();
        }

        void bw_ProgressChanged(object sender, ProgressChangedEventArgs eventArgs)
        {
            label.Text = eventArgs.UserState as string;
            progressBar.Value = eventArgs.ProgressPercentage;
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs eventArgs)
        {
            label.Text = Resources.String15;

            if (eventArgs.Error != null)
            {
                Progress.AddLog(eventArgs.Error.Message);

                this.ProgressDialogResult = ProgressDialogResult.Failure;
            }
            else if (eventArgs.Cancelled)
            {
                this.ProgressDialogResult = ProgressDialogResult.Failure;
            }
            else
            {
                this.ProgressDialogResult = ProgressDialogResult.Success;
            }

            this.Close();
        }

        public new ProgressDialogResult ShowDialog()
        {
            base.ShowDialog();
            return this.ProgressDialogResult;
        }

        public new ProgressDialogResult ShowDialog(IWin32Window owner)
        {
            base.ShowDialog(owner);
            return this.ProgressDialogResult;
        }
        
        // invalidate the close button
        protected override CreateParams CreateParams
        {
            [System.Security.Permissions.SecurityPermission(
                System.Security.Permissions.SecurityAction.LinkDemand,
                Flags = System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]
            get
            {
                const int CS_NOCLOSE = 0x200;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = cp.ClassStyle | CS_NOCLOSE;

                return cp;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            label.Text = Resources.String14;
            bw.CancelAsync();
        }
    }
}
