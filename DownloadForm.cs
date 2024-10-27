using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GfWLUtility
{
    internal enum DownloadFormResult
    {
        DownloadCancelled,
        DownloadSuccess,
        DownloadFailure
    }

    public partial class DownloadForm : Form
    {
        private DownloadFormResult result = DownloadFormResult.DownloadCancelled;
        private FileInformation fileInformation;
        private string downloadOutput;
        private string downloadUrl;
        private int downloadAttempt;

        public DownloadForm()
        {
            InitializeComponent();
        }

        // https://stackoverflow.com/a/9459441
        private void StartDownload()
        {
            Thread thread = new Thread(() => {
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);
                client.DownloadFileAsync(new Uri(downloadUrl), downloadOutput);
            });
            thread.Start();
            progressBar1.Style = ProgressBarStyle.Blocks;
        }
        void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                statusLabel.Text = "Downloaded " + UtilityFuncs.BytesToString(e.BytesReceived) + " of " + UtilityFuncs.BytesToString(e.TotalBytesToReceive);
                progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
            });
        }
        void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                result = DownloadFormResult.DownloadSuccess;
                Close();
            });
        }

        internal DownloadFormResult StartFileDownload(FileInformation fi, IWin32Window owner)
        {
            if (!Directory.Exists(System.IO.Path.GetTempPath() + "\\GfWLUtility"))
                Directory.CreateDirectory(System.IO.Path.GetTempPath() + "\\GfWLUtility");
            downloadOutput = System.IO.Path.GetTempPath() + "\\GfWLUtility\\" + fi.Filename;
            if (File.Exists(downloadOutput))
                File.Delete(downloadOutput);

            fileInformation = fi;
            // TODO: If a download fails on one URL, try another
            downloadUrl = fi.DownloadURLs.FirstOrDefault();
            currentDownloadURL.Text = downloadUrl;
            statusLabel.Text = "Preparing download...";
            progressBar1.Style = ProgressBarStyle.Marquee;
            StartDownload();
            ShowDialog(owner);
            return result;
        }

        internal string GetOutputFilePath()
        {
            return downloadOutput;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
