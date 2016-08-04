using System.Linq;
using AOP.Common;

namespace AOP.CQS
{
    public class QueryNameObjectLoggingDataExtractor : IObjectLoggingDataExtractor
    {
        public LoggingData[] Extract(object @object)
        {
            var attribute =
                @object
                    .GetType()
                    .GetCustomAttributes(typeof(QueryNameAttribute), false)
                    .Cast<QueryNameAttribute>()
                    .SingleOrDefault();

            if(attribute == null)
                return new LoggingData[0];

            return new []
            {
                new LoggingData
                {
                    Name = "Query Name",
                    Value = attribute.Name
                }
            };
        }
    }
}
