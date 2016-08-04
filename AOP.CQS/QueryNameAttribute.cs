using System;

namespace AOP.CQS
{
    public class QueryNameAttribute : Attribute
    {
        public string Name { get; private set; }

        public QueryNameAttribute(string name)
        {
            Name = name;
        }
    }
}
