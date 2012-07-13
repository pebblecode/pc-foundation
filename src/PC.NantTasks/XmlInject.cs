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

namespace PebbleCode.NantTasks
{
    // GPJ... not implemented yet!


    [TaskName("xmlinject")]
    public class XmlInject : Task
    {
        /// <summary>
        /// The input filename
        /// </summary>
        [TaskAttribute("file", Required = true)]
        [StringValidator(AllowEmpty = false)]
        public string InputFilename { get; set; }

        /// <summary>
        /// A collection of key value pairs that will be used to xml poke into the file
        /// </summary>
        [BuildElementCollection("keyvaluepairs", "keyvaluepair", Required = true)]
        [StringValidator(AllowEmpty = false)]
        public KeyValuePairCollection KeyValuePairs { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public XmlInject()
        {
            KeyValuePairs = new KeyValuePairCollection();
        }

        protected override void ExecuteTask()
        {
            Project.Log(Level.Info, "Executing nant task");
            foreach (KeyValuePair pair in KeyValuePairs)
            {
                Project.Log(Level.Info, string.Format("{0}: {1}", pair.Key, pair.Value));
            }
        }
    }
}
