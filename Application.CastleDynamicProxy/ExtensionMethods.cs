using System;
using AOP;
using AOP.CastleDynamicProxy;
using AOP.Common;
using Castle.DynamicProxy;

namespace Application.CastleDynamicProxy
{
    public static class ExtensionMethods
    {
        public static T AsLoggable<T>(
            this T instance, params LoggingData[] constantLoggingData)
        {
            if(!typeof(T).IsInterface)
                throw new Exception("T should be an interface");

            ProxyGenerator proxyGenerator = new ProxyGenerator();

            return
                (T)proxyGenerator.CreateInterfaceProxyWithTarget(
                    typeof(T),
                    instance,
                    new LoggingAspect(
                        
                        new ConsoleLogger(),
                        new CompositeMethodLoggingDataExtractor(
                            new MethodDescriptionLoggingDataExtractor(),
                            new ConstantMethodLoggingDataExtractor(constantLoggingData)), 
                        new CompositeLoggingDataExtractor(
                            new LogCountAttributeBasedLoggingDataExtractor(),
                            new LogAttributeBasedLoggingDataExtractor()),
                        new CompositeLoggingDataExtractor(
                            new LogCountAttributeBasedLoggingDataExtractor(),
                            new LogAttributeBasedLoggingDataExtractor())));
        }
    }
}