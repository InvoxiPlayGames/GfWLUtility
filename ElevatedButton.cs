using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace GfWLUtility
{
    /// <summary>
    /// Is a button with the UAC shield
    /// https://stackoverflow.com/a/16226657
    /// Modified to remove shield when disabled
    /// </summary>
    public class ElevatedButton : Button
    {
        /// <summary>
        /// The constructor to create the button with a UAC shield if necessary.
        /// </summary>
        public ElevatedButton()
        {
            FlatStyle = FlatStyle.System;
            EnabledChanged += ElevatedOnEnabledChanged;
            if (!Program.Elevated && Enabled) ShowShield();
        }


        [DllImport("user32.dll")]
        private static extern IntPtr
            SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        private uint BCM_SETSHIELD = 0x0000160C;

        private void ElevatedOnEnabledChanged(object sender, EventArgs e)
        {
            if (!Enabled || Program.Elevated)
                HideShield();
            else
                ShowShield();
        }

        private void ShowShield()
        {
            IntPtr wParam = new IntPtr(0);
            IntPtr lParam = new IntPtr(1);
            SendMessage(new HandleRef(this, Handle), BCM_SETSHIELD, wParam, lParam);
        }

        private void HideShield()
        {
            IntPtr wParam = new IntPtr(0);
            IntPtr lParam = new IntPtr(0);
            SendMessage(new HandleRef(this, Handle), BCM_SETSHIELD, wParam, lParam);
        }
    }
}
