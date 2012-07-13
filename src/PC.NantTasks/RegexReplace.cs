using System;
using System.Collections.Generic;
using System.Text;
using NAnt.Core;
using NAnt.Core.Attributes;
using System.Text.RegularExpressions;
using System.IO;

namespace PebbleCode.NantTasks
{
    [TaskName("regexreplace")]
    public class RegexReplace : Task
    {
        [TaskAttribute("input-file", Required = true)]
        [StringValidator(AllowEmpty = false)]
        public string InputFilename { get; set; }

        [TaskAttribute("output-file", Required = true)]
        [StringValidator(AllowEmpty = false)]
        public string OutputFilename { get; set; }

        [TaskAttribute("pattern", Required = true)]
        [StringValidator(AllowEmpty = false)]
        public string Pattern { get; set; }


        [TaskAttribute("replacement", Required = true)]
        [StringValidator(AllowEmpty = true)]
        public string Replacement { get; set; }

        protected override void ExecuteTask()
        {
            string line;
            using (StreamReader reader = new StreamReader(InputFilename))
            using (StreamWriter writer = new StreamWriter(OutputFilename))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine(Regex.Replace(line, Pattern, Replacement));
                }
            }
        }
    }
}
