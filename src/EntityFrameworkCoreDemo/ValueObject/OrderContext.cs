using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.ValueObject
{
    public class OrderContext : DbContext
    {
        public OrderContext()
        {
        }

        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=valueobject.db;");
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            }));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>(o =>
            {
                o.HasKey(k => k.Id);
                o.OwnsOne(o => o.Address, o =>
                {
                    o.Property(o => o.Province).HasMaxLength(50).IsRequired();
                });
                o.OwnsMany(o => o.Items, a =>
                {
                    a.WithOwner().HasForeignKey("orderId");
                    a.Property<int>("id");
                    a.HasKey("id");
                });
            });
        }
    }
}
