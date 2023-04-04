using EntityFrameworkCoreDemo.Concurrency;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.ChangeKeyType;

internal class GuidToStringEntityTypeConfiguration : IEntityTypeConfiguration<GuidToStringEntity>
{
    public void Configure(EntityTypeBuilder<GuidToStringEntity> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(k => k.Id).HasMaxLength(50);

        // 修改主键约束
        builder.HasAlternateKey(b => b.Id)
            .HasName("NewId");
    }
}
