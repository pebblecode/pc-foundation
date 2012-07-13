using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections;

using NAnt.Core;
using NAnt.Core.Attributes;
using System.Collections.ObjectModel;
using PebbleCode.NantTasks.Elements;
using System.Diagnostics;

namespace PebbleCode.NantTasks
{
    [TaskName("isrunning")]
    public class IsRunning : Task
    {
        /// <summary>
        /// The process name
        /// </summary>
        [TaskAttribute("processname", Required = true)]
        [StringValidator(AllowEmpty = false)]
        public string ProcessName { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public IsRunning()
        {
        }

        /// <summary>
        /// Check for the process
        /// </summary>
        protected override void ExecuteTask()
        {
            Process[] processes = Process.GetProcessesByName(ProcessName);
            Project.Properties["pc.isrunning.result"] = (processes.Length > 0).ToString().ToLower();
        }
    }
}
