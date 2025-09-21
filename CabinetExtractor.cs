using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace GfWLUtility
{
    internal class CabinetExtractor
    {
        private string _initialFile;
        private string _outputFolder;
        private bool _treatContentNormally; // whether to extract the "Content" folder of an xlive cab or extract the whole cab

        // https://stackoverflow.com/a/37646895
        /// <summary>
        ///     This routine appends the given argument to a command line such that
        ///     CommandLineToArgvW will return the argument string unchanged. Arguments
        ///     in a command line should be separated by spaces; this function does
        ///     not add these spaces.
        /// </summary>
        /// <param name="argument">Supplies the argument to encode.</param>
        /// <param name="force">
        ///     Supplies an indication of whether we should quote the argument even if it 
        ///     does not contain any characters that would ordinarily require quoting.
        /// </param>
        private static string EncodeParameterArgument(string argument, bool force = false)
        {
            if (argument == null) throw new ArgumentNullException(nameof(argument));

            // Unless we're told otherwise, don't quote unless we actually
            // need to do so --- hopefully avoid problems if programs won't
            // parse quotes properly
            if (force == false
                && argument.Length > 0
                && argument.IndexOfAny(" \t\n\v\"".ToCharArray()) == -1)
            {
                return argument;
            }

            var quoted = new StringBuilder();
            quoted.Append('"');

            var numberBackslashes = 0;

            foreach (var chr in argument)
            {
                switch (chr)
                {
                    case '\\':
                        numberBackslashes++;
                        continue;
                    case '"':
                        // Escape all backslashes and the following
                        // double quotation mark.
                        quoted.Append('\\', numberBackslashes * 2 + 1);
                        quoted.Append(chr);
                        break;
                    default:
                        // Backslashes aren't special here.
                        quoted.Append('\\', numberBackslashes);
                        quoted.Append(chr);
                        break;
                }
                numberBackslashes = 0;
            }

            // Escape all backslashes, but let the terminating
            // double quotation mark we add below be interpreted
            // as a metacharacter.
            quoted.Append('\\', numberBackslashes * 2);
            quoted.Append('"');

            return quoted.ToString();
        }

        public CabinetExtractor(string initialFile, string outputFolder, bool treatContentNormally = false)
        {
            _initialFile = initialFile;
            _outputFolder = outputFolder;
            _treatContentNormally = treatContentNormally;
        }

        public bool Extract()
        {
            if (!Directory.Exists(_outputFolder))
                Directory.CreateDirectory(_outputFolder);
            // use Extrac32 to extract the cabinet file
            Process p = new Process();
            p.StartInfo.FileName = "Extrac32";
            p.StartInfo.Arguments = $"/E /Y {EncodeParameterArgument(_initialFile)}";
            p.StartInfo.WorkingDirectory = _outputFolder;
            p.Start();
            p.WaitForExit();
            // check if we're a content file and we shouldn't treat it normally
            if (!_treatContentNormally &&
                File.Exists(Path.Combine(_outputFolder, "content.xbx")) &&
                Directory.Exists(Path.Combine(_outputFolder, "Content")))
            {
                // copy all the files from within the Content folder to the correct output folder
                // TODO: copy subdirectories
                foreach (string file in Directory.GetFiles(Path.Combine(_outputFolder, "Content"), "*.*", SearchOption.TopDirectoryOnly))
                {
                    File.Copy(file, file.Replace(Path.Combine(_outputFolder, "Content"), _outputFolder), true);
                    File.Delete(file);
                }

                // delete the Content files
                Directory.Delete(Path.Combine(_outputFolder, "Content"), true);
                File.Delete(Path.Combine(_outputFolder, "content.xbx"));
            }
            // TODO: make sure it's succeeded
            return true;
        }
    }
}
