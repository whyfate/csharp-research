using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class LiteralAttribute : Attribute
    {
        public string Value { get; }

        public LiteralAttribute(string value)
        {
            this.Value = value;
        }
    }
}
