using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.Tracking
{
    public static class TrackingTest
    {
        public static async Task Test()
        {
            using var context = new DemoDbContext();
            var order = await context.Orders.AsNoTracking().FirstOrDefaultAsync();
            context.Orders.Attach(order);
            order.OrderDate = DateTime.Now;
            Console.WriteLine(await context.SaveChangesAsync() == 1 ? "成功" : "失败");
            Console.WriteLine((await context.Orders.AsNoTracking().FirstOrDefaultAsync(o=>o.Id == order.Id)).OrderDate);
        }

        public static async Task Performance()
        {
            using (var context = new DemoDbContext())
            {
                await context.Orders.Where(o => o.Id == Guid.NewGuid().ToString()).FirstOrDefaultAsync();
            }

            using (var context = new DemoDbContext())
            {
                var sw = Stopwatch.StartNew();
                await context.Orders.AsNoTracking().Where(o => o.Id == Guid.NewGuid().ToString()).FirstOrDefaultAsync();
                sw.Stop();
                Console.WriteLine($"NoTracking:{sw.ElapsedMilliseconds}");
            }

            using (var context = new DemoDbContext())
            {
                var sw = Stopwatch.StartNew();
                await context.Orders.Where(o => o.Id == Guid.NewGuid().ToString()).FirstOrDefaultAsync();
                sw.Stop();
                Console.WriteLine($"Tracking:{sw.ElapsedMilliseconds}");
            }
        }
    }
}
