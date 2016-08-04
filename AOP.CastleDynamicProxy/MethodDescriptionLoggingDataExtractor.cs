using System.Linq;
using System.Reflection;
using AOP.Common;

namespace AOP.CastleDynamicProxy
{
    public class MethodDescriptionLoggingDataExtractor : IMethodLoggingDataExtractor
    {
        public LoggingData[] Extract(MethodInfo method)
        {

            var methodDescriptionAttribute =
                method
                    .GetCustomAttributes(false)
                    .OfType<MethodDescriptionAttribute>()
                    .Single();

            return new[]
            {
                new LoggingData {Name = "Method", Value = methodDescriptionAttribute.Description}
            };
        }
    }
}