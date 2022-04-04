using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.Relational
{
    internal class ParentEntityTypeConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasMany(s => s.Participants)
            .WithOne();
        }
    }

    internal class ScheduleParticipantEntityTypeConfiguration : IEntityTypeConfiguration<ScheduleParticipant>
    {
        public void Configure(EntityTypeBuilder<ScheduleParticipant> builder)
        {

            builder.HasKey(s => s.Id);
            builder.HasOne(s => s.Schedule)
            .WithMany(s => s.Participants)
            .HasForeignKey(s => s.ScheduleId);
        }
    }
}
