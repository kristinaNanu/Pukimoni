using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pukimoni.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.DataAccess.Configurations
{
    public class RegionConfiguration : EntityConfiguration<Region>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Region> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x => x.Pokemons).WithOne(x => x.Region).HasForeignKey(x => x.RegionId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
