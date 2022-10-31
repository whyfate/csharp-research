using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.Concurrency;

public class ConcurrencyEntity
{
    public string OccurDay { get; set; }

    public int Current { get; set; } = 1;

    public void Increment()
    {
        this.Current += 1;
    }
}
