using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.Concurrency;

internal class ConcurrencyTest
{
    internal static async Task TestAsync()
    {
        var key = DateTime.Now.ToString("yyyyMMdd");
        using (var context = new DemoDbContext())
        {
            if (context.ConcurrencyEntities.FirstOrDefault(c => c.OccurDay == key) == null)
            {
                context.ConcurrencyEntities.Add(new ConcurrencyEntity
                {
                    OccurDay = key
                });

                await context.SaveChangesAsync();
            }
        }

        var context1 = new DemoDbContext();
        var context2 = new DemoDbContext();

        try
        {
            var c1 = context1.ConcurrencyEntities.First(c => c.OccurDay == key);
            c1.Increment();

            var c2 = context2.ConcurrencyEntities.First(c => c.OccurDay == key);
            c2.Increment();

            await context1.SaveChangesAsync();
            await context2.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            Console.WriteLine("出错:"+ex.Message);

            context2.ChangeTracker.Clear();
            var c2 = context2.ConcurrencyEntities.First(c => c.OccurDay == key);
            c2.Increment();
            await context2.SaveChangesAsync();
            Console.WriteLine("----------成功----------");
        }

        using (var context = new DemoDbContext())
        {
            var c = context1.ConcurrencyEntities.First(c => c.OccurDay == key);
            Console.WriteLine(c.Current);
        }
    }
}
