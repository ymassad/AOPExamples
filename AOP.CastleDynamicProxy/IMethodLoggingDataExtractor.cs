using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AOP.Common;

namespace AOP.CastleDynamicProxy
{
    public interface IMethodLoggingDataExtractor
    {
        LoggingData[] Extract(MethodInfo method);
    }
}
