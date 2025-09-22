using GfWLUtility.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GfWLUtility
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadSystemInfoGroup()
        {
            showPCIDCheckbox.Checked = false;
            pcidText.Text = UtilityFuncs.CensorString(GfWLRegistry.GetPCID(), 2, 2, 4);
            versionText.Text = GfWLRegistry.GetVersion();
        }

        public string CurrentTabName()
        {
            return mainTabControl.SelectedTab.Text;
        }

        private bool ConfirmIsAdmin()
        {
            if (!Program.Elevated)
            {
                // no UAC prompt on Windows XP, and while technically Run As... still exists it's not what i'm going for
                if (!UtilityFuncs.IsWindowsXP())
                {
                    DialogResult r = MessageBox.Show("You must run GfWL Utility as administrator to use this functionality.\n\nDo you want to relaunch as administrator?",
                        "Permission Required", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (r == DialogResult.Yes)
                    {
                        Program.RelaunchAsAdmin($"--tab {CurrentTabName()}");
                        return false;
                    } else
                    {
                        return false;
                    }
                } else
                {
                    MessageBox.Show("You must run GfWL Utility as an administrator to use this functionality.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else return true;
        }

        private void LoadRuntimeInfoGroup()
        {
            string xlive_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "xlive.dll");
            if (File.Exists(xlive_path))
            {
                Version xlive_version = UtilityFuncs.GetProductVersion(xlive_path);
                runtimeInstallLabel.Text = "Runtime installed!";
                runtimeVersionLabel.Text = $"Version {xlive_version}";
                // hardcoded latest version. sucks?
                if (xlive_version.CompareTo(new Version("3.5.95.0")) >= 0) {
                    gfwlLogoPicture.Image = Resources.GfWLCheck;
                    installRuntimeButton.Enabled = false;
                    installRuntimeButton.Text = "Up to date!";
                } else
                {
                    gfwlLogoPicture.Image = Resources.GfWLOld;
                    installRuntimeButton.Enabled = true;
                    installRuntimeButton.Text = "Update runtime";
                }
            } else
            {
                gfwlLogoPicture.Image = Resources.GfWLUnknown;
                runtimeInstallLabel.Text = "Runtime not installed.";
                runtimeVersionLabel.Text = "";
                installRuntimeButton.Enabled = true;
                installRuntimeButton.Text = "Install runtime";
            }
        }

        private void LoadMarketplaceInfoGroup()
        {
            string dashdir = GfWLRegistry.GetDashPath();
            string gfwdashpath = "";
            if (dashdir != null)
                gfwdashpath = Path.Combine(dashdir, "GFWLive.exe");
            if (gfwdashpath != null && File.Exists(gfwdashpath))
            {
                Version dash_version = UtilityFuncs.GetProductVersion(gfwdashpath);
                marketplaceInstallLabel.Text = "Marketplace installed!";
                marketplaceVersionLabel.Text = $"Version {dash_version}";
                // hardcoded latest version. sucks?
                if (dash_version.CompareTo(new Version("3.5.67.0")) >= 0)
                {
                    Bitmap dashIcon = UtilityFuncs.Get48x48Icon(gfwdashpath);
                    if (dashIcon != null)
                        marketplaceLogoPicture.Image = dashIcon;
                    else
                        marketplaceLogoPicture.Image = Resources.GfWLCheck;
                    installMarketplaceButton.Enabled = false;
                    installMarketplaceButton.Text = "Up to date!";
                }
                else
                {
                    marketplaceLogoPicture.Image = Resources.GfWLOld;
                    installMarketplaceButton.Enabled = true;
                    installMarketplaceButton.Text = "Update marketplace";
                }
            }
            else
            {
                marketplaceLogoPicture.Image = Resources.GfWLUnknown;
                marketplaceInstallLabel.Text = "Marketplace not installed.";
                marketplaceVersionLabel.Text = "";
                installMarketplaceButton.Enabled = true;
                installMarketplaceButton.Text = "Install marketplace";
            }
        }

        private void LoadWLIDGroup()
        {
            bool is_old = false;
            // wlidcli has the icon assets so we use that first
            string wlid_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "wlidcli.dll");
            // check the Windows Live ID assistant install path
            if (!File.Exists(wlid_path) && GfWLRegistry.GetMsidcrlPath() != null)
            {
                wlid_path = Path.Combine(GfWLRegistry.GetMsidcrlPath(), "wlidcli.dll");
                // msidcrl40 gets installed as part of the Windows Live ID runtime but also is included in Windows 8+'s system32 folder
                if (!File.Exists(wlid_path))
                    wlid_path = Path.Combine(GfWLRegistry.GetMsidcrlPath(), "msidcrl40.dll");
            }
            // check system32 in case it exists there
            if (!File.Exists(wlid_path))
                wlid_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "msidcrl40.dll");
            // hack to get older versions to show up as existing but old
            if (!File.Exists(wlid_path))
            {
                wlid_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "msidcrl30.dll");
                is_old = true;
            }
            // final check - do we have a valid path
            if (File.Exists(wlid_path))
            {
                Version wlid_version = UtilityFuncs.GetProductVersion(wlid_path);
                wlidInstallLabel.Text = "Assistant installed!";
                // are we on 8+?
                if (UtilityFuncs.IsWindowsModern())
                    wlidInfoLabel.Text = "";
                else
                    wlidInfoLabel.Text = $"Version {wlid_version}";

                Bitmap wlidIcon = UtilityFuncs.Get48x48Icon(wlid_path);
                if (wlidIcon != null)
                    wlidLogoPicture.Image = wlidIcon;
                else
                    wlidLogoPicture.Image = Resources.WLIDOld;

                // hardcoded latest version. sucks?
                // technically this isn't even the latest version - newer versions do in fact exist
                if (UtilityFuncs.IsWindowsModern() || (!is_old && wlid_version.CompareTo(new Version("6.500.3165.0")) >= 0))
                {
                    installWLIDButton.Enabled = false;
                    installWLIDButton.Text = UtilityFuncs.IsWindowsModern() ? "Included in Windows" : "Up to date!";
                }
                else
                {
                    installWLIDButton.Enabled = true;
                    installWLIDButton.Text = "Update sign-in assistant";
                }
            }
            else
            {
                wlidLogoPicture.Image = Resources.WLIDUnknown;
                wlidInstallLabel.Text = "Assistant missing.";
                wlidInfoLabel.Text = "";
                installWLIDButton.Enabled = true;
                installWLIDButton.Text = "Install sign-in assistant";
            }
        }

        private void LoadConnBlockGroup()
        {
            if (DomainBlock.IsDomainBlocked("services.gamesforwindows.com"))
                blockServicesButton.Text = "Unblock Services";
            else
                blockServicesButton.Text = "Block Services";

            if (DomainBlock.IsDomainBlocked("xeas.xboxlive.com") ||
                DomainBlock.IsDomainBlocked("xemacs.xboxlive.com") ||
                DomainBlock.IsDomainBlocked("xetgs.xboxlive.com"))
                blockLiveButton.Text = "Unblock LIVE";
            else
                blockLiveButton.Text = "Block LIVE";
        }

        private void LoadAllGroups()
        {
            LoadConnBlockGroup();
            LoadRuntimeInfoGroup();
            LoadSystemInfoGroup();
            LoadMarketplaceInfoGroup();
            LoadWLIDGroup();
        }

        private void RefreshGamePage()
        {
            titleNameBox.Text = string.Empty;
            titleIDBox.Text = string.Empty;
            titleProductKeyBox.Text = string.Empty;
            titleIDFormattedLabel.Text = string.Empty;
            titleShowKeyCheck.Checked = false;

            if (gameListBox.SelectedIndex == -1)
            {
                titleShowKeyCheck.Enabled = false;
                return;
            }

            titleShowKeyCheck.Enabled = true;

            KnownTitle selected = (KnownTitle)gameListBox.SelectedItem;
            titleNameBox.Text = selected.Name;
            titleIDBox.Text = selected.TitleID.ToString("X8");
            titleIDFormattedLabel.Text = "(" + UtilityFuncs.GetFormattedTitleID(selected.TitleID) + ")";
            titleProductKeyBox.Text = UtilityFuncs.CensorString(TitleManager.GetTitleProductKey(selected.TitleID), 6, 6, 5);
            titleIconPicture.ImageLocation = $"http://image.xboxlive.com/global/t.{selected.TitleID:X8}/icon/0/8000";
        }

        private void RefreshProfilePage()
        {
            accountNameBox.Text = string.Empty;
            accountNameBox.Enabled = true;
            accountXuidBox.Text = string.Empty;
            accountGamerpic.ImageLocation = string.Empty;

            accountLiveCheck.Visible = false;
            onlineXuidBox.Visible = false;
            onlineXuidLabel.Visible = false;
            msaLabel.Visible = false;
            msaEmailBox.Visible = false;
            showMsaCheck.Visible = false;
            pnetCheck.Visible = false;
            showMsaCheck.Checked = false;

            if (accountsListBox.SelectedIndex == -1)
            {
                return;
            }

            KnownUser selected = (KnownUser)accountsListBox.SelectedItem;
            accountNameBox.Text = selected.HasFullInformation ? selected.Gamertag : "Missing Profile Info";
            accountNameBox.Enabled = selected.HasFullInformation;
            accountLiveCheck.Visible = selected.HasFullInformation;
            accountXuidBox.Text = selected.XUID.ToString("X16");
            accountGamerpic.ImageLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    $"Microsoft\\Xlive\\Content\\{selected.XUID:X8}\\FFFE07D1\\00010000\\{selected.XUID:X8}_MountPt\\tile_64.png");

            if (selected.HasFullInformation)
            {
                accountLiveCheck.Checked = selected.LiveEnabled;
                if (selected.LiveEnabled)
                {
                    onlineXuidBox.Visible = true;
                    onlineXuidLabel.Visible = true;
                    msaLabel.Visible = true;
                    msaEmailBox.Visible = true;
                    showMsaCheck.Visible = true;
                    pnetCheck.Visible = true;

                    pnetCheck.Visible = selected.Pnet;
                    pnetCheck.Checked = selected.Pnet;
                    msaEmailBox.Text = UtilityFuncs.CensorEmail(selected.MsaEmail);
                    onlineXuidBox.Text = selected.OnlineXUID.ToString("X16");
                }
            }
        }

        private void SearchForTitles()
        {
            string titlePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    $"Microsoft\\Xlive\\Titles");
            if (Directory.Exists(titlePath))
            {
                string[] titleSubdirs = Directory.GetDirectories(titlePath);
                foreach(string subdir in titleSubdirs)
                {
                    string titleID = Path.GetFileName(subdir);
                    uint titleIDInt = 0;
                    if (!uint.TryParse(titleID, NumberStyles.HexNumber,
                        CultureInfo.CurrentCulture, out titleIDInt))
                        continue;
                    TitleManager.FoundTitleExists(titleIDInt);
                }
            }

            gameListBox.Items.Clear();
            foreach (KnownTitle title in TitleManager.KnownTitles.Values)
            {
                gameListBox.Items.Add(title);
            }

            RefreshGamePage();
        }

        private void SearchForProfiles()
        {
            string profilesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    $"Microsoft\\Xlive\\Content");
            if (Directory.Exists(profilesPath))
            {
                string[] titleSubdirs = Directory.GetDirectories(profilesPath);
                foreach (string subdir in titleSubdirs)
                {
                    string xuid = Path.GetFileName(subdir);
                    ulong xuidInt = 0;
                    if (!ulong.TryParse(xuid, NumberStyles.HexNumber,
                        CultureInfo.CurrentCulture, out xuidInt))
                        continue;
                    // make sure it's a valid local xuid
                    if ((xuidInt & 0xE000000000000000) != 0xE000000000000000)
                        continue;
                    UserManager.FoundUserExists(xuidInt);
                    UserManager.PopulateUserInformation(xuidInt, $"{subdir}\\FFFE07D1\\00010000\\{xuidInt:X16}_MountPt\\Account");
                }
            }

            accountsListBox.Items.Clear();
            foreach (KnownUser title in UserManager.KnownUsers.Values)
            {
                accountsListBox.Items.Add(title);
            }

            RefreshProfilePage();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // detect Windows older than 2000 and bail out
            if (UtilityFuncs.IsWindowsLegacy())
            {
                MessageBox.Show("Games for Windows - LIVE and GfWL Utility requires Windows XP or later.",
                        "OS Unsupported", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            // load information
            LoadAllGroups();
            SearchForProfiles();
            SearchForTitles();
            if (Program.Elevated && !UtilityFuncs.IsWindowsXP())
                Text += " (Administrator)";
            // check if we're supposed to be launching a specific tab
            if (Program.Arguments.Contains("--tab"))
            {
                // gross
                string targetTab = null;
                // find the tab argument and get the argument value
                for(int i = 0; i < Program.Arguments.Length; i++)
                {
                    if (Program.Arguments[i] == "--tab" && Program.Arguments.Length >= (i + 2))
                    {
                        targetTab = Program.Arguments[i + 1];
                        break;
                    }
                }
                // if we've got a value find the tab itself
                if (targetTab != null)
                {
                    foreach(TabPage tab in mainTabControl.TabPages)
                    {
                        if (tab.Text == targetTab)
                            mainTabControl.SelectedTab = tab;
                    }
                }
            }
        }

        private void showPCIDCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (showPCIDCheckbox.Checked)
                pcidText.Text = GfWLRegistry.GetPCID();
            else
                pcidText.Text = UtilityFuncs.CensorString(GfWLRegistry.GetPCID(), 2, 2, 4);
        }

        private void blockServicesButton_Click(object sender, EventArgs e)
        {
            if (!ConfirmIsAdmin())
                return;

            if (DomainBlock.IsDomainBlocked("services.gamesforwindows.com"))
                DomainBlock.UnblockDomain("services.gamesforwindows.com");
            else
                DomainBlock.BlockDomain("services.gamesforwindows.com");

            LoadConnBlockGroup();
        }

        private void blockLiveButton_Click(object sender, EventArgs e)
        {
            if (!ConfirmIsAdmin())
                return;

            string[] domains = new string[] { "xeas.xboxlive.com", "xemacs.xboxlive.com", "xetgs.xboxlive.com" };
            if (domains.Any(DomainBlock.IsDomainBlocked))
            {
                foreach (var d in domains) DomainBlock.UnblockDomain(d);
            }
            else
            {
                DialogResult r = MessageBox.Show("Blocking LIVE means all Games for Windows - LIVE games will no longer be able to sign in, and some games may be unplayable. Are you sure you want to continue?",
                "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    foreach (var d in domains) DomainBlock.BlockDomain(d);
                }
            }

            LoadConnBlockGroup();
        }

        private void githubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/InvoxiPlayGames/GfWLUtility");
        }

        private void gameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGamePage();
        }

        private void titleShowKeyCheck_CheckedChanged(object sender, EventArgs e)
        {
            KnownTitle selected = (KnownTitle)gameListBox.SelectedItem;
            if (selected == null) return;
            if (titleShowKeyCheck.Checked)
                titleProductKeyBox.Text = TitleManager.GetTitleProductKey(selected.TitleID);
            else
                titleProductKeyBox.Text = UtilityFuncs.CensorString(TitleManager.GetTitleProductKey(selected.TitleID), 6, 6, 5);
        }

        private void accountsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshProfilePage();
        }

        private void dataExportButton_Click(object sender, EventArgs e)
        {
            ExportForm form = new ExportForm();
            form.ShowDialog(this);
        }

        private void dataImportButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Data import is not currently supported.", "GfWL Utility", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void installRuntimeButton_Click(object sender, EventArgs e)
        {
            // check if we have the latest redistributable msi downloaded
            string msiPath = DownloadForm.FileAlreadyExists(StaticFileInformation.xliveupdate_3_5_95_msi);
            if (msiPath == null || !File.Exists(msiPath))
            {
                // download the cabinet file
                DownloadForm form = new DownloadForm();
                DownloadFormResult fr = form.StartFileDownload(StaticFileInformation.titleupdate_3_5_95_cab, this);
                if (fr == DownloadFormResult.DownloadCancelled)
                {
                    MessageBox.Show("The download was cancelled.", "GfWL Utility", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (fr == DownloadFormResult.DownloadFailure)
                {
                    MessageBox.Show("The download failed.", "GfWL Utility", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string cabPath = form.GetOutputFilePath();
                if (!File.Exists(cabPath))
                {
                    MessageBox.Show("The download worked, but the CAB doesn't exist?!", "GfWL Utility", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CabinetExtractor cex = new CabinetExtractor(cabPath, UtilityFuncs.GetLocalDirectory("Downloads"));
                if (!cex.Extract() || DownloadForm.FileAlreadyExists(StaticFileInformation.xliveupdate_3_5_95_msi) == null)
                {
                    MessageBox.Show("Failed to extract the System Update CAB.", "GfWL Utility", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // delete the original cab file
                File.Delete(cabPath);
            }

            DoMSIDownloadAndInstall(StaticFileInformation.xliveupdate_3_5_95_msi);
            LoadRuntimeInfoGroup();
        }

        private void DoMSIDownloadAndInstall(FileInformation fi)
        {
            DownloadForm form = new DownloadForm();
            // check if the file already exists in the downloads cache
            string msiPath = DownloadForm.FileAlreadyExists(fi);
            if (msiPath == null || !File.Exists(msiPath))
            {
                // if it doesn't, download it
                DownloadFormResult fr = form.StartFileDownload(fi, this);
                if (fr == DownloadFormResult.DownloadCancelled)
                {
                    MessageBox.Show("The download was cancelled.", "GfWL Utility", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (fr == DownloadFormResult.DownloadFailure)
                {
                    MessageBox.Show("The download failed.", "GfWL Utility", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                msiPath = form.GetOutputFilePath();
                if (!File.Exists(msiPath))
                {
                    MessageBox.Show("The download worked, but the MSI doesn't exist?! Make sure any anti-virus software is not interfering.", "GfWL Utility", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Process p = new Process();
            p.StartInfo.FileName = "msiexec";
            p.StartInfo.Arguments = $"/qf /i \"{msiPath}\"";
            p.StartInfo.UseShellExecute = true;
            p.Start();
            p.WaitForExit();
        }

        private void installMarketplaceButton_Click(object sender, EventArgs e)
        {
            DoMSIDownloadAndInstall(StaticFileInformation.gfwlclient_msi);
            LoadMarketplaceInfoGroup();
        }

        private void installWLIDButton_Click(object sender, EventArgs e)
        {
            if (UtilityFuncs.IsWindows64Bit())
                DoMSIDownloadAndInstall(StaticFileInformation.wllogin_64_msi);
            DoMSIDownloadAndInstall(StaticFileInformation.wllogin_32_msi);
            LoadWLIDGroup();
        }

        private void showMsaCheck_CheckedChanged(object sender, EventArgs e)
        {
            KnownUser selected = (KnownUser)accountsListBox.SelectedItem;
            if (selected == null) return;
            if (showMsaCheck.Checked)
                msaEmailBox.Text = selected.MsaEmail;
            else
                msaEmailBox.Text = UtilityFuncs.CensorEmail(selected.MsaEmail);
        }

        private void viewCacheLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Directory.Exists(UtilityFuncs.GetLocalDirectory("")))
                Process.Start(UtilityFuncs.GetLocalDirectory(""));
            else
                MessageBox.Show("The cache folder does not exist.", "GfWL Utility", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void clearCacheButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(UtilityFuncs.GetLocalDirectory(""))) {
                try
                {
                    Directory.Delete(UtilityFuncs.GetLocalDirectory(""), true);
                    MessageBox.Show("The cache folder has been cleared!", "GfWL Utility", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } catch (Exception ex)
                {
                    MessageBox.Show($"The cache folder could not be deleted.\n\nError: {ex.Message}", "GfWL Utility", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("The cache folder does not exist.", "GfWL Utility", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void refreshProfileInfoButton_Click(object sender, EventArgs e)
        {
            ProfileInfoExtractor p = new ProfileInfoExtractor();
            p.ShowDialog(this);
            if (p.Success)
                SearchForProfiles();
        }
    }
}
