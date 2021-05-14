using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo
{
    public class DemoDbContext : DbContext
    {
        public virtual DbSet<Relational.Schedule> Schedules { get; set; }

        public virtual DbSet<ValueObject.Order> Orders { get; set; }

        public virtual DbSet<ValueConversions.People> Peoples { get; set; }

        /// <summary>
        /// 配置连接字符串.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=demo.db;");
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            }));
        }

        /// <summary>
        /// 配置模型.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relational Configuration
            modelBuilder.ApplyConfiguration(new Relational.ScheduleEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new Relational.ScheduleParticipantEntityTypeConfiguration());

            // ValueObject Configuration
            modelBuilder.ApplyConfiguration(new ValueObject.OrderEntityTypeConfiguration());

            // value conversion
            modelBuilder.ApplyConfiguration(new ValueConversions.PersonEntityTypeConfiguration());
        }
    }
}
