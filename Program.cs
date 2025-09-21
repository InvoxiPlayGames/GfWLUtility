using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;

namespace GfWLUtility
{
    internal static class Program
    {
        public static bool Elevated = false;

        public static string[] Arguments = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // store arguments
            Arguments = args;

            // store elevation status
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            Elevated = principal.IsInRole(WindowsBuiltInRole.Administrator);

            // start the application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }

        public static void RelaunchAsAdmin(string arguments = null)
        {
            Process p = new Process();
            p.StartInfo.FileName = Assembly.GetExecutingAssembly().Location;
            p.StartInfo.Arguments = arguments;
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.Verb = "runas";
            p.Start();
            Application.Exit();
        }
    }
}
