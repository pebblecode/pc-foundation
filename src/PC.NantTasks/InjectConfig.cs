using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using NAnt.Core;
using NAnt.Core.Attributes;

namespace PebbleCode.NantTasks
{
    [TaskName("injectconfig")]
    public class InjectConfig : Task
    {
        [TaskAttribute("config-file-path", Required = true)]
        [StringValidator(AllowEmpty = false)]
        public string ConfigFilePath { get; set; }


        [TaskAttribute("ignore-list", Required = false)]
        [StringValidator(AllowEmpty = true)]
        public string IgnoreList { get; set; }

        protected override void ExecuteTask()
        {
            if (!File.Exists(ConfigFilePath))
                throw new ArgumentException("Config file path is not exists.", "config-file-path");

            List<string> ignoreList = new List<string>();
            if (!string.IsNullOrEmpty(IgnoreList))
                ignoreList.AddRange(IgnoreList.Split(';', ','));

            XmlDocument configDoc = new XmlDocument();
            configDoc.Load(ConfigFilePath);
            XmlNodeList settingsNodeList = configDoc.GetElementsByTagName("appSettings");
            if (settingsNodeList == null || settingsNodeList.Count == 0)
                throw new Exception("No appSettings defined in the config file.");

            XmlNode settingsNode = settingsNodeList[0];
            if (settingsNode != null)
            {
                foreach (XmlNode configNode in settingsNode.ChildNodes)
                {
                    if (configNode.Attributes != null &&
                        configNode.Attributes["key"] != null &&
                        configNode.Attributes["value"] != null && 
                        this.Properties.Contains(configNode.Attributes["key"].Value) &&
                        !ignoreList.Contains(configNode.Attributes["key"].Value))
                    {
                        configNode.Attributes["value"].Value = this.Properties[configNode.Attributes["key"].Value];
                    }
                }
            }

            XmlTextWriter xr = new XmlTextWriter(ConfigFilePath, Encoding.UTF8) {Formatting = Formatting.Indented};
            configDoc.WriteTo(xr);
            xr.Close();
        }
    }
}
