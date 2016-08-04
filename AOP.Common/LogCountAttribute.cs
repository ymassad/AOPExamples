using System;

namespace AOP.Common
{
    public class LogCountAttribute : Attribute
    {
        public string Name { get; private set; }

        public LogCountAttribute(string name)
        {
            Name = name;
        }

        public LogCountAttribute()
        {
            
        }

        public bool HasName => Name != null;
    }
}