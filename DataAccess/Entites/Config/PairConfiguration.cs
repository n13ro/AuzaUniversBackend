using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites.Config
{
    public class PairConfiguration : IEntityTypeConfiguration<Pair>
    {
        public void Configure(EntityTypeBuilder<Pair> builder)
        {
            //

            builder.HasIndex(p => p.Id);
            builder.Property(p => p.Id).IsConcurrencyToken();
        }
    }
}
