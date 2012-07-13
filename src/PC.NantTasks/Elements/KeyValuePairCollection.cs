using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using NAnt.Core;
using NAnt.Core.Attributes;

namespace PebbleCode.NantTasks.Elements
{
    /// <summary>
    /// Contains a strongly typed collection of KeyValue objects.
    /// </summary>
    [Serializable()]
    public class KeyValuePairCollection : Collection<KeyValuePair>
    {
        public KeyValuePairCollection()
        {
        }

        public KeyValuePairCollection(KeyValuePairCollection seed)
        {
            AddRange(seed);
        }

        public KeyValuePairCollection(KeyValuePair[] seed)
        {
            AddRange(seed);
        }

        private void AddRange(IEnumerable<KeyValuePair> source)
        {
            foreach (KeyValuePair sourceItem in source)
                this.Add(sourceItem);
        }
    }
}
