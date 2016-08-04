using System;
using System.Collections;
using System.Linq;

namespace AOP.Common
{
    public class LogCountAttributeBasedLoggingDataExtractor : ILoggingDataExtractor
    {
        public LoggingData[] Extract(Attribute[] attributes, string defaultName, object @object)
        {
            return
                attributes
                    .OfType<LogCountAttribute>()
                    .Select(x => new LoggingData
                    {
                        Name = GetLogName(x, defaultName),
                        Value = GetCountOfItems(@object).ToString()
                    })
                    .ToArray();
        }

        private string GetLogName(LogCountAttribute logAttribute, string defaultName)
        {
            if (logAttribute.HasName)
                return logAttribute.Name;

            return defaultName;
        }

        private int GetCountOfItems(object @object)
        {
            if (@object is ICollection)
            {
                ICollection collection = (ICollection)@object;

                return collection.Count;
            }

            throw new Exception("Property type does not implement ICollection");
        }
    }
}