using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GfWLUtility
{
    public partial class ExportForm : Form
    {
        public ExportForm()
        {
            InitializeComponent();
        }

        public void ExportPCInfo(string filename)
        {
            if (File.Exists(filename))
                File.Delete(filename);
            FileStream fs = new FileStream(filename, FileMode.Create);

            SavedPCInfo savedPCInfo = new SavedPCInfo();
            savedPCInfo.PCID = GfWLRegistry.GetPCID();
            // shit way to enumerate through every title to put it in the XML
            savedPCInfo.Titles = new SavedPCInfoTitle[TitleManager.KnownTitles.Count];
            int i_title = 0;
            foreach (KnownTitle title in TitleManager.KnownTitles.Values)
            {
                savedPCInfo.Titles[i_title] = new SavedPCInfoTitle();
                savedPCInfo.Titles[i_title].ID = title.TitleID.ToString("X8");

                if (productKeyCheckbox.Checked)
                {
                    string productKey = TitleManager.GetTitleProductKey(title.TitleID);
                    if (productKey != null)
                        savedPCInfo.Titles[i_title].Key = productKey;
                }

                // i really don't like this
                List<SavedPCInfoTitleSector> sectors = new List<SavedPCInfoTitleSector>();
                for (int i = 0; i < 0x14; i++)
                {
                    byte[] sectorData = TitleManager.GetConfigSector(title.TitleID, i);
                    if (sectorData != null)
                    {
                        // because it's big and unweildy and these are *mostly* null bytes, trim ending nulls
                        // this makes the mostly unused config sector basically invisible, and the account sector much smaller
                        int sectorTrailingNulls = UtilityFuncs.CountTrailingNulls(sectorData);
                        sectorData = sectorData.Take(sectorTrailingNulls + 1).ToArray();
                        SavedPCInfoTitleSector sec = new SavedPCInfoTitleSector()
                        {
                            ID = "0x" + i.ToString("X"),
                            Value = Convert.ToBase64String(sectorData)
                        };
                        sectors.Add(sec);
                    }
                }
                savedPCInfo.Titles[i_title].Sector = sectors.ToArray();
                i_title++;
            }
            savedPCInfo.Version = "1";
            savedPCInfo.CreatedBy = "GfWLUtility-beta1";
            savedPCInfo.CreatedAt = DateTime.Now.ToString();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(savedPCInfo.GetType());
            x.Serialize(fs, savedPCInfo);

            fs.Close();
        }

        public void ExportProductKeys(string filename)
        {
            if (File.Exists(filename))
                File.Delete(filename);
            List<string> productKeyStrings = new List<string>();
            productKeyStrings.Add("GfWL Utility Exported Product Keys:");
            productKeyStrings.Add("-----------------------------------");
            foreach (KnownTitle title in TitleManager.KnownTitles.Values)
            {
                string productKey = TitleManager.GetTitleProductKey(title.TitleID);
                if (productKey != null)
                    productKeyStrings.Add($"{title} : {productKey}");
            }
            productKeyStrings.Add("-----------------------------------");
            productKeyStrings.Add($"Generated at {DateTime.Now}");
            File.WriteAllLines(filename, productKeyStrings.ToArray());
        }

        public void CopyContent(string directory)
        {
            if (Directory.Exists(directory + @"\Content"))
                Directory.Delete(directory + @"\Content", true);
            if (Directory.Exists(directory + @"\DLC"))
                Directory.Delete(directory + @"\DLC", true);

            string xliveDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Microsoft\Xlive");

            if (Directory.Exists(xliveDir + @"\Content"))
            {
                Directory.CreateDirectory(directory + @"\Content");
                DirectoryInfo contentSourceInfo = new DirectoryInfo(xliveDir + @"\Content");
                DirectoryInfo contentTargetInfo = new DirectoryInfo(directory + @"\Content");
                UtilityFuncs.CopyFilesRecursively(contentSourceInfo, contentTargetInfo);
            }

            if (Directory.Exists(xliveDir + @"\DLC"))
            {
                Directory.CreateDirectory(directory + @"\DLC");
                DirectoryInfo dlcSourceInfo = new DirectoryInfo(xliveDir + @"\DLC");
                DirectoryInfo dlcTargetInfo = new DirectoryInfo(directory + @"\DLC");
                UtilityFuncs.CopyFilesRecursively(dlcSourceInfo, dlcTargetInfo);
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            Application.DoEvents();

            if (Directory.Exists("GfWL_Export"))
                Directory.Delete("GfWL_Export", true);

            Directory.CreateDirectory("GfWL_Export");
            if (pcInfoCheckbox.Checked)
                ExportPCInfo("GfWL_Export\\SavedPCInfo.xml");
            if (productKeyCheckbox.Checked)
                ExportProductKeys("GfWL_Export\\GfWL_ProductKeys.txt");
            if (userProfileCheckbox.Checked)
                CopyContent("GfWL_Export");

            UseWaitCursor = false;
            Application.DoEvents();

            DialogResult dr = 
                MessageBox.Show("Export created in 'GfWL_Export' folder. Open this folder now?", "GfWL Utility Export",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
                Process.Start("GfWL_Export");

            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
