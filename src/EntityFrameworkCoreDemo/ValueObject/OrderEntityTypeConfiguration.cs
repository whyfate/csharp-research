using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.ValueObject
{
    internal class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).HasMaxLength(50);
            builder.OwnsOne(o => o.Address, o =>
            {
                o.Property(o => o.Province).HasMaxLength(50).IsRequired();
            });
            builder.OwnsMany(o => o.Items, a =>
            {
                a.WithOwner().HasForeignKey("orderId");
                a.Property<int>("id");
                a.HasKey("id");
                a.Property(p => p.Price).HasColumnType("decimal(18,4)");
            });
        }
    }
}
