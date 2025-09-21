using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace GfWLUtility
{
    internal class UtilityFuncs
    {

        [DllImport("shell32.dll", BestFitMapping = false, CharSet = CharSet.Auto, EntryPoint = "SHDefExtractIcon")]
        public static extern int SHDefExtractIcon(string pszIconFile, int index, uint uFlags, ref IntPtr phiconLarge, ref IntPtr phiconSmall, uint nIconSize);

        public static string CensorString(string str, int start, int end, int min_length)
        {
            if (str == null || str.Length < min_length) return str;
            int x_fill = str.Length - start - end;
            return str.Substring(0, start) + new string('\u25CF', x_fill) + str.Substring(str.Length - end, end);
        }

        public static string CensorEmail(string email)
        {
            string[] emailsplit = email.Split('@');
            if (emailsplit.Length != 2) return email;
            string[] domainsplit = emailsplit[1].Split('.');
            if (domainsplit.Length < 2) return email;
            string finalemail = emailsplit[0][0] + new string('\u25CF', 5) + "@" + domainsplit[0][0] + new string('\u25CF', 5) + "." + domainsplit[1];
            if (domainsplit.Length > 2)
                finalemail += '.' + string.Join(".", domainsplit.Skip(2).ToArray());
            return finalemail;
        }

        // https://stackoverflow.com/a/58779
        public static void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
                CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));
            foreach (FileInfo file in source.GetFiles())
                file.CopyTo(Path.Combine(target.FullName, file.Name));
        }

        public static string BytesToString(double bytes, int round = 2)
        {
            if (bytes > Math.Pow(1000, 4)) return $"{Math.Round(bytes / Math.Pow(1000, 4), round)} TB";
            if (bytes > Math.Pow(1000, 3)) return $"{Math.Round(bytes / Math.Pow(1000, 3), round)} GB";
            if (bytes > Math.Pow(1000, 2)) return $"{Math.Round(bytes / Math.Pow(1000, 2), round)} MB";
            if (bytes > Math.Pow(1000, 1)) return $"{Math.Round(bytes / Math.Pow(1000, 1), round)} KB";
            return $"{bytes} B";
        }

        public static int CountTrailingNulls(byte[] buf)
        {
            int i = buf.Length - 1;
            while (buf[i] == 0 && i > 0)
                --i;
            return i;
        }

        public static Bitmap Get48x48Icon(string exe_path)
        {
            // get the icon from the shell
            IntPtr hIconLarge = default;
            IntPtr hIconSmall = default; // ignored?
            if (SHDefExtractIcon(exe_path, 0, 0, ref hIconLarge, ref hIconSmall, 48) != 0)
                return null;

            // load the icon and convert it to a bitmap
            Icon largeIcon = Icon.FromHandle(hIconLarge);
            Bitmap largeBitmap = largeIcon.ToBitmap();

            largeIcon.Dispose();
            return largeBitmap;
        }

        public static string GetFormattedTitleID(uint titleID)
        {
            ushort gameNum = (ushort)(titleID & 0xFFFF);
            char publisher1 = (char)(titleID >> 24);
            char publisher2 = (char)((titleID >> 16) & 0xFF);
            return publisher1.ToString() + publisher2.ToString() + "-" + gameNum.ToString();
        }

        public static Version GetProductVersion(string exe_path)
        {
            FileVersionInfo info = FileVersionInfo.GetVersionInfo(exe_path);
            if (info == null) return null;
            return new Version(info.ProductVersion);
        }

        public static bool IsWindowsModern()
        {
            // are we higher than Windows 8?
            return Environment.OSVersion.Version.CompareTo(new Version("6.2")) >= 0;
        }

        public static bool IsWindowsXP()
        {
            // are we lower than Windows Vista?
            return Environment.OSVersion.Version.CompareTo(new Version("6.0")) < 0;
        }

        public static bool IsWindowsLegacy()
        {
            // are we lower than Windows XP?
            return Environment.OSVersion.Version.CompareTo(new Version("5.1")) < 0;
        }

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWow64Process([In] IntPtr hProcess, [Out] out bool wow64Process);

        public static bool IsWindows64Bit()
        {
            using (Process p = Process.GetCurrentProcess())
            {
                bool retVal;
                if (!IsWow64Process(p.Handle, out retVal))
                {
                    return false;
                }
                return retVal;
            }
        }

        public static string GetLocalDirectory(string dirname)
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\GfWLUtility\\" + dirname + "\\";
        }

        // https://stackoverflow.com/a/5076491
        public static T BytesToStructure<T>(byte[] bytes)
        {
            int size = Marshal.SizeOf(typeof(T));
            if (bytes.Length != size)
                throw new Exception($"Invalid size (got {bytes.Length}, expected {size})");

            IntPtr ptr = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.Copy(bytes, 0, ptr, size);
                return (T)Marshal.PtrToStructure(ptr, typeof(T));
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }
    }
}
