using System;

namespace AOP.Common
{
    public interface ILogger
    {
        void LogSuccess(LoggingData[] loggingData);
        void LogError(LoggingData[] loggingData, Exception exception);
    }
}