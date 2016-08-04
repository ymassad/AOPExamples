namespace AOP.Common
{
    public interface IObjectLoggingDataExtractor
    {
        LoggingData[] Extract(object @object);
    }
}