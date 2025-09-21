using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GfWLUtility
{
    internal enum DownloadFormResult
    {
        DownloadCancelled,
        DownloadSuccess,
        DownloadFailure,
        FileAlreadyExists
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
                result = e.Error == null ? DownloadFormResult.DownloadSuccess : DownloadFormResult.DownloadFailure;
                Close();
            });
        }

        internal static byte[] GetFileHash(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            byte[] hash = null;
            using (BufferedStream bs = new BufferedStream(fs))
            {
                using (SHA1Managed sha1 = new SHA1Managed())
                {
                    hash = sha1.ComputeHash(bs);
                }
                bs.Close();
            }
            fs.Close();
            return hash;
        }

        internal static string FileAlreadyExists(FileInformation fi)
        {
            // check if the file exists in the downloads folder with its default filename
            string filename = UtilityFuncs.GetLocalDirectory("Downloads") + fi.Filename;
            // TODO: check filesize as well as hash
            if (File.Exists(filename) && GetFileHash(filename).SequenceEqual(fi.Hash))
            {
                return filename;
            }
            // check alternative filenames
            if (fi.AltFilenames != null && fi.AltFilenames.Length >= 1)
            {
                foreach(string file in fi.AltFilenames)
                {
                    filename = UtilityFuncs.GetLocalDirectory("Downloads") + file;
                    if (File.Exists(filename) && GetFileHash(filename).SequenceEqual(fi.Hash))
                    {
                        return filename;
                    }
                }
            }
            // null = file doesn't already exist
            return null;
        }

        internal DownloadFormResult StartFileDownload(FileInformation fi, IWin32Window owner)
        {
            if (!Directory.Exists(UtilityFuncs.GetLocalDirectory("Downloads")))
                Directory.CreateDirectory(UtilityFuncs.GetLocalDirectory("Downloads"));
            downloadOutput = UtilityFuncs.GetLocalDirectory("Downloads") + fi.Filename;
            if (File.Exists(downloadOutput))
            {
                // verify the checksum of the existing file
                if (!GetFileHash(downloadOutput).SequenceEqual(fi.Hash))
                {
                    // if the hash isn't the same, delete it and redownload
                    File.Delete(downloadOutput);
                }
                else
                {
                    // if it is the same, we don't need to redownload
                    return DownloadFormResult.FileAlreadyExists;
                }
            }

            fileInformation = fi;

            // if there is no download URLs, the download should immediately fail
            if (fi.DownloadURLs == null || fi.DownloadURLs.Length < 1)
                return DownloadFormResult.DownloadFailure;

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
