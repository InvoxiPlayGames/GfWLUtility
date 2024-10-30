namespace GfWLUtility
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.runtimeTab = new System.Windows.Forms.TabPage();
            this.systemInfoGroup = new System.Windows.Forms.GroupBox();
            this.showPCIDCheckbox = new System.Windows.Forms.CheckBox();
            this.versionText = new System.Windows.Forms.TextBox();
            this.versionLabel = new System.Windows.Forms.Label();
            this.pcidText = new System.Windows.Forms.TextBox();
            this.pcidLabel = new System.Windows.Forms.Label();
            this.marketplaceGroup = new System.Windows.Forms.GroupBox();
            this.manageMarketplaceButton = new System.Windows.Forms.Button();
            this.marketplaceLogoPicture = new System.Windows.Forms.PictureBox();
            this.marketplaceInstallLabel = new System.Windows.Forms.Label();
            this.marketplaceVersionLabel = new System.Windows.Forms.Label();
            this.wlidGroup = new System.Windows.Forms.GroupBox();
            this.wlidLogoPicture = new System.Windows.Forms.PictureBox();
            this.wlidInstallLabel = new System.Windows.Forms.Label();
            this.wlidInfoLabel = new System.Windows.Forms.Label();
            this.runtimeGroup = new System.Windows.Forms.GroupBox();
            this.manageRuntimeButton = new System.Windows.Forms.Button();
            this.gfwlLogoPicture = new System.Windows.Forms.PictureBox();
            this.runtimeInstallLabel = new System.Windows.Forms.Label();
            this.runtimeVersionLabel = new System.Windows.Forms.Label();
            this.accountsTab = new System.Windows.Forms.TabPage();
            this.onlineXuidLabel = new System.Windows.Forms.Label();
            this.onlineXuidBox = new System.Windows.Forms.TextBox();
            this.accountGamerpic = new System.Windows.Forms.PictureBox();
            this.accountLiveCheck = new System.Windows.Forms.CheckBox();
            this.accountXuidBox = new System.Windows.Forms.TextBox();
            this.accountNameBox = new System.Windows.Forms.TextBox();
            this.accountXuidLabel = new System.Windows.Forms.Label();
            this.accountNameLabel = new System.Windows.Forms.Label();
            this.accountsListBox = new System.Windows.Forms.ListBox();
            this.gamesTab = new System.Windows.Forms.TabPage();
            this.titleIDFormattedLabel = new System.Windows.Forms.Label();
            this.titleIconPicture = new System.Windows.Forms.PictureBox();
            this.titleClearConfigLink = new System.Windows.Forms.LinkLabel();
            this.titleShowKeyCheck = new System.Windows.Forms.CheckBox();
            this.titleKeyLabel = new System.Windows.Forms.Label();
            this.titleProductKeyBox = new System.Windows.Forms.TextBox();
            this.titleIDBox = new System.Windows.Forms.TextBox();
            this.titleNameBox = new System.Windows.Forms.TextBox();
            this.titleIDLabel = new System.Windows.Forms.Label();
            this.titleNameLabel = new System.Windows.Forms.Label();
            this.gameListBox = new System.Windows.Forms.ListBox();
            this.utilitiesTab = new System.Windows.Forms.TabPage();
            this.connBlockGroup = new System.Windows.Forms.GroupBox();
            this.blockLiveInfoLabel = new System.Windows.Forms.Label();
            this.blockServicesInfoLabel = new System.Windows.Forms.Label();
            this.dataExportGroup = new System.Windows.Forms.GroupBox();
            this.dataExportInfoLabel = new System.Windows.Forms.Label();
            this.dataImportButton = new System.Windows.Forms.Button();
            this.dataExportButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.githubLinkLabel = new System.Windows.Forms.LinkLabel();
            this.appVersionLabel = new System.Windows.Forms.Label();
            this.installMarketplaceButton = new GfWLUtility.ElevatedButton();
            this.installWLIDButton = new GfWLUtility.ElevatedButton();
            this.installRuntimeButton = new GfWLUtility.ElevatedButton();
            this.blockServicesButton = new GfWLUtility.ElevatedButton();
            this.blockLiveButton = new GfWLUtility.ElevatedButton();
            this.mainTabControl.SuspendLayout();
            this.runtimeTab.SuspendLayout();
            this.systemInfoGroup.SuspendLayout();
            this.marketplaceGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.marketplaceLogoPicture)).BeginInit();
            this.wlidGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wlidLogoPicture)).BeginInit();
            this.runtimeGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gfwlLogoPicture)).BeginInit();
            this.accountsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accountGamerpic)).BeginInit();
            this.gamesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.titleIconPicture)).BeginInit();
            this.utilitiesTab.SuspendLayout();
            this.connBlockGroup.SuspendLayout();
            this.dataExportGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.runtimeTab);
            this.mainTabControl.Controls.Add(this.accountsTab);
            this.mainTabControl.Controls.Add(this.gamesTab);
            this.mainTabControl.Controls.Add(this.utilitiesTab);
            this.mainTabControl.Location = new System.Drawing.Point(12, 12);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(454, 250);
            this.mainTabControl.TabIndex = 0;
            // 
            // runtimeTab
            // 
            this.runtimeTab.Controls.Add(this.systemInfoGroup);
            this.runtimeTab.Controls.Add(this.marketplaceGroup);
            this.runtimeTab.Controls.Add(this.wlidGroup);
            this.runtimeTab.Controls.Add(this.runtimeGroup);
            this.runtimeTab.Location = new System.Drawing.Point(4, 22);
            this.runtimeTab.Name = "runtimeTab";
            this.runtimeTab.Padding = new System.Windows.Forms.Padding(3);
            this.runtimeTab.Size = new System.Drawing.Size(446, 224);
            this.runtimeTab.TabIndex = 0;
            this.runtimeTab.Text = "Runtime";
            this.runtimeTab.UseVisualStyleBackColor = true;
            // 
            // systemInfoGroup
            // 
            this.systemInfoGroup.Controls.Add(this.showPCIDCheckbox);
            this.systemInfoGroup.Controls.Add(this.versionText);
            this.systemInfoGroup.Controls.Add(this.versionLabel);
            this.systemInfoGroup.Controls.Add(this.pcidText);
            this.systemInfoGroup.Controls.Add(this.pcidLabel);
            this.systemInfoGroup.Location = new System.Drawing.Point(251, 115);
            this.systemInfoGroup.Name = "systemInfoGroup";
            this.systemInfoGroup.Size = new System.Drawing.Size(189, 103);
            this.systemInfoGroup.TabIndex = 13;
            this.systemInfoGroup.TabStop = false;
            this.systemInfoGroup.Text = "System Info";
            // 
            // showPCIDCheckbox
            // 
            this.showPCIDCheckbox.AutoSize = true;
            this.showPCIDCheckbox.Location = new System.Drawing.Point(9, 55);
            this.showPCIDCheckbox.Name = "showPCIDCheckbox";
            this.showPCIDCheckbox.Size = new System.Drawing.Size(97, 17);
            this.showPCIDCheckbox.TabIndex = 6;
            this.showPCIDCheckbox.Text = "Show full PCID";
            this.showPCIDCheckbox.UseVisualStyleBackColor = true;
            this.showPCIDCheckbox.CheckedChanged += new System.EventHandler(this.showPCIDCheckbox_CheckedChanged);
            // 
            // versionText
            // 
            this.versionText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.versionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionText.Location = new System.Drawing.Point(57, 36);
            this.versionText.Name = "versionText";
            this.versionText.ReadOnly = true;
            this.versionText.Size = new System.Drawing.Size(126, 13);
            this.versionText.TabIndex = 5;
            this.versionText.Text = "2.0.0000.0";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(6, 35);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(45, 13);
            this.versionLabel.TabIndex = 4;
            this.versionLabel.Text = "Version:";
            // 
            // pcidText
            // 
            this.pcidText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pcidText.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pcidText.Location = new System.Drawing.Point(57, 19);
            this.pcidText.Name = "pcidText";
            this.pcidText.ReadOnly = true;
            this.pcidText.Size = new System.Drawing.Size(126, 13);
            this.pcidText.TabIndex = 3;
            this.pcidText.Text = "AABBCCDD00112233";
            // 
            // pcidLabel
            // 
            this.pcidLabel.AutoSize = true;
            this.pcidLabel.Location = new System.Drawing.Point(6, 19);
            this.pcidLabel.Name = "pcidLabel";
            this.pcidLabel.Size = new System.Drawing.Size(35, 13);
            this.pcidLabel.TabIndex = 2;
            this.pcidLabel.Text = "PCID:";
            // 
            // marketplaceGroup
            // 
            this.marketplaceGroup.Controls.Add(this.manageMarketplaceButton);
            this.marketplaceGroup.Controls.Add(this.marketplaceLogoPicture);
            this.marketplaceGroup.Controls.Add(this.marketplaceInstallLabel);
            this.marketplaceGroup.Controls.Add(this.installMarketplaceButton);
            this.marketplaceGroup.Controls.Add(this.marketplaceVersionLabel);
            this.marketplaceGroup.Location = new System.Drawing.Point(6, 115);
            this.marketplaceGroup.Name = "marketplaceGroup";
            this.marketplaceGroup.Size = new System.Drawing.Size(239, 103);
            this.marketplaceGroup.TabIndex = 12;
            this.marketplaceGroup.TabStop = false;
            this.marketplaceGroup.Text = "Games for Windows Marketplace";
            // 
            // manageMarketplaceButton
            // 
            this.manageMarketplaceButton.Location = new System.Drawing.Point(169, 73);
            this.manageMarketplaceButton.Name = "manageMarketplaceButton";
            this.manageMarketplaceButton.Size = new System.Drawing.Size(64, 23);
            this.manageMarketplaceButton.TabIndex = 11;
            this.manageMarketplaceButton.Text = "Manage...";
            this.manageMarketplaceButton.UseVisualStyleBackColor = true;
            this.manageMarketplaceButton.Visible = false;
            // 
            // marketplaceLogoPicture
            // 
            this.marketplaceLogoPicture.Image = global::GfWLUtility.Properties.Resources.GfWLUnknown;
            this.marketplaceLogoPicture.Location = new System.Drawing.Point(6, 19);
            this.marketplaceLogoPicture.Name = "marketplaceLogoPicture";
            this.marketplaceLogoPicture.Size = new System.Drawing.Size(48, 48);
            this.marketplaceLogoPicture.TabIndex = 3;
            this.marketplaceLogoPicture.TabStop = false;
            // 
            // marketplaceInstallLabel
            // 
            this.marketplaceInstallLabel.AutoSize = true;
            this.marketplaceInstallLabel.Location = new System.Drawing.Point(60, 19);
            this.marketplaceInstallLabel.Name = "marketplaceInstallLabel";
            this.marketplaceInstallLabel.Size = new System.Drawing.Size(165, 13);
            this.marketplaceInstallLabel.TabIndex = 0;
            this.marketplaceInstallLabel.Text = "Marketplace installed placeholder";
            // 
            // marketplaceVersionLabel
            // 
            this.marketplaceVersionLabel.AutoSize = true;
            this.marketplaceVersionLabel.Location = new System.Drawing.Point(60, 37);
            this.marketplaceVersionLabel.Name = "marketplaceVersionLabel";
            this.marketplaceVersionLabel.Size = new System.Drawing.Size(161, 13);
            this.marketplaceVersionLabel.TabIndex = 1;
            this.marketplaceVersionLabel.Text = "Marketplace version placeholder";
            // 
            // wlidGroup
            // 
            this.wlidGroup.Controls.Add(this.wlidLogoPicture);
            this.wlidGroup.Controls.Add(this.wlidInstallLabel);
            this.wlidGroup.Controls.Add(this.installWLIDButton);
            this.wlidGroup.Controls.Add(this.wlidInfoLabel);
            this.wlidGroup.Location = new System.Drawing.Point(251, 6);
            this.wlidGroup.Name = "wlidGroup";
            this.wlidGroup.Size = new System.Drawing.Size(189, 103);
            this.wlidGroup.TabIndex = 11;
            this.wlidGroup.TabStop = false;
            this.wlidGroup.Text = "Windows Live ID assistant";
            // 
            // wlidLogoPicture
            // 
            this.wlidLogoPicture.Image = global::GfWLUtility.Properties.Resources.WLIDUnknown;
            this.wlidLogoPicture.Location = new System.Drawing.Point(6, 19);
            this.wlidLogoPicture.Name = "wlidLogoPicture";
            this.wlidLogoPicture.Size = new System.Drawing.Size(48, 48);
            this.wlidLogoPicture.TabIndex = 6;
            this.wlidLogoPicture.TabStop = false;
            // 
            // wlidInstallLabel
            // 
            this.wlidInstallLabel.AutoSize = true;
            this.wlidInstallLabel.Location = new System.Drawing.Point(60, 19);
            this.wlidInstallLabel.Name = "wlidInstallLabel";
            this.wlidInstallLabel.Size = new System.Drawing.Size(134, 13);
            this.wlidInstallLabel.TabIndex = 5;
            this.wlidInstallLabel.Text = "WLID installed placeholder";
            // 
            // wlidInfoLabel
            // 
            this.wlidInfoLabel.AutoSize = true;
            this.wlidInfoLabel.Location = new System.Drawing.Point(60, 37);
            this.wlidInfoLabel.Name = "wlidInfoLabel";
            this.wlidInfoLabel.Size = new System.Drawing.Size(113, 13);
            this.wlidInfoLabel.TabIndex = 7;
            this.wlidInfoLabel.Text = "WLID info placeholder";
            // 
            // runtimeGroup
            // 
            this.runtimeGroup.Controls.Add(this.manageRuntimeButton);
            this.runtimeGroup.Controls.Add(this.gfwlLogoPicture);
            this.runtimeGroup.Controls.Add(this.runtimeInstallLabel);
            this.runtimeGroup.Controls.Add(this.installRuntimeButton);
            this.runtimeGroup.Controls.Add(this.runtimeVersionLabel);
            this.runtimeGroup.Location = new System.Drawing.Point(6, 6);
            this.runtimeGroup.Name = "runtimeGroup";
            this.runtimeGroup.Size = new System.Drawing.Size(239, 103);
            this.runtimeGroup.TabIndex = 10;
            this.runtimeGroup.TabStop = false;
            this.runtimeGroup.Text = "Games for Windows - LIVE Runtime";
            // 
            // manageRuntimeButton
            // 
            this.manageRuntimeButton.Location = new System.Drawing.Point(169, 73);
            this.manageRuntimeButton.Name = "manageRuntimeButton";
            this.manageRuntimeButton.Size = new System.Drawing.Size(64, 23);
            this.manageRuntimeButton.TabIndex = 11;
            this.manageRuntimeButton.Text = "Manage...";
            this.manageRuntimeButton.UseVisualStyleBackColor = true;
            this.manageRuntimeButton.Visible = false;
            // 
            // gfwlLogoPicture
            // 
            this.gfwlLogoPicture.Image = global::GfWLUtility.Properties.Resources.GfWLUnknown;
            this.gfwlLogoPicture.Location = new System.Drawing.Point(6, 19);
            this.gfwlLogoPicture.Name = "gfwlLogoPicture";
            this.gfwlLogoPicture.Size = new System.Drawing.Size(48, 48);
            this.gfwlLogoPicture.TabIndex = 3;
            this.gfwlLogoPicture.TabStop = false;
            // 
            // runtimeInstallLabel
            // 
            this.runtimeInstallLabel.AutoSize = true;
            this.runtimeInstallLabel.Location = new System.Drawing.Point(60, 19);
            this.runtimeInstallLabel.Name = "runtimeInstallLabel";
            this.runtimeInstallLabel.Size = new System.Drawing.Size(145, 13);
            this.runtimeInstallLabel.TabIndex = 0;
            this.runtimeInstallLabel.Text = "Runtime installed placeholder";
            // 
            // runtimeVersionLabel
            // 
            this.runtimeVersionLabel.AutoSize = true;
            this.runtimeVersionLabel.Location = new System.Drawing.Point(60, 37);
            this.runtimeVersionLabel.Name = "runtimeVersionLabel";
            this.runtimeVersionLabel.Size = new System.Drawing.Size(141, 13);
            this.runtimeVersionLabel.TabIndex = 1;
            this.runtimeVersionLabel.Text = "Runtime version placeholder";
            // 
            // accountsTab
            // 
            this.accountsTab.Controls.Add(this.onlineXuidLabel);
            this.accountsTab.Controls.Add(this.onlineXuidBox);
            this.accountsTab.Controls.Add(this.accountGamerpic);
            this.accountsTab.Controls.Add(this.accountLiveCheck);
            this.accountsTab.Controls.Add(this.accountXuidBox);
            this.accountsTab.Controls.Add(this.accountNameBox);
            this.accountsTab.Controls.Add(this.accountXuidLabel);
            this.accountsTab.Controls.Add(this.accountNameLabel);
            this.accountsTab.Controls.Add(this.accountsListBox);
            this.accountsTab.Location = new System.Drawing.Point(4, 22);
            this.accountsTab.Name = "accountsTab";
            this.accountsTab.Padding = new System.Windows.Forms.Padding(3);
            this.accountsTab.Size = new System.Drawing.Size(446, 224);
            this.accountsTab.TabIndex = 1;
            this.accountsTab.Text = "Profiles";
            this.accountsTab.UseVisualStyleBackColor = true;
            // 
            // onlineXuidLabel
            // 
            this.onlineXuidLabel.AutoSize = true;
            this.onlineXuidLabel.Location = new System.Drawing.Point(195, 84);
            this.onlineXuidLabel.Name = "onlineXuidLabel";
            this.onlineXuidLabel.Size = new System.Drawing.Size(40, 13);
            this.onlineXuidLabel.TabIndex = 18;
            this.onlineXuidLabel.Text = "Online:";
            this.onlineXuidLabel.Visible = false;
            // 
            // onlineXuidBox
            // 
            this.onlineXuidBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onlineXuidBox.Location = new System.Drawing.Point(237, 81);
            this.onlineXuidBox.Name = "onlineXuidBox";
            this.onlineXuidBox.ReadOnly = true;
            this.onlineXuidBox.Size = new System.Drawing.Size(129, 20);
            this.onlineXuidBox.TabIndex = 17;
            this.onlineXuidBox.Text = "DEADBEEFDEADBEEF";
            this.onlineXuidBox.Visible = false;
            // 
            // accountGamerpic
            // 
            this.accountGamerpic.Location = new System.Drawing.Point(376, 58);
            this.accountGamerpic.Name = "accountGamerpic";
            this.accountGamerpic.Size = new System.Drawing.Size(64, 64);
            this.accountGamerpic.TabIndex = 16;
            this.accountGamerpic.TabStop = false;
            // 
            // accountLiveCheck
            // 
            this.accountLiveCheck.AutoSize = true;
            this.accountLiveCheck.Enabled = false;
            this.accountLiveCheck.Location = new System.Drawing.Point(198, 58);
            this.accountLiveCheck.Name = "accountLiveCheck";
            this.accountLiveCheck.Size = new System.Drawing.Size(108, 17);
            this.accountLiveCheck.TabIndex = 15;
            this.accountLiveCheck.Text = "Xbox LIVE Profile";
            this.accountLiveCheck.UseVisualStyleBackColor = true;
            this.accountLiveCheck.Visible = false;
            // 
            // accountXuidBox
            // 
            this.accountXuidBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountXuidBox.Location = new System.Drawing.Point(237, 32);
            this.accountXuidBox.Name = "accountXuidBox";
            this.accountXuidBox.ReadOnly = true;
            this.accountXuidBox.Size = new System.Drawing.Size(203, 20);
            this.accountXuidBox.TabIndex = 14;
            this.accountXuidBox.Text = "DEADBEEFDEADBEEF";
            // 
            // accountNameBox
            // 
            this.accountNameBox.Location = new System.Drawing.Point(257, 6);
            this.accountNameBox.Name = "accountNameBox";
            this.accountNameBox.ReadOnly = true;
            this.accountNameBox.Size = new System.Drawing.Size(183, 20);
            this.accountNameBox.TabIndex = 13;
            this.accountNameBox.Text = "WWWWWWWWWWWWWWW";
            // 
            // accountXuidLabel
            // 
            this.accountXuidLabel.AutoSize = true;
            this.accountXuidLabel.Location = new System.Drawing.Point(195, 35);
            this.accountXuidLabel.Name = "accountXuidLabel";
            this.accountXuidLabel.Size = new System.Drawing.Size(36, 13);
            this.accountXuidLabel.TabIndex = 12;
            this.accountXuidLabel.Text = "XUID:";
            // 
            // accountNameLabel
            // 
            this.accountNameLabel.AutoSize = true;
            this.accountNameLabel.Location = new System.Drawing.Point(195, 9);
            this.accountNameLabel.Name = "accountNameLabel";
            this.accountNameLabel.Size = new System.Drawing.Size(56, 13);
            this.accountNameLabel.TabIndex = 11;
            this.accountNameLabel.Text = "Gamertag:";
            // 
            // accountsListBox
            // 
            this.accountsListBox.FormattingEnabled = true;
            this.accountsListBox.Location = new System.Drawing.Point(6, 6);
            this.accountsListBox.Name = "accountsListBox";
            this.accountsListBox.Size = new System.Drawing.Size(183, 212);
            this.accountsListBox.TabIndex = 10;
            this.accountsListBox.SelectedIndexChanged += new System.EventHandler(this.accountsListBox_SelectedIndexChanged);
            // 
            // gamesTab
            // 
            this.gamesTab.Controls.Add(this.titleIDFormattedLabel);
            this.gamesTab.Controls.Add(this.titleIconPicture);
            this.gamesTab.Controls.Add(this.titleClearConfigLink);
            this.gamesTab.Controls.Add(this.titleShowKeyCheck);
            this.gamesTab.Controls.Add(this.titleKeyLabel);
            this.gamesTab.Controls.Add(this.titleProductKeyBox);
            this.gamesTab.Controls.Add(this.titleIDBox);
            this.gamesTab.Controls.Add(this.titleNameBox);
            this.gamesTab.Controls.Add(this.titleIDLabel);
            this.gamesTab.Controls.Add(this.titleNameLabel);
            this.gamesTab.Controls.Add(this.gameListBox);
            this.gamesTab.Location = new System.Drawing.Point(4, 22);
            this.gamesTab.Name = "gamesTab";
            this.gamesTab.Padding = new System.Windows.Forms.Padding(3);
            this.gamesTab.Size = new System.Drawing.Size(446, 224);
            this.gamesTab.TabIndex = 2;
            this.gamesTab.Text = "Games";
            this.gamesTab.UseVisualStyleBackColor = true;
            // 
            // titleIDFormattedLabel
            // 
            this.titleIDFormattedLabel.AutoSize = true;
            this.titleIDFormattedLabel.Location = new System.Drawing.Point(314, 35);
            this.titleIDFormattedLabel.Name = "titleIDFormattedLabel";
            this.titleIDFormattedLabel.Size = new System.Drawing.Size(62, 13);
            this.titleIDFormattedLabel.TabIndex = 18;
            this.titleIDFormattedLabel.Text = "(WW-9999)";
            // 
            // titleIconPicture
            // 
            this.titleIconPicture.Location = new System.Drawing.Point(376, 58);
            this.titleIconPicture.Name = "titleIconPicture";
            this.titleIconPicture.Size = new System.Drawing.Size(64, 64);
            this.titleIconPicture.TabIndex = 17;
            this.titleIconPicture.TabStop = false;
            // 
            // titleClearConfigLink
            // 
            this.titleClearConfigLink.AutoSize = true;
            this.titleClearConfigLink.Location = new System.Drawing.Point(394, 35);
            this.titleClearConfigLink.Name = "titleClearConfigLink";
            this.titleClearConfigLink.Size = new System.Drawing.Size(46, 13);
            this.titleClearConfigLink.TabIndex = 9;
            this.titleClearConfigLink.TabStop = true;
            this.titleClearConfigLink.Text = "Config...";
            this.titleClearConfigLink.Visible = false;
            // 
            // titleShowKeyCheck
            // 
            this.titleShowKeyCheck.AutoSize = true;
            this.titleShowKeyCheck.Location = new System.Drawing.Point(387, 181);
            this.titleShowKeyCheck.Name = "titleShowKeyCheck";
            this.titleShowKeyCheck.Size = new System.Drawing.Size(53, 17);
            this.titleShowKeyCheck.TabIndex = 7;
            this.titleShowKeyCheck.Text = "Show";
            this.titleShowKeyCheck.UseVisualStyleBackColor = true;
            this.titleShowKeyCheck.CheckedChanged += new System.EventHandler(this.titleShowKeyCheck_CheckedChanged);
            // 
            // titleKeyLabel
            // 
            this.titleKeyLabel.AutoSize = true;
            this.titleKeyLabel.Location = new System.Drawing.Point(195, 182);
            this.titleKeyLabel.Name = "titleKeyLabel";
            this.titleKeyLabel.Size = new System.Drawing.Size(68, 13);
            this.titleKeyLabel.TabIndex = 6;
            this.titleKeyLabel.Text = "Product Key:";
            // 
            // titleProductKeyBox
            // 
            this.titleProductKeyBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleProductKeyBox.Location = new System.Drawing.Point(195, 198);
            this.titleProductKeyBox.Name = "titleProductKeyBox";
            this.titleProductKeyBox.ReadOnly = true;
            this.titleProductKeyBox.Size = new System.Drawing.Size(245, 20);
            this.titleProductKeyBox.TabIndex = 5;
            this.titleProductKeyBox.Text = "WWWWW-WWWWW-WWWWW-WWWWW-WWWWW";
            // 
            // titleIDBox
            // 
            this.titleIDBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleIDBox.Location = new System.Drawing.Point(245, 32);
            this.titleIDBox.Name = "titleIDBox";
            this.titleIDBox.ReadOnly = true;
            this.titleIDBox.Size = new System.Drawing.Size(63, 20);
            this.titleIDBox.TabIndex = 4;
            this.titleIDBox.Text = "DEADF00D";
            // 
            // titleNameBox
            // 
            this.titleNameBox.Location = new System.Drawing.Point(270, 6);
            this.titleNameBox.Name = "titleNameBox";
            this.titleNameBox.ReadOnly = true;
            this.titleNameBox.Size = new System.Drawing.Size(170, 20);
            this.titleNameBox.TabIndex = 3;
            this.titleNameBox.Text = "Super Awesome Long Game Name Title";
            // 
            // titleIDLabel
            // 
            this.titleIDLabel.AutoSize = true;
            this.titleIDLabel.Location = new System.Drawing.Point(195, 35);
            this.titleIDLabel.Name = "titleIDLabel";
            this.titleIDLabel.Size = new System.Drawing.Size(44, 13);
            this.titleIDLabel.TabIndex = 2;
            this.titleIDLabel.Text = "Title ID:";
            // 
            // titleNameLabel
            // 
            this.titleNameLabel.AutoSize = true;
            this.titleNameLabel.Location = new System.Drawing.Point(195, 9);
            this.titleNameLabel.Name = "titleNameLabel";
            this.titleNameLabel.Size = new System.Drawing.Size(69, 13);
            this.titleNameLabel.TabIndex = 1;
            this.titleNameLabel.Text = "Game Name:";
            // 
            // gameListBox
            // 
            this.gameListBox.FormattingEnabled = true;
            this.gameListBox.Location = new System.Drawing.Point(6, 6);
            this.gameListBox.Name = "gameListBox";
            this.gameListBox.Size = new System.Drawing.Size(183, 212);
            this.gameListBox.TabIndex = 0;
            this.gameListBox.SelectedIndexChanged += new System.EventHandler(this.gameListBox_SelectedIndexChanged);
            // 
            // utilitiesTab
            // 
            this.utilitiesTab.Controls.Add(this.connBlockGroup);
            this.utilitiesTab.Controls.Add(this.dataExportGroup);
            this.utilitiesTab.Location = new System.Drawing.Point(4, 22);
            this.utilitiesTab.Name = "utilitiesTab";
            this.utilitiesTab.Padding = new System.Windows.Forms.Padding(3);
            this.utilitiesTab.Size = new System.Drawing.Size(446, 224);
            this.utilitiesTab.TabIndex = 5;
            this.utilitiesTab.Text = "Utilities";
            this.utilitiesTab.UseVisualStyleBackColor = true;
            // 
            // connBlockGroup
            // 
            this.connBlockGroup.Controls.Add(this.blockLiveInfoLabel);
            this.connBlockGroup.Controls.Add(this.blockServicesInfoLabel);
            this.connBlockGroup.Controls.Add(this.blockServicesButton);
            this.connBlockGroup.Controls.Add(this.blockLiveButton);
            this.connBlockGroup.Location = new System.Drawing.Point(6, 63);
            this.connBlockGroup.Name = "connBlockGroup";
            this.connBlockGroup.Size = new System.Drawing.Size(434, 85);
            this.connBlockGroup.TabIndex = 4;
            this.connBlockGroup.TabStop = false;
            this.connBlockGroup.Text = "Connection Blocking";
            // 
            // blockLiveInfoLabel
            // 
            this.blockLiveInfoLabel.AutoSize = true;
            this.blockLiveInfoLabel.Location = new System.Drawing.Point(136, 58);
            this.blockLiveInfoLabel.Name = "blockLiveInfoLabel";
            this.blockLiveInfoLabel.Size = new System.Drawing.Size(275, 13);
            this.blockLiveInfoLabel.TabIndex = 4;
            this.blockLiveInfoLabel.Text = "Blocks *ALL* connections to Games for Windows - LIVE.";
            // 
            // blockServicesInfoLabel
            // 
            this.blockServicesInfoLabel.AutoSize = true;
            this.blockServicesInfoLabel.Location = new System.Drawing.Point(136, 24);
            this.blockServicesInfoLabel.Name = "blockServicesInfoLabel";
            this.blockServicesInfoLabel.Size = new System.Drawing.Size(272, 26);
            this.blockServicesInfoLabel.TabIndex = 3;
            this.blockServicesInfoLabel.Text = "Blocks GfWL marketplace services to speed up loading.\r\n(Recommended)";
            // 
            // dataExportGroup
            // 
            this.dataExportGroup.Controls.Add(this.dataExportInfoLabel);
            this.dataExportGroup.Controls.Add(this.dataImportButton);
            this.dataExportGroup.Controls.Add(this.dataExportButton);
            this.dataExportGroup.Location = new System.Drawing.Point(6, 6);
            this.dataExportGroup.Name = "dataExportGroup";
            this.dataExportGroup.Size = new System.Drawing.Size(434, 51);
            this.dataExportGroup.TabIndex = 0;
            this.dataExportGroup.TabStop = false;
            this.dataExportGroup.Text = "Data Export";
            // 
            // dataExportInfoLabel
            // 
            this.dataExportInfoLabel.AutoSize = true;
            this.dataExportInfoLabel.Location = new System.Drawing.Point(168, 24);
            this.dataExportInfoLabel.Name = "dataExportInfoLabel";
            this.dataExportInfoLabel.Size = new System.Drawing.Size(225, 13);
            this.dataExportInfoLabel.TabIndex = 3;
            this.dataExportInfoLabel.Text = "Export or import your data to another computer";
            // 
            // dataImportButton
            // 
            this.dataImportButton.Location = new System.Drawing.Point(6, 19);
            this.dataImportButton.Name = "dataImportButton";
            this.dataImportButton.Size = new System.Drawing.Size(75, 23);
            this.dataImportButton.TabIndex = 1;
            this.dataImportButton.Text = "Import...";
            this.dataImportButton.UseVisualStyleBackColor = true;
            this.dataImportButton.Click += new System.EventHandler(this.dataImportButton_Click);
            // 
            // dataExportButton
            // 
            this.dataExportButton.Location = new System.Drawing.Point(87, 19);
            this.dataExportButton.Name = "dataExportButton";
            this.dataExportButton.Size = new System.Drawing.Size(75, 23);
            this.dataExportButton.TabIndex = 0;
            this.dataExportButton.Text = "Export...";
            this.dataExportButton.UseVisualStyleBackColor = true;
            this.dataExportButton.Click += new System.EventHandler(this.dataExportButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Unofficial utility by Emma / InvoxiPlayGames. Not affiliated with Microsoft.";
            // 
            // githubLinkLabel
            // 
            this.githubLinkLabel.AutoSize = true;
            this.githubLinkLabel.Location = new System.Drawing.Point(13, 280);
            this.githubLinkLabel.Name = "githubLinkLabel";
            this.githubLinkLabel.Size = new System.Drawing.Size(239, 13);
            this.githubLinkLabel.TabIndex = 2;
            this.githubLinkLabel.TabStop = true;
            this.githubLinkLabel.Text = "https://github.com/InvoxiPlayGames/GfWLUtility";
            this.githubLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.githubLinkLabel_LinkClicked);
            // 
            // appVersionLabel
            // 
            this.appVersionLabel.AutoSize = true;
            this.appVersionLabel.Location = new System.Drawing.Point(359, 280);
            this.appVersionLabel.Name = "appVersionLabel";
            this.appVersionLabel.Size = new System.Drawing.Size(107, 13);
            this.appVersionLabel.TabIndex = 3;
            this.appVersionLabel.Text = "version 1.0.0.0-beta1";
            // 
            // installMarketplaceButton
            // 
            this.installMarketplaceButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.installMarketplaceButton.Location = new System.Drawing.Point(6, 73);
            this.installMarketplaceButton.Name = "installMarketplaceButton";
            this.installMarketplaceButton.Size = new System.Drawing.Size(227, 23);
            this.installMarketplaceButton.TabIndex = 8;
            this.installMarketplaceButton.Text = "Install marketplace";
            this.installMarketplaceButton.UseVisualStyleBackColor = true;
            this.installMarketplaceButton.Click += new System.EventHandler(this.installMarketplaceButton_Click);
            // 
            // installWLIDButton
            // 
            this.installWLIDButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.installWLIDButton.Location = new System.Drawing.Point(6, 73);
            this.installWLIDButton.Name = "installWLIDButton";
            this.installWLIDButton.Size = new System.Drawing.Size(177, 23);
            this.installWLIDButton.TabIndex = 9;
            this.installWLIDButton.Text = "Install sign-in assistant";
            this.installWLIDButton.UseVisualStyleBackColor = true;
            this.installWLIDButton.Click += new System.EventHandler(this.installWLIDButton_Click);
            // 
            // installRuntimeButton
            // 
            this.installRuntimeButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.installRuntimeButton.Location = new System.Drawing.Point(6, 73);
            this.installRuntimeButton.Name = "installRuntimeButton";
            this.installRuntimeButton.Size = new System.Drawing.Size(227, 23);
            this.installRuntimeButton.TabIndex = 8;
            this.installRuntimeButton.Text = "Install runtime";
            this.installRuntimeButton.UseVisualStyleBackColor = true;
            this.installRuntimeButton.Click += new System.EventHandler(this.installRuntimeButton_Click);
            // 
            // blockServicesButton
            // 
            this.blockServicesButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.blockServicesButton.Location = new System.Drawing.Point(6, 19);
            this.blockServicesButton.Name = "blockServicesButton";
            this.blockServicesButton.Size = new System.Drawing.Size(124, 23);
            this.blockServicesButton.TabIndex = 1;
            this.blockServicesButton.Text = "Block Services";
            this.blockServicesButton.UseVisualStyleBackColor = true;
            this.blockServicesButton.Click += new System.EventHandler(this.blockServicesButton_Click);
            // 
            // blockLiveButton
            // 
            this.blockLiveButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.blockLiveButton.Location = new System.Drawing.Point(6, 53);
            this.blockLiveButton.Name = "blockLiveButton";
            this.blockLiveButton.Size = new System.Drawing.Size(124, 23);
            this.blockLiveButton.TabIndex = 0;
            this.blockLiveButton.Text = "Block LIVE";
            this.blockLiveButton.UseVisualStyleBackColor = true;
            this.blockLiveButton.Click += new System.EventHandler(this.blockLiveButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 304);
            this.Controls.Add(this.appVersionLabel);
            this.Controls.Add(this.githubLinkLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mainTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GfWL Utility";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.mainTabControl.ResumeLayout(false);
            this.runtimeTab.ResumeLayout(false);
            this.systemInfoGroup.ResumeLayout(false);
            this.systemInfoGroup.PerformLayout();
            this.marketplaceGroup.ResumeLayout(false);
            this.marketplaceGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.marketplaceLogoPicture)).EndInit();
            this.wlidGroup.ResumeLayout(false);
            this.wlidGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wlidLogoPicture)).EndInit();
            this.runtimeGroup.ResumeLayout(false);
            this.runtimeGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gfwlLogoPicture)).EndInit();
            this.accountsTab.ResumeLayout(false);
            this.accountsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accountGamerpic)).EndInit();
            this.gamesTab.ResumeLayout(false);
            this.gamesTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.titleIconPicture)).EndInit();
            this.utilitiesTab.ResumeLayout(false);
            this.connBlockGroup.ResumeLayout(false);
            this.connBlockGroup.PerformLayout();
            this.dataExportGroup.ResumeLayout(false);
            this.dataExportGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage runtimeTab;
        private System.Windows.Forms.TabPage accountsTab;
        private System.Windows.Forms.Label runtimeVersionLabel;
        private System.Windows.Forms.Label runtimeInstallLabel;
        private System.Windows.Forms.TabPage gamesTab;
        private System.Windows.Forms.PictureBox gfwlLogoPicture;
        private System.Windows.Forms.Label wlidInfoLabel;
        private System.Windows.Forms.PictureBox wlidLogoPicture;
        private System.Windows.Forms.Label wlidInstallLabel;
        private System.Windows.Forms.TabPage utilitiesTab;
        private System.Windows.Forms.GroupBox dataExportGroup;
        private System.Windows.Forms.Label dataExportInfoLabel;
        private System.Windows.Forms.Button dataImportButton;
        private System.Windows.Forms.Button dataExportButton;
        private System.Windows.Forms.GroupBox wlidGroup;
        private System.Windows.Forms.GroupBox runtimeGroup;
        private System.Windows.Forms.Button manageRuntimeButton;
        private System.Windows.Forms.GroupBox systemInfoGroup;
        private System.Windows.Forms.GroupBox marketplaceGroup;
        private System.Windows.Forms.Button manageMarketplaceButton;
        private System.Windows.Forms.PictureBox marketplaceLogoPicture;
        private System.Windows.Forms.Label marketplaceInstallLabel;
        private System.Windows.Forms.Label marketplaceVersionLabel;
        private System.Windows.Forms.TextBox versionText;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.TextBox pcidText;
        private System.Windows.Forms.Label pcidLabel;
        private System.Windows.Forms.CheckBox showPCIDCheckbox;
        private ElevatedButton installRuntimeButton;
        private ElevatedButton installWLIDButton;
        private ElevatedButton installMarketplaceButton;
        private System.Windows.Forms.CheckBox titleShowKeyCheck;
        private System.Windows.Forms.Label titleKeyLabel;
        private System.Windows.Forms.TextBox titleProductKeyBox;
        private System.Windows.Forms.TextBox titleIDBox;
        private System.Windows.Forms.TextBox titleNameBox;
        private System.Windows.Forms.Label titleIDLabel;
        private System.Windows.Forms.Label titleNameLabel;
        private System.Windows.Forms.ListBox gameListBox;
        private System.Windows.Forms.LinkLabel titleClearConfigLink;
        private System.Windows.Forms.CheckBox accountLiveCheck;
        private System.Windows.Forms.TextBox accountXuidBox;
        private System.Windows.Forms.TextBox accountNameBox;
        private System.Windows.Forms.Label accountXuidLabel;
        private System.Windows.Forms.Label accountNameLabel;
        private System.Windows.Forms.ListBox accountsListBox;
        private System.Windows.Forms.PictureBox accountGamerpic;
        private System.Windows.Forms.PictureBox titleIconPicture;
        private System.Windows.Forms.GroupBox connBlockGroup;
        private System.Windows.Forms.Label blockServicesInfoLabel;
        private System.Windows.Forms.Label blockLiveInfoLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel githubLinkLabel;
        private System.Windows.Forms.Label appVersionLabel;
        private ElevatedButton blockServicesButton;
        private ElevatedButton blockLiveButton;
        private System.Windows.Forms.Label titleIDFormattedLabel;
        private System.Windows.Forms.Label onlineXuidLabel;
        private System.Windows.Forms.TextBox onlineXuidBox;
    }
}

