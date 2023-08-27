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
    public class PokemonConfiguration : EntityConfiguration<Pokemon>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Pokemon> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(15); 
            //Crabominable je najduze pokemon ime koji ima 12
            builder.Property(x => x.Number).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.ImageId).IsRequired();
            builder.Property(x => x.EvolutionId).IsRequired(false);
            builder.Property(x => x.RegionId).IsRequired();

            builder.HasIndex(x => x.Name).IsUnique();
            builder.HasIndex(x => x.Number).IsUnique();

            builder.HasOne(x => x.Evolution).WithOne().HasForeignKey<Pokemon>(x => x.Id).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Image).WithOne(x=> x.Pokemon).HasForeignKey<Pokemon>(x => x.ImageId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Region).WithMany(x => x.Pokemons).HasForeignKey(x => x.RegionId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x=> x.PokemonElementTypes).WithOne(x=> x.Pokemon).HasForeignKey(x=> x.PokemonId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x=> x.PokemonTrainers).WithOne(x=> x.Pokemon).HasForeignKey(x=> x.PokemonId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
