using GfWLUtility.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GfWLUtility
{
    public partial class ProfileInfoExtractor : Form
    {
        public bool Success = false;
        private Thread thread;
        private string shadowrunDir = UtilityFuncs.GetLocalDirectory("ShadowrunUtility");

        public ProfileInfoExtractor()
        {
            InitializeComponent();
        }

        void SetStatusString(string statusMessage)
        {
            BeginInvoke((MethodInvoker)delegate {
                statusLabel.Text = statusMessage;
            });
        }

        void Cancel()
        {
            thread.Abort();
            Close();
        }

        bool CheckDependencies()
        {
            SetStatusString("Checking dependencies...");

            //if (UtilityFuncs.IsWindowsXP())
            //{
            //    MessageBox.Show("Refreshing profile information requires Windows Vista or later.", "GfWL Utility", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            // make sure XLive is installed and is the latest version
            string xlive_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "xlive.dll");
            if (File.Exists(xlive_path))
            {
                Version xlive_version = UtilityFuncs.GetProductVersion(xlive_path);
                // hardcoded latest version. sucks?
                if (xlive_version.CompareTo(new Version("3.5.95.0")) != 0)
                {
                    MessageBox.Show("Refreshing profile information requires the latest version of the Games for Windows - LIVE runtime to be installed.", "GfWL Utility", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Refreshing profile information requires the Games for Windows - LIVE runtime to be installed.", "GfWL Utility", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // make sure the correct DirectX 9 files are installed
            string d3d9_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "d3d9.dll");
            string d3dx9_31_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "d3dx9_31.dll");
            if (!File.Exists(d3d9_path) || !File.Exists(d3dx9_31_path))
            {
                MessageBox.Show("Refreshing profile information requires the latest DirectX 9 redistributables to be installed.", "GfWL Utility", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // TODO: make sure the correct MSVC runtimes are installed

            Thread.Sleep(66);
            return true;
        }

        bool PrepareShadowrunFiles()
        {
            SetStatusString("Preparing Shadowrun TU files...");
            // make sure the folder exists
            if (!Directory.Exists(shadowrunDir))
                Directory.CreateDirectory(shadowrunDir);
            // check if Shadowrun already exists in this folder
            string execPath = Path.Combine(shadowrunDir, "Shadowrun.exe");
            if (!File.Exists(execPath))
            {
                // download the shadowrun TU
                DownloadForm form = new DownloadForm();
                DownloadFormResult fr = form.StartFileDownload(StaticFileInformation.shadowrun_tu10000081_cab, null);
                if (fr == DownloadFormResult.DownloadCancelled)
                {
                    MessageBox.Show("Downloading Shadowrun TU files was cancelled.", "GfWL Utility", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else if (fr == DownloadFormResult.DownloadFailure)
                {
                    MessageBox.Show("Downloading Shadowrun TU files failed.", "GfWL Utility", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                string cabPath = form.GetOutputFilePath();
                if (!File.Exists(cabPath))
                {
                    MessageBox.Show("The download succeeded, but the file doesn't exist..?", "GfWL Utility", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                // extract the cab file
                CabinetExtractor cex = new CabinetExtractor(cabPath, shadowrunDir);
                if (!cex.Extract() || !File.Exists(execPath))
                {
                    MessageBox.Show("Failed to extract the Title Update.", "GfWL Utility", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                // delete the original cabinet file
                File.Delete(cabPath);
                return true;
            }
            Thread.Sleep(500);
            return true;
        }

        bool PrepareXeKeysDumperFiles()
        {
            SetStatusString("Preparing dumper files...");

            // make sure the profile cache exists
            string profileCacheDir = UtilityFuncs.GetLocalDirectory("ProfileCache");
            if (!Directory.Exists(profileCacheDir))
                Directory.CreateDirectory(profileCacheDir);

            // set up the dumper's binkw32.dll
            File.WriteAllBytes(Path.Combine(shadowrunDir, "binkw32.dll"), Resources.gfwlxekeys);

            string xuidFile = Path.Combine(shadowrunDir, "xuids.dat");
            // delete the xuid file if it already exists
            if (File.Exists(xuidFile))
                File.Delete(xuidFile);
            // build up the xuid file from our user cache
            List<byte> xuidfileBytes = new List<byte>();
            int numXuids = UserManager.KnownUsers.Keys.Count;
            xuidfileBytes.AddRange(BitConverter.GetBytes(numXuids));
            foreach (KnownUser user in UserManager.KnownUsers.Values)
            {
                xuidfileBytes.AddRange(BitConverter.GetBytes(user.XUID));
            }
            File.WriteAllBytes(xuidFile, xuidfileBytes.ToArray());

            Thread.Sleep(66);
            return true;
        }

        bool StartDumping()
        {
            SetStatusString("Dumping profiles...");
            // launch the Shadowrun binary
            Process p = new Process();
            p.StartInfo.FileName = Path.Combine(shadowrunDir, "Shadowrun.exe");
            p.StartInfo.WorkingDirectory = shadowrunDir;
            p.Start();
            p.WaitForExit();
            if (p.ExitCode != -4000)
            {
                MessageBox.Show($"Refreshing profile information failed. (Error: {p.ExitCode})", "GfWL Utility", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        void ExtractorThread()
        {
            // ugly chain just to make sure if something fails in a former it won't die in the latter
            if (CheckDependencies())
                if (PrepareShadowrunFiles())
                    if (PrepareXeKeysDumperFiles())
                        if (StartDumping())
                            Success = true;
            BeginInvoke((MethodInvoker)delegate {
                Cancel();
            });
        }

        private void ProfileInfoExtractor_Load(object sender, EventArgs e)
        {
            // check if we've already asked...
            if (Directory.Exists(shadowrunDir))
            {
                thread = new Thread(ExtractorThread);
                thread.Start();
                return;
            }
            // if not, then ask.
            DialogResult dr = MessageBox.Show("Refreshing profile information requires downloading a ~20MB set of files from Microsoft (a Title Update for the game \"Shadowrun\"). Do you want to continue?", "GfWL Utility", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                thread = new Thread(ExtractorThread);
                thread.Start();
            } else
            {
                Close();
            }
        }

        private void ProfileInfoExtractor_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = thread != null && thread.ThreadState == System.Threading.ThreadState.Running;
        }
    }
}
