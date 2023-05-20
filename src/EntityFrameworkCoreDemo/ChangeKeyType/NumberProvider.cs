using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.ChangeKeyType;

public class NumberProvider
{
    public string Id { get; set; }

    public string Name { get; set; }

    public virtual List<Number> Numbers { get; set; }
}