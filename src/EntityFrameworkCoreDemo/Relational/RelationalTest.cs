using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace EntityFrameworkCoreDemo.Relational
{
    public class RelationalTest
    {
        public static void TestSubSearch()
        {
            using var context = new ScheduleDbContext();
            context.Database.EnsureCreated();
            context.Schedules.Add(new Schedule
            {
                Day = DateTime.Now,
                Id = Guid.NewGuid().ToString(),
                Note = "test",
                Participants = new System.Collections.Generic.List<ScheduleParticipant>
                {
                    new ScheduleParticipant
                    {
                        Id =Guid.NewGuid().ToString(),
                        ParticipantID="123",
                        ParticipantType= "Practitioner",
                    }
                }
            });

            context.SaveChanges();

            var count = context.Schedules
                .Where(s => s.Participants.Where(p => p.ParticipantID == "123").Any())
                .ToList().Count;
            Console.WriteLine(count);
            Console.WriteLine("成功");
        }

        public static void TestBothSubSearch()
        {
            using var context = new ScheduleDbContext();
            context.Database.EnsureCreated();
            context.Schedules.Add(new Schedule
            {
                Day = DateTime.Now,
                Id = Guid.NewGuid().ToString(),
                Note = "test",
                Participants = new List<ScheduleParticipant>
                {
                    new ScheduleParticipant
                    {
                        Id =Guid.NewGuid().ToString(),
                        ParticipantID="123",
                        ParticipantType= "Practitioner",
                    },
                    new ScheduleParticipant
                    {
                        Id =Guid.NewGuid().ToString(),
                        ParticipantID="456",
                        ParticipantType= "Device",
                    }
                }
            });

            context.SaveChanges();

            var count = context.Schedules
                .Where(s => 
                s.Participants.Where(p => p.ParticipantID == "123" && p.ParticipantType == "Practitioner").Any()
                &&
                s.Participants.Where(p => p.ParticipantID == "456" && p.ParticipantType == "Device").Any()
                )
                .ToList().Count;
            Console.WriteLine(count);
            Console.WriteLine("成功");
        }
    }
}
