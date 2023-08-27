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
    public class PokemonTrainerConfiguration : EntityConfiguration<PokemonTrainer>
    {
        protected override void ConfigureRules(EntityTypeBuilder<PokemonTrainer> builder)
        {
            builder.Property(x => x.TrainerId).IsRequired();
            builder.Property(x => x.PokemonId).IsRequired();
            builder.Property(x => x.Atk).IsRequired();
            builder.Property(x => x.Def).IsRequired();
            builder.Property(x => x.Cp).IsRequired();
            builder.Property(x => x.Shiny).IsRequired();
            builder.Property(x => x.Favorite).IsRequired();
           

            builder.HasOne(x => x.Trainer).WithMany(x => x.PokemonTrainers).HasForeignKey(x => x.TrainerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Pokemon).WithMany(x => x.PokemonTrainers).HasForeignKey(x => x.PokemonId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
