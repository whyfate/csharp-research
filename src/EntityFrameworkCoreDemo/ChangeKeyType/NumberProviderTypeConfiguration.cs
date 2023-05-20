using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.ChangeKeyType
{
    internal class NumberProviderTypeConfiguration : IEntityTypeConfiguration<NumberProvider>
    {
        public void Configure(EntityTypeBuilder<NumberProvider> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasMaxLength(100);
            builder.Property(p => p.Name).HasMaxLength(50);

            // 修改主键约束
            builder.HasAlternateKey(b => b.Id).HasName($"PK_{nameof(NumberProvider)}_To_String");
        }
    }
}
