using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace EntityFrameworkCoreDemo.ValueConversions
{
    internal class PersonEntityTypeConfiguration : IEntityTypeConfiguration<People>
    {
        public void Configure(EntityTypeBuilder<People> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasMaxLength(50);
            builder.Property(p => p.Gender)
                .HasMaxLength(25)
                .HasConversion(
                    v => v.ToString(),
                    v => (Gender)Enum.Parse(typeof(Gender), v))
                .IsRequired();

            builder.Property(p => p.ContactType)
                .HasMaxLength(25)
                .HasConversion(
                    v => EnumerationUtility.Enumeration2Code(v),
                    v => EnumerationUtility.Code2Enumeration<ContactType>(v))
                .IsRequired();

            builder.Property(p => p.ContactNumber).HasMaxLength(50);
        }
    }
}
