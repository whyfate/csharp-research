﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreDemo.Relational
{
    public class RelationalTest
    {
        /// <summary>
        /// 根据子表查询条件查询.
        /// </summary>
        public static void TestSubSearch()
        {
            using var context = new DemoDbContext();
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
                    }
                }
            });

            context.SaveChanges();

            var schedules = context.Schedules
                // 包含 Participate
                .Include(s => s.Participants)
                .Where(s => s.Participants.Where(p => p.ParticipantID == "123").Any())
                .ToList();
            Console.WriteLine(schedules.Count);
            Console.WriteLine(schedules.First().Participants.Count);
            Console.WriteLine("成功");
        }

        /// <summary>
        /// 根据子表多条件查询.
        /// </summary>
        public static void TestMultiSubSearch()
        {
            using var context = new DemoDbContext();
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

        public static void TestMultiSubSearchEqual()
        {
            using var context = new DemoDbContext();
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
                &&
                s.Participants.Count == 2
                )
                .ToList().Count;
            Console.WriteLine(count);
            Console.WriteLine("成功");
        }

        public static void TestSubSearchContains()
        {
            using var context = new DemoDbContext();
            context.Schedules.AddRange(new List<Schedule> {
                new Schedule
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
                        }
                    }
                },
                new Schedule
                {
                    Day = DateTime.Now,
                    Id = Guid.NewGuid().ToString(),
                    Note = "test",
                    Participants = new List<ScheduleParticipant>
                    {
                        new ScheduleParticipant
                        {
                            Id =Guid.NewGuid().ToString(),
                            ParticipantID="456",
                            ParticipantType= "Practitioner",
                        }
                    }
                }
            });

            context.SaveChanges();

            var participantIDs = new string[] { "123", "456" };
            var count = context.Schedules
                .Where(s =>
                s.Participants.Where(p => participantIDs.Contains(p.ParticipantID)).Any()
                )
                .ToList().Count;
            Console.WriteLine(count);
            Console.WriteLine("成功");
        }

    }
}
