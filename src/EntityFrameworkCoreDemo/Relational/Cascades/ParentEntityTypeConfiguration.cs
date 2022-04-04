using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.Relational.Cascades
{
    internal class ParentEntityTypeConfiguration : IEntityTypeConfiguration<Parent>
    {
        public void Configure(EntityTypeBuilder<Parent> builder)
        {
            builder.ToTable("parent");
            builder.HasKey(s => s.Id);

            builder.OwnsMany(s => s.Children, c =>
           {
               c.ToTable("children");

               c.OwnsMany(c => c.Grands, g =>
               {
                   g.ToTable("grand");
               });
           });
        }
    }
}
