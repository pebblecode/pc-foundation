using System;

using NAnt.Core;
using NAnt.Core.Attributes;

namespace PebbleCode.NantTasks.Elements
{
    /// <summary>
    /// Represents an keyvalue pair
    /// </summary>
    [ElementName("keyvaluepair")]
    [Serializable()]
    public class KeyValuePair : Element
    {
        public KeyValuePair()
        {
        }

        /// <summary>
        /// The key
        /// </summary>
        [TaskAttribute("key")]
        [StringValidator(AllowEmpty = false)]
        public string Key { get; set; }

        /// <summary>
        /// The value
        /// </summary>
        [TaskAttribute("value")]
        [StringValidator(AllowEmpty = false)]
        public string Value { get; set; }
    }
}
