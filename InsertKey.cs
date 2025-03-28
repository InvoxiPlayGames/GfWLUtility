using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace GfWLUtility
{
    public partial class InsertKey : Form
    {
        [DllImport("LiveTokenHelper.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern uint XLiveSetSponsorToken([MarshalAs(UnmanagedType.LPWStr)] string pwszToken, uint dwTitleId);
        public InsertKey()
        {
            InitializeComponent();
        }

        public static byte[] FromHexString(string hex)
        {
            if (hex.Length % 2 != 0)
                throw new ArgumentException("Hex string must have an even length.");

            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }

        private void Save(object sender, EventArgs e)
        {
            string titleDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Microsoft\\XLive\\Titles\\" + titleIDTextbox.Text;
            if (File.Exists(titleDir + "\\config.bin\\") == true)
            {
                File.Delete(titleDir + "\\config.bin\\");
            }
            byte[] titleID = FromHexString(titleIDTextbox.Text);
            Array.Reverse(titleID);
            //If you get 0x8007000B use x86 exe since this dll is 32 bit.
            try
            {
                XLiveSetSponsorToken(keyTextbox.Text, BitConverter.ToUInt32(titleID, 0));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nIf you see error code 0x8007000B build this program in x86");
            }
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
    