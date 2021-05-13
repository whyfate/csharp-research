using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.ValueObject
{
    public class OrderItem
    {
        public string ProduceId { get; set; }

        public string ProduceName { get; set; }

        public decimal Price { get; set; }
    }
}
