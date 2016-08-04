using System;

namespace AOP.Common
{
    public interface ILoggingDataExtractor
    {
        LoggingData[] Extract(Attribute[] attributes, string defaultName, object @object);
    }
}