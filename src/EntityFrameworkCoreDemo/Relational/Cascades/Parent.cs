using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.Relational.Cascades
{
    public class Parent
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public List<Child> Children { get; set; }


        public override string ToString()
        {
            return System.Text.Json.JsonSerializer.Serialize(this);
        }
    }
}
