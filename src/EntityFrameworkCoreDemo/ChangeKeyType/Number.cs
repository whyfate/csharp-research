using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.ChangeKeyType;

public class Number
{
    public string Id { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public virtual NumberProvider Provider { get; set; }
    public virtual string ProviderId { get; set; }
}
