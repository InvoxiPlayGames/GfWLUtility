using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GfWLUtility
{
    internal class DomainBlock
    {
        private static string hosts_file_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers\\etc\\hosts");
        
        public static bool IsDomainBlocked(string domain)
        {
            if (!File.Exists(hosts_file_path)) return false;

            // scan through each entry in the hosts file to see if the block exists
            string[] hosts_lines = File.ReadAllLines(hosts_file_path);
            foreach (string entry in hosts_lines)
            {
                // ignore any entry starting with a comment, or any blank lines
                if (entry.Length == 0 || entry[0] == '#') continue;
                // to check if it's blocked, we see if it's routed nowhere or locally
                // GfWL doesn't support IPv6 so we don't care for that either
                if (entry.StartsWith("0.0.0.0") || entry.StartsWith("127.0.0.1"))
                {
                    // would split but splitting is hard so we just see if the line contains the domain
                    if (entry.Contains(domain)) return true;
                }
            }

            return false;
        }

        public static void BlockDomain(string domain)
        {
            if (!Program.Elevated)
                throw new Exception("Blocking domains requires admin.");

            // scan through each entry in the hosts file to see if the block exists
            string[] hosts_lines = File.ReadAllLines(hosts_file_path);
            List<string> hosts_lines_list = hosts_lines.ToList();
            foreach (string entry in hosts_lines)
            {
                // ignore any entry starting with a comment, or any blank lines
                if (entry.Length == 0 || entry[0] == '#') continue;
                // to check if it's blocked, we see if it's routed nowhere or locally
                // GfWL doesn't support IPv6 so we don't care for that either
                if (entry.StartsWith("0.0.0.0") || entry.StartsWith("127.0.0.1"))
                {
                    // would split but splitting is hard so we just see if the line contains the domain
                    if (entry.Contains(domain)) return;
                }
            }

            // if we got here the domain isn't blocked already so add it
            hosts_lines_list.Add($"0.0.0.0 {domain}");
            File.WriteAllLines(hosts_file_path, hosts_lines_list.ToArray());
        }

        public static void UnblockDomain(string domain)
        {
            if (!Program.Elevated)
                throw new Exception("Unblocking domains requires admin.");

            // scan through each entry in the hosts file to see if the block exists
            string[] hosts_lines = File.ReadAllLines(hosts_file_path);
            List<string> hosts_lines_list = hosts_lines.ToList();
            foreach (string entry in hosts_lines)
            {
                // ignore any entry starting with a comment, or any blank lines
                if (entry.Length == 0 || entry[0] == '#') continue;
                // to check if it's blocked, we see if it's routed nowhere or locally
                // GfWL doesn't support IPv6 so we don't care for that either
                if (entry.StartsWith("0.0.0.0") || entry.StartsWith("127.0.0.1"))
                {
                    // would split but splitting is hard so we just see if the line contains the domain
                    // and then we remove the line from the hosts file
                    if (entry.Contains(domain))
                        hosts_lines_list.Remove(entry);
                }
            }
            // write the newly modified hosts file back to the hosts file 
            File.WriteAllLines(hosts_file_path, hosts_lines_list.ToArray());
        }
    }
}
