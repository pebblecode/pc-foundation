using System;
using System.Collections.Generic;
using System.Text;

using NAnt.Core;
using NAnt.Core.Attributes;
using System.Runtime.InteropServices;
using System.IO;

namespace PebbleCode.NantTasks
{
    /// <summary>
    /// A custom nant task to expand a path to be the full absolute path of the input.  Expands subst/mapped drives to ultimate locations
    /// </summary>
    [TaskName("pathexpander")]
    public class PathExpander : Task
    {
        [TaskAttribute("path", Required=true)]
        [StringValidator(AllowEmpty=false)]
        public string Path { get; set; }

        protected override void ExecuteTask()
        {
            string expandedPath = GetRealPath(this.Path);
            Project.Log(Level.Debug, string.Format("Expanded {0} to {1}.  Access via project property expandedpath", this.Path, expandedPath));
            Project.Properties["expandedpath"] = expandedPath;
        }

        [DllImport("kernel32.dll")]
        private static extern uint QueryDosDevice(string lpDeviceName, StringBuilder lpTargetPath, int ucchMax);

        /// <summary>
        /// Useful for turning a SUBST drive path into a physical path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetRealPath(string path)
        {
            const string MSG_PATH_INVALID = "The path/file specified does not exist.";
            const int BUFFER_LENGTH = 1024;

            if (path == null) throw new ArgumentNullException("path");
            if (Directory.Exists(path))
            {
                path = new DirectoryInfo(path).FullName;
            }
            else if (File.Exists(path))
            {
                path = new FileInfo(path).FullName;
            }
            else
            {
                throw new ArgumentException(MSG_PATH_INVALID, "path");
            }

            string realPath = path;
            StringBuilder pathInformation = new StringBuilder(BUFFER_LENGTH);
            string driveLetter = System.IO.Path.GetPathRoot(realPath).Replace(@"\", string.Empty);
            QueryDosDevice(driveLetter, pathInformation, BUFFER_LENGTH);

            // If drive is substed, the result will be in the format of "\??\C:\RealPath\".
            // after that strip the \??\ prefix and combine the paths.
            if (pathInformation.ToString().Contains(@"\??\"))
            {
                string realRoot = pathInformation.ToString(4, pathInformation.Length - 4);
                realPath = realRoot + realPath.Substring(2); // Remove the drive letter
            }

            return realPath;
        }
    }
}
