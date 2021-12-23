using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.LazyLoad
{
    internal class BlogEntityTypeConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b=>b.Id).HasMaxLength(50);
            builder.Property(b => b.Name).HasMaxLength(50);
            builder.HasMany(b => b.Posts).WithOne().HasForeignKey(b => b.BlogId);
        }
    }
}
