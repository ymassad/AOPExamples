using System.Linq;
using System.Reflection;
using AOP.Common;

namespace AOP.CastleDynamicProxy
{
    public class CompositeMethodLoggingDataExtractor : IMethodLoggingDataExtractor
    {
        private readonly IMethodLoggingDataExtractor[] extractors;

        public CompositeMethodLoggingDataExtractor(params IMethodLoggingDataExtractor[] extractors)
        {
            this.extractors = extractors;
        }

        public LoggingData[] Extract(MethodInfo method)
        {
            return extractors.SelectMany(x => x.Extract(method)).ToArray();
        }
    }
}