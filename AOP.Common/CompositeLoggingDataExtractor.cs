using System;
using System.Linq;

namespace AOP.Common
{
    public class CompositeLoggingDataExtractor : ILoggingDataExtractor
    {
        private readonly ILoggingDataExtractor[] extractors;

        public CompositeLoggingDataExtractor(params ILoggingDataExtractor[] extractors)
        {
            this.extractors = extractors;
        }

        public LoggingData[] Extract(Attribute[] attributes, string defaultName, object @object)
        {
            return
                extractors
                    .SelectMany(x => x.Extract(attributes, defaultName, @object))
                    .ToArray();
        }
    }
}