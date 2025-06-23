using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites.Config
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            // Student - Pair (Many-to-Many)
            builder.HasMany(s => s.MyPairs)
                .WithMany(p => p.Students)
                .UsingEntity(j => j.ToTable("StudentPairs"));

            // Student - Pair (Many-to-Many)
            builder.HasMany(s => s.MyPairs)
                .WithMany(p => p.Students)
                .UsingEntity(j => j.ToTable("StudentPairs"));

            // Student - Group (One-to-Many)
            builder.HasOne(s => s.MyGroup)
                .WithMany(g => g.Students)
                .HasForeignKey(k => k.MyGroupId);

            builder.HasMany(s => s.Coins)
                .WithMany(c => c.Students)
                .UsingEntity(j => j.ToTable("StudentCoins"));

            builder.HasIndex(s => s.Id).IsUnique();
            builder.Property(s => s.Id).IsConcurrencyToken();
        }
    }
}
