using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace EntityFrameworkCoreDemo.ValueConversions
{
    public enum ContactType
    {
        [Literal("phone")]
        Phone,
        [Literal("fax")]
        Fax,
        [Literal("email")]
        Email,
        [Literal("pager")]
        Pager,
        [Literal("url")]
        Url,
        [Literal("sms")]
        Sms,
        [Literal("other")]
        Other
    }
}
