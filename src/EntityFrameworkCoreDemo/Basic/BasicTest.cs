using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.Basic
{
    internal class BasicTest
    {
        public static async Task TestUpdateAsync()
        {
            var id = Guid.NewGuid().ToString();
            using (var context = new DemoDbContext())
            {
                context.Peoples.Add(new ValueConversions.People
                {
                    Id = id,
                    Age = 20,
                    Gender = ValueConversions.Gender.Female,
                    ContactType = ValueConversions.ContactType.Phone,
                    ContactNumber = "13888888888"
                });

                await context.SaveChangesAsync();
            }

            using (var context = new DemoDbContext())
            {
                var peoples = await context.Peoples
                    .AsNoTracking()
                    .ToListAsync();

                var people = new ValueConversions.People
                {
                    Id = id,
                    Age = 22
                };

                context.Peoples.Attach(people);
                context.Entry(people).Property(p => p.Age).IsModified = true;

                await context.SaveChangesAsync();
            }

            using (var context = new DemoDbContext())
            {
                var people = await context.Peoples.FirstAsync(p => p.Id == id);
                Console.WriteLine(people.ContactNumber == "13888888888" ? "修改成功" : "修改失败：" + people.ContactNumber);
            }
        }
    }
}
