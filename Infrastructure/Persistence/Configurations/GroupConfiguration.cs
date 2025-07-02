using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Persistence.Configurations
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

            builder.HasMany(g => g.Pairs)
                   .WithOne(p => p.Group)
                   .HasForeignKey(p => p.GroupId);

            builder.HasIndex(g => g.Id).IsUnique();
            builder.Property(c => c.Id).IsConcurrencyToken();
        }
    }
}
