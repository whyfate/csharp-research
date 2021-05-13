using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.ValueObject
{
    public class Order
    {
        public string Id { get; set; }

        public string OrderNo { get; set; }

        public DateTime OrderDate { get; set; }

        public Address Address { get; set; }

        public IEnumerable<OrderItem> Items { get; set; }
    }
}
