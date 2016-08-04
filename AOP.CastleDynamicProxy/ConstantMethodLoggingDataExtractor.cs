using System.Reflection;
using AOP.Common;

namespace AOP.CastleDynamicProxy
{
    public class ConstantMethodLoggingDataExtractor : IMethodLoggingDataExtractor
    {
        private readonly LoggingData[] constantData;

        public ConstantMethodLoggingDataExtractor(LoggingData[] constantData)
        {
            this.constantData = constantData;
        }

        public LoggingData[] Extract(MethodInfo method)
        {
            return constantData;
        }
    }
}