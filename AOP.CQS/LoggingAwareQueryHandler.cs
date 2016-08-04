using System;
using System.Linq;
using AOP.Common;
using CQS;

namespace AOP.CQS
{
    public class LoggingAwareQueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
    {
        private readonly IQueryHandler<TQuery, TResult> decoratedHandler;
        private readonly ILogger logger;
        private readonly IObjectLoggingDataExtractor queryObjectLoggingDataExtractor;
        private readonly IObjectLoggingDataExtractor resultObjectLoggingDataExtractor;

        public LoggingAwareQueryHandler(
            IQueryHandler<TQuery, TResult> decoratedHandler,
            ILogger logger,
            IObjectLoggingDataExtractor queryObjectLoggingDataExtractor,
            IObjectLoggingDataExtractor resultObjectLoggingDataExtractor)
        {
            this.decoratedHandler = decoratedHandler;
            this.logger = logger;
            this.queryObjectLoggingDataExtractor = queryObjectLoggingDataExtractor;
            this.resultObjectLoggingDataExtractor = resultObjectLoggingDataExtractor;
        }

        public TResult Handle(TQuery query)
        {
            var queryLoggingData = queryObjectLoggingDataExtractor.Extract(query);

            TResult result;

            try
            {
                result = decoratedHandler.Handle(query);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    queryLoggingData,
                    ex);
                throw;
            }

            var resultLoggingData = resultObjectLoggingDataExtractor.Extract(result);

            logger.LogSuccess(
                    queryLoggingData
                    .Concat(resultLoggingData)
                    .ToArray());

            return result;
        }
    }
}