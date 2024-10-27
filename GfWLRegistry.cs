using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace GfWLUtility
{
    internal class GfWLRegistry
    {
        private static string xlive_registry_key = "software\\classes\\software\\microsoft\\xlive";

        // Returns the current PCID in hex string format, or N/A if not found.
        public static string GetPCID()
        {
            RegistryKey gfwlKey = Registry.CurrentUser.OpenSubKey(xlive_registry_key);
            if (gfwlKey == null) return "N/A";
            object pcidValue = gfwlKey.GetValue("PCID");
            if (pcidValue != null && gfwlKey.GetValueKind("PCID") == RegistryValueKind.QWord)
            {
                byte[] pcidBytes = BitConverter.GetBytes((long)pcidValue);
                return BitConverter.ToString(pcidBytes).Replace("-", "");
            } else return "N/A";
        }

        // Returns the last used GfWL version from the registry, or N/A if not found.
        public static string GetVersion()
        {

            RegistryKey gfwlKey = Registry.CurrentUser.OpenSubKey(xlive_registry_key);
            if (gfwlKey == null) return "N/A";
            object verValue = gfwlKey.GetValue("Version");
            if (verValue != null && gfwlKey.GetValueKind("Version") == RegistryValueKind.DWord)
            {
                int verInt = (int)verValue;
                int major = (int)(verInt >> 28 & 0xF);
                int minor = (int)(verInt >> 24 & 0xF);
                int build = (int)(verInt >> 8 & 0xFFFF);
                int qfe = (int)(verInt & 0xFF);
                return $"{major}.{minor}.{build:D4}.{qfe}";
            }
            else return "N/A";
        }

        // Returns the path that the GfWL "dash"/marketplace client is installed to.
        public static string GetDashPath()
        {
            RegistryKey gfwlKey = Registry.LocalMachine.OpenSubKey(xlive_registry_key);
            if (gfwlKey == null) return null;
            object dashDirValue = gfwlKey.GetValue("DashDir");
            if (dashDirValue != null && gfwlKey.GetValueKind("DashDir") == RegistryValueKind.String)
                return (string)dashDirValue;
            else
                return null;
        }
    }
}
