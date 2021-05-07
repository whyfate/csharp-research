using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkCoreDemo.Relational
{
    public class ScheduleDbContext: DbContext
    {
        public ScheduleDbContext()
        {
        }

        public virtual DbSet<Schedule> Schedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=test.db;");
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            }));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Schedule>(s =>
            {
                s.HasKey(s => s.Id);
                s.HasMany(s => s.Participants)
                .WithOne();
            });

            modelBuilder.Entity<ScheduleParticipant>(s =>
            {
                s.HasKey(s => s.Id);
                s.HasOne(s => s.Schedule)
                .WithMany(s => s.Participants)
                .HasForeignKey(s => s.ScheduleId);
            });
        }
    }
}
