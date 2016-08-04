using AOP;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AOP.Common;

namespace AOP.CastleDynamicProxy
{
    public class LoggingAspect : IInterceptor
    {
        private readonly ILogger logger;
        private readonly IMethodLoggingDataExtractor methodLoggingDataExtractor;
        private readonly ILoggingDataExtractor argumentsLoggingDataExtractor;
        private readonly ILoggingDataExtractor resultLoggingDataExtractor;

        public LoggingAspect(
            ILogger logger,
            IMethodLoggingDataExtractor methodLoggingDataExtractor,
            ILoggingDataExtractor argumentsLoggingDataExtractor,
            ILoggingDataExtractor resultLoggingDataExtractor)
        {
            this.logger = logger;
            this.methodLoggingDataExtractor = methodLoggingDataExtractor;
            this.argumentsLoggingDataExtractor = argumentsLoggingDataExtractor;
            this.resultLoggingDataExtractor = resultLoggingDataExtractor;
        }

        public void Intercept(IInvocation invocation)
        {
            var method = invocation.MethodInvocationTarget;

            var methodLoggingData = methodLoggingDataExtractor.Extract(method);

            var preInvocationLoggingData =
                methodLoggingData
                    .Concat(invocation
                        .Arguments
                        .Zip(
                            method.GetParameters(),
                            (arg,param) =>
                                new
                                {
                                    Argument = arg,
                                    Attributes = param
                                        .GetCustomAttributes(false)
                                        .OfType<Attribute>()
                                        .ToArray(),
                                    ParameterName = param.Name
                                }).ToArray()
                        .Where(x => x.Attributes.Any())
                        .SelectMany(x =>
                            argumentsLoggingDataExtractor.Extract(x.Attributes, x.ParameterName, x.Argument)))
                    .ToArray();

            try
            {
                invocation.Proceed();
            }
            catch(Exception ex)
            {
                logger.LogError(preInvocationLoggingData, ex);
                throw;
            }

            if (method.ReturnType == typeof (void))
            {
                logger.LogSuccess(preInvocationLoggingData);
                return;
            }

            var returnValueAttributes =
                method.ReturnParameter.GetCustomAttributes(false).ToArray();

            if (!returnValueAttributes.Any())
            {
                logger.LogSuccess(preInvocationLoggingData);
                return;
            }

            var resultLoggingData =
                resultLoggingDataExtractor
                    .Extract(
                        method
                            .ReturnParameter
                            .GetCustomAttributes(false)
                            .OfType<Attribute>()
                            .ToArray(),
                        "Return Value",
                        invocation.ReturnValue);

            logger.LogSuccess(
                preInvocationLoggingData
                    .Concat(resultLoggingData)
                    .ToArray());
        }
    }
}
