using System.Linq;

namespace AOP.Common
{
    public class CompositeObjectLoggingDataExtractor: IObjectLoggingDataExtractor
    {
        private readonly IObjectLoggingDataExtractor[] extractors;

        public CompositeObjectLoggingDataExtractor(params IObjectLoggingDataExtractor[] extractors)
        {
            this.extractors = extractors;
        }

        public LoggingData[] Extract(object @object)
        {
            return
                extractors
                    .SelectMany(x => x.Extract(@object))
                    .ToArray();
        }
    }
}
