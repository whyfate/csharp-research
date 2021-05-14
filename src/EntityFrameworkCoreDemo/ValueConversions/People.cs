using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.ValueConversions
{
    public class People
    {
        public string Id { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public ContactType ContactType { get; set; }

        public string ContactNumber { get; set; }
    }
}
