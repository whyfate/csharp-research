using EntityFrameworkCoreDemo.Relational;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.Basic;

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

    public static async Task TestUpdate2Async()
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
            var people = await context.Peoples
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            people.ContactNumber = "13888888888";

            // 0
            Console.WriteLine(await context.SaveChangesAsync());
        }
    }

    public static async Task TestUpdate3Async()
    {
        var id = Guid.NewGuid().ToString();
        using (var context = new DemoDbContext())
        {
            context.Schedules.Add(new Schedule
            {
                Id = id,
                Day = DateTime.Now,
                Note = "test",
                Participants = new List<ScheduleParticipant>
                {
                    new ScheduleParticipant
                    {
                        Id = Guid.NewGuid().ToString(),
                        ParticipantID="123",
                        ParticipantType= "Practitioner",
                    }
                }
            });

            Console.WriteLine(await context.SaveChangesAsync());
        }

        using (var context = new DemoDbContext())
        {
            var schedule = await context.Schedules
                        .Where(s => s.Id == id)
                        .Include(s => s.Participants)
                        .FirstOrDefaultAsync();

            schedule.Participants.First().ParticipantID = "123";

            // 0
            Console.WriteLine(await context.SaveChangesAsync());
        }
    }

    public static async Task TestUpdate4Async()
    {
        var id = Guid.NewGuid().ToString();
        using (var context = new DemoDbContext())
        {
            context.Schedules.Add(new Schedule
            {
                Id = id,
                Day = DateTime.Now,
                Note = "test",
                Participants = new List<ScheduleParticipant>
                {
                    new ScheduleParticipant
                    {
                        Id = Guid.NewGuid().ToString(),
                        ParticipantID="123",
                        ParticipantType= "Practitioner",
                    }
                }
            });

            Console.WriteLine(await context.SaveChangesAsync());
        }
        using (var context = new DemoDbContext())
        {
            var schedule = await context.Schedules.FirstAsync(s => s.Id == id);

            context.Schedules.Remove(schedule);

            context.Schedules.Add(new Schedule
            {
                Id = id,
                Day = DateTime.Now,
                Note = "test-2",
                Participants = new List<ScheduleParticipant>
                {
                    new ScheduleParticipant
                    {
                        Id = Guid.NewGuid().ToString(),
                        ParticipantID="123",
                        ParticipantType= "Practitioner",
                    }
                }
            });

            await context.SaveChangesAsync();
            Console.WriteLine("完成");
        }
    }
}
