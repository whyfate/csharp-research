using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.ValueConversions
{
    public class ValueConversionTest
    {
        public static void TestConversion()
        {
            using var context = new DemoDbContext();
            context.Peoples.AddRange(new List<People> { 
                new People
                {
                    Id = "1",
                    Age = 1,
                    Gender = Gender.Male,
                    ContactType = ContactType.Phone,
                    ContactNumber = "13888888888"
                },
                new People
                {
                    Id = "2",
                    Age = 2,
                    Gender = Gender.Male,
                    ContactType = ContactType.Email,
                    ContactNumber = "tx@qq.com"
                }
            });

            context.SaveChanges();

            Console.WriteLine(context.Peoples.Where(p => p.Gender == Gender.Female).Count());
            Console.WriteLine(context.Peoples.Where(p => new ContactType[] { ContactType.Phone,ContactType.Email }.Contains(p.ContactType)).Count());
        }
    }
}
