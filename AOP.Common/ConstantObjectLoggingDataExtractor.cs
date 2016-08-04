namespace AOP.Common
{
    public class ConstantObjectLoggingDataExtractor : IObjectLoggingDataExtractor
    {
        private readonly LoggingData[] constant;

        public ConstantObjectLoggingDataExtractor(LoggingData[] constant)
        {
            this.constant = constant;
        }

        public LoggingData[] Extract(object @object)
        {
            return constant;
        }
    }
}
