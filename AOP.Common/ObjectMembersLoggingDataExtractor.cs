using System.Linq;
using System.Reflection;

namespace AOP.Common
{
    public class ObjectMembersLoggingDataExtractor : IObjectLoggingDataExtractor
    {
        private readonly ILoggingDataExtractor individualMemberLoggingDataExtractor;

        public ObjectMembersLoggingDataExtractor(ILoggingDataExtractor individualMemberLoggingDataExtractor)
        {
            this.individualMemberLoggingDataExtractor = individualMemberLoggingDataExtractor;
        }

        public LoggingData[] Extract(object @object)
        {
            return
                @object
                    .GetType()
                    .GetProperties()
                    .Where(prop => prop.CanRead)
                    .Select(prop => new {Property = prop, Attributes = prop.GetCustomAttributes()})
                    .Where(x => x.Attributes.Any())
                    .SelectMany(
                        x => individualMemberLoggingDataExtractor
                            .Extract(
                                x.Attributes.ToArray(),
                                x.Property.Name,
                                x.Property.GetValue(@object)))
                    .ToArray();
        }
    }
}