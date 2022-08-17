using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDemo.Commands;

[AttributeUsage(AttributeTargets.Method)]
public class CommandAttribute : Attribute
{
    public CommandAttribute(string key = null, string description = null)
    {
        Key = key;
        Description = description;
    }

    public string Key { get; set; }

    public string Description { get; set; }
}
