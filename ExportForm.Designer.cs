namespace GfWLUtility
{
    partial class ExportForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.userProfileCheckbox = new System.Windows.Forms.CheckBox();
            this.pcInfoCheckbox = new System.Windows.Forms.CheckBox();
            this.productKeyCheckbox = new System.Windows.Forms.CheckBox();
            this.exportButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.exportSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.userProfileCheckbox);
            this.groupBox1.Controls.Add(this.pcInfoCheckbox);
            this.groupBox1.Controls.Add(this.productKeyCheckbox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 145);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export Options";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(323, 26);
            this.label4.TabIndex = 5;
            this.label4.Text = "Downloaded and offline user profiles, along with any saved content\r\nsuch as DLC f" +
    "or games that used LIVE.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Saved product keys for each of your games.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Your PC ID and machine accounts used to log into games.";
            // 
            // userProfileCheckbox
            // 
            this.userProfileCheckbox.AutoSize = true;
            this.userProfileCheckbox.Checked = true;
            this.userProfileCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.userProfileCheckbox.Location = new System.Drawing.Point(9, 91);
            this.userProfileCheckbox.Name = "userProfileCheckbox";
            this.userProfileCheckbox.Size = new System.Drawing.Size(146, 17);
            this.userProfileCheckbox.TabIndex = 2;
            this.userProfileCheckbox.Text = "User Profiles and Content";
            this.userProfileCheckbox.UseVisualStyleBackColor = true;
            // 
            // pcInfoCheckbox
            // 
            this.pcInfoCheckbox.AutoSize = true;
            this.pcInfoCheckbox.Checked = true;
            this.pcInfoCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pcInfoCheckbox.Location = new System.Drawing.Point(9, 19);
            this.pcInfoCheckbox.Name = "pcInfoCheckbox";
            this.pcInfoCheckbox.Size = new System.Drawing.Size(95, 17);
            this.pcInfoCheckbox.TabIndex = 1;
            this.pcInfoCheckbox.Text = "PC Information";
            this.pcInfoCheckbox.UseVisualStyleBackColor = true;
            // 
            // productKeyCheckbox
            // 
            this.productKeyCheckbox.AutoSize = true;
            this.productKeyCheckbox.Checked = true;
            this.productKeyCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.productKeyCheckbox.Location = new System.Drawing.Point(9, 54);
            this.productKeyCheckbox.Name = "productKeyCheckbox";
            this.productKeyCheckbox.Size = new System.Drawing.Size(89, 17);
            this.productKeyCheckbox.TabIndex = 0;
            this.productKeyCheckbox.Text = "Product Keys";
            this.productKeyCheckbox.UseVisualStyleBackColor = true;
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(294, 163);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 2;
            this.exportButton.Text = "Export...";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(213, 163);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(12, 168);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(213, 13);
            this.statusLabel.TabIndex = 4;
            this.statusLabel.Text = "Some pretty long status message bla bla bla";
            this.statusLabel.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(269, 163);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Visible = false;
            // 
            // exportSaveFileDialog
            // 
            this.exportSaveFileDialog.Filter = "ZIP Archives|*.zip";
            this.exportSaveFileDialog.Title = "Games for Windows - LIVE Data Export";
            // 
            // ExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 197);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export Games for Windows - LIVE Data";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox userProfileCheckbox;
        private System.Windows.Forms.CheckBox pcInfoCheckbox;
        private System.Windows.Forms.CheckBox productKeyCheckbox;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.SaveFileDialog exportSaveFileDialog;
    }
}