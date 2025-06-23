using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataAccess.Entites.Config
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasMany(g => g.Students)
                   .WithOne(s => s.MyGroup)
                   .HasForeignKey(s => s.MyGroupId);

            builder.HasMany(g => g.Mentors)
                   .WithMany(m => m.Groups)
                   .UsingEntity(j => j.ToTable("MentorGroups"));

            builder.HasIndex(g => g.Id).IsUnique();
            builder.Property(c => c.Id).IsConcurrencyToken();
        }
    }
}
