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
    public class UserConfiguration : EntityConfiguration<User>
    {
        protected override void ConfigureRules(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Username).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Blacklisted).IsRequired();
            builder.Property(x => x.RoleId).IsRequired();
            builder.Property(x => x.NumberOfUsernameChanges).IsRequired(false);
            builder.Property(x => x.LastLogin).IsRequired(false);

            builder.HasIndex(x=> x.Username).IsUnique();
            builder.HasIndex(x=> x.Email).IsUnique();

            builder.HasOne(x => x.Role).WithMany(x => x.Users).HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x=> x.Pokedexs).WithOne(x => x.Trainer).HasForeignKey(x => x.TrainerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x=> x.PokemonTrainers).WithOne(x=> x.Trainer).HasForeignKey(x=> x.TrainerId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
