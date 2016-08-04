using AOP.Common;
using AOP.CQS;
using CQS;

namespace Application.CQS
{
    public static class QueryHandlerExtensionMethods
    {
        public static IQueryHandler<TQuery, TResult> AsLoggable<TQuery, TResult>(
            this IQueryHandler<TQuery, TResult> queryHandler, params LoggingData[] constantLoggingData)
        {
            return
                new LoggingAwareQueryHandler<TQuery, TResult>(
                    queryHandler,
                    new ConsoleLogger(),
                    new CompositeObjectLoggingDataExtractor(
                        new QueryNameObjectLoggingDataExtractor(),
                        new ObjectMembersLoggingDataExtractor(new LogCountAttributeBasedLoggingDataExtractor()),
                        new ObjectMembersLoggingDataExtractor(new LogAttributeBasedLoggingDataExtractor()),
                        new ConstantObjectLoggingDataExtractor(constantLoggingData)),
                    new CompositeObjectLoggingDataExtractor(
                        new ObjectMembersLoggingDataExtractor(new LogCountAttributeBasedLoggingDataExtractor()),
                        new ObjectMembersLoggingDataExtractor(new LogAttributeBasedLoggingDataExtractor())));
        }
    }
}