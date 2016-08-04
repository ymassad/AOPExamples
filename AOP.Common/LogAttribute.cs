using System;

namespace AOP.Common
{
    public class LogAttribute : Attribute
    {
        public string Name { get; private set; }
        
        public LogAttribute(string name)
        {
            Name = name;
        }

        public LogAttribute()
        {
        }

        public bool HasName
        {
            get { return Name != null; }
        }
    }
}
