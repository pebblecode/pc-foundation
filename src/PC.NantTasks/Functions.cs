using System;
using System.Collections.Generic;
using System.Text;
using NAnt.Core.Attributes;
using NAnt.Core;

namespace PebbleCode.NantTasks
{
    [FunctionSet("datetime", "DateTime")]
    public class DateTimeFunctions : FunctionSetBase
    {
        public DateTimeFunctions(Project project, PropertyDictionary properties)
            : base(project, properties)
        {
        }

        [Function("format")]
        public static string Format(DateTime dateTime, string format)
        {
            return dateTime.ToString(format);
        }
    }
}
