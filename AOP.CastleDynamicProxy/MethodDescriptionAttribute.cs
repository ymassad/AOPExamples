using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP.CastleDynamicProxy
{
    public class MethodDescriptionAttribute : Attribute
    {
        public string Description { get; private set; }

        public MethodDescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}
