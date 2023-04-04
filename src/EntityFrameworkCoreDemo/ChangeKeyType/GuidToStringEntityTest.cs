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
        using var context = new DemoDbContext();
        context.GuidToStringEntities.Add(new GuidToStringEntity
        {
            Id = Guid.NewGuid().ToString(),
            Index = Random.Shared.Next(1000),
            CreateTime = DateTime.Now
        });

        await context.SaveChangesAsync();
    }
}
