using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.ChangeKeyType
{
    public class GuidToStringEntity
    {
        public string Id { get; set; }

        public int Index { get; set; }

        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}