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
    public class PokedexConfiguration : EntityConfiguration<Pokedex>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Pokedex> builder)
        {
            builder.Property(x => x.TrainerId).IsRequired();
            builder.Property(x => x.PokemonId).IsRequired();
            builder.Property(x => x.AmountCaught).IsRequired();
            builder.Property(x => x.AmountCaughtShiny).IsRequired();


            builder.HasOne(x => x.Trainer).WithMany(x => x.Pokedexs).HasForeignKey(x => x.TrainerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Pokemon).WithMany(x => x.Pokedexs).HasForeignKey(x => x.PokemonId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
