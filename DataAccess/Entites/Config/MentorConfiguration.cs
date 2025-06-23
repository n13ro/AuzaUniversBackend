using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites.Config
{
    public class MentorConfiguration : IEntityTypeConfiguration<Mentor>
    {
        public void Configure(EntityTypeBuilder<Mentor> builder)
        {
            builder.HasMany(m => m.MyPairs)
                .WithMany(p => p.Mentors)
                .UsingEntity(j => j.ToTable("MentorPairs"));

            builder.HasIndex(m => m.Id).IsUnique();
            builder.Property(m => m.Id).IsConcurrencyToken();
        }
    }
}
