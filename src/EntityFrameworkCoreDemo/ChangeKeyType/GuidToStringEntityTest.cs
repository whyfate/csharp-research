using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.ChangeKeyType;

internal class GuidToStringEntityTest
{
    internal static async Task TestAsync()
    {
        await SingleTestAsync();

        await RelationshipTestAsync();
    }

    static async Task SingleTestAsync()
    {
        using var context = new DemoDbContext();
        context.GuidToStringEntities.Add(new GuidToStringEntity
        {
            Id = Guid.NewGuid().ToString(),
            Index = Random.Shared.Next(1000),
            CreateTime = DateTime.Now
        });

        await context.SaveChangesAsync();
    }

    static async Task RelationshipTestAsync()
    {
        var now = DateTime.Now;
        using var context = new DemoDbContext();
        context.NumberProviders.Add(new NumberProvider
        {
            Id = Guid.NewGuid().ToString("N"),
            Name = "Name",
            Numbers = new List<Number>
            {
                new Number
                {
                    Id = Guid.NewGuid().ToString("N"),
                    Start = now,
                    End = now.AddMinutes(10),
                },
                new Number
                {
                    Id = Guid.NewGuid().ToString("N"),
                    Start = now.AddMinutes(10),
                    End = now.AddMinutes(20),
                },

            }
        });

        await context.SaveChangesAsync();
    }
}
