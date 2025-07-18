﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Persistence.Configurations
{
    public class PairConfiguration : IEntityTypeConfiguration<Pair>
    {
        public void Configure(EntityTypeBuilder<Pair> builder)
        {
            builder.HasOne(p => p.Group)
                   .WithMany(g => g.Pairs)
                   .HasForeignKey(p => p.GroupId);

            builder.HasIndex(p => p.Id);
            builder.Property(p => p.Id).IsConcurrencyToken();
        }
    }
}
