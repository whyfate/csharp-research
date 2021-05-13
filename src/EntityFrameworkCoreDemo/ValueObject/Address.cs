using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.ValueObject
{
    public record Address
    {
        public string ZipCode { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Street { get; set; }
        public string Detail { get; set; }

        public override string ToString()
        {
            return $"{nameof(ZipCode)}:{ZipCode},{nameof(Province)}:{Province},{nameof(City)}:{City},{nameof(County)}:{County},{nameof(Street)}:{Street},{nameof(Detail)}:{Detail},";
        }
    }
}
