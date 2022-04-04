using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.Relational.Cascades
{
    public class Child
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public List<Grand> Grands { get; set; }
    }
}
