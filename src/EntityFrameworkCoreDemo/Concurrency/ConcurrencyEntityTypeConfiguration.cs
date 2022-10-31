using EntityFrameworkCoreDemo.Concurrency;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.Concurrency;

internal class ConcurrencyEntityTypeConfiguration : IEntityTypeConfiguration<ConcurrencyEntity>
{
    public void Configure(EntityTypeBuilder<ConcurrencyEntity> builder)
    {
        builder.HasKey(k => k.OccurDay);
        builder.Property(k => k.OccurDay).HasMaxLength(8);
        builder.Property(k => k.Current).IsConcurrencyToken();
    }
}
