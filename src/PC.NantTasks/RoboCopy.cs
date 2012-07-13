using System;
using System.Collections.Generic;
using System.Text;
using NAnt.Core.Attributes;
using NAnt.Core;
using System.Diagnostics;

namespace PebbleCode.NantTasks
{
    [TaskName("robocopy")]
    public class Robocopy : Task
    {
        /*
        
        The return code from Robocopy is a bit map, defined as follows:

        Hex Bit Value Decimal Value Meaning If Set
        0Ã—10 16 Serious error. Robocopy did not copy any files. This is either a usage error or an error due to insufficient access privileges on the source or destination directories.
        0Ã—08 8 Some files or directories could not be copied (copy errors occurred and the retry limit was exceeded). Check these errors further.
        0Ã—04 4 Some Mismatched files or directories were detected. Examine the output log. Housekeeping is probably necessary.
        0Ã—02 2 Some Extra files or directories were detected. Examine the output log. Some housekeeping may be needed.
        0Ã—01 1 One or more files were copied successfully (that is, new files have arrived).
        0Ã—00 0 No errors occurred, and no copying was done. The source and destination directory trees are completely synchronized.
        
        You may get a number like 11. This is a combination of errors that make it up. Ie 11 = 8 + 2 + 1
        
        */

        private string _robocopyPath = @"robocopy.exe";
        private int _retries = 5;

        [TaskAttribute("robocopypath", Required = false), StringValidator(AllowEmpty = false)]
        public string RobocopyPath
        {
            set { _robocopyPath = value; }
        }

        [TaskAttribute("source", Required = true), StringValidator(AllowEmpty = false)]
        public string Source { get; set; }

        [TaskAttribute("destination", Required = true), StringValidator(AllowEmpty = false)]
        public string Destination { get; set; }

        [TaskAttribute("mirror", Required = false)]
        public bool Mirror { get; set; }

        [TaskAttribute("excludeDirs", Required = false)]
        public string ExcludeDirs { get; set; }

        [TaskAttribute("retries", Required = false)]
        public int Retries
        {
            set { _retries = value; }
        }

        [TaskAttribute("arguments", Required = false)]
        public string Arguments { get; set; }

        protected override void ExecuteTask()
        {
            Project.Log(Level.Info, string.Format("Copying files from {0} to {1}", Source, Destination));

            var arguments = Source + " " + Destination;
            arguments += string.Concat(
                (Mirror ? " /MIR" : string.Empty),
                string.IsNullOrEmpty(ExcludeDirs) ? string.Empty : " /XD " + ExcludeDirs,
                " /XF *.pdb",
                " /R:" + _retries,
                " /W:5",
                " /NP /NFL");

            Project.Log(Level.Info, string.Format("Retries: {0}, Mirror: {1}, Arguments: {2}", _retries, Mirror, arguments));

            try
            {
                var proc = new Process();
                proc.StartInfo.WorkingDirectory = @"C:\";
                proc.StartInfo.FileName = _robocopyPath;
                proc.StartInfo.Arguments = arguments;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = false;
                proc.StartInfo.RedirectStandardError = true;
                proc.Start();
                proc.WaitForExit();

                switch (proc.ExitCode)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 11:
                        break;
                    default:
                        throw new ApplicationException(string.Format("Error copying files from {0} to {1}. Return code {2}", Source, Destination, proc.ExitCode));
                }

                proc.Close();
            }
            catch (Exception e)
            {
                Project.Log(Level.Error, string.Format("Error copying files from {0} to {1} - {2}", Source, Destination, e.Message));
            }

            Project.Log(Level.Info, string.Format("Finished copying files from {0} to {1}", Source, Destination));
        }
    }
}
