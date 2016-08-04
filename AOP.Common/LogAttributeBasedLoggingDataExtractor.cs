using System;
using System.Linq;

namespace AOP.Common
{
    public class LogAttributeBasedLoggingDataExtractor : ILoggingDataExtractor
    {
        public LoggingData[] Extract(Attribute[] attributes, string defaultName, object @object)
        {
            return
                attributes
                    .OfType<LogAttribute>()
                    .Select(x => new LoggingData
                    {
                        Name = GetLogName(x, defaultName),
                        Value = @object.ToString()
                    })
                    .ToArray();
        }

        private string GetLogName(LogAttribute logAttribute, string defaultName)
        {
            if (logAttribute.HasName)
                return logAttribute.Name;

            return defaultName;
        }
    }
}
