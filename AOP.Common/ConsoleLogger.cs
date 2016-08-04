using System;
using System.Text;

namespace AOP.Common
{
    public class ConsoleLogger : ILogger
    {

        public void LogSuccess(LoggingData[] loggingData)
        {
            Console.WriteLine("Success" + Environment.NewLine + FormatLoggingData(loggingData));
        }

        public void LogError(LoggingData[] loggingData, Exception exception)
        {
            Console.WriteLine("Error" + Environment.NewLine + FormatLoggingData(loggingData));
            Console.WriteLine(exception.Message);
        }

        private string FormatLoggingData(LoggingData[] loggingData)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in loggingData)
            {
                sb.AppendLine(item.Name + ": " + item.Value);
            }

            return sb.ToString();
        }
    }
}
