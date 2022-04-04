using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.Basic
{
    internal class BasicSelectTest
    {
        public static async Task Test404PropertyAsync()
        {
            using (var context = new DemoDbContext())
            {
                var property = await context.Schedules.Where(s => s.Id == Guid.NewGuid().ToString())
                    .Select(s => s.Id)
                    .FirstOrDefaultAsync();
                Console.WriteLine($"string property:{property}");
            }

            using (var context = new DemoDbContext())
            {
                var property = await context.Schedules.Where(s => s.Id == Guid.NewGuid().ToString())
                    .Select(s => s.Level)
                    .FirstOrDefaultAsync();
                Console.WriteLine($"enum property:{property}");
            }

            using (var context = new DemoDbContext())
            {
                var property = await context.Schedules.Where(s => s.Id == Guid.NewGuid().ToString())
                    .Select(s => new { s.Level, s.Id })
                    .FirstOrDefaultAsync();
                Console.WriteLine($"enum property:{property}");
            }
        }
    }
}
