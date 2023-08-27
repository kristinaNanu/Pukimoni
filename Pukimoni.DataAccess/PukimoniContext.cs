using Microsoft.EntityFrameworkCore;
using Pukimoni.Domain.Entities;
using Pukimoni.Domain.Enums;
using Pukimoni.Domain.Interfaces;
using System;

namespace Pukimoni.DataAccess
{
    public class PukimoniContext : DbContext
    {

        public IApplicationUser User { get; set; }

        //// kada se radi add-migration i update-database, nema user-a, dakle ne treba
        
        public PukimoniContext(IApplicationUser user)
        {
            User = user;
        }
        
        //// kada se radi add-migration i update-database, nema user-a, dakle ne treba


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=Pukimoni;Integrated Security=True; TrustServerCertificate=True;");

            base.OnConfiguring(optionsBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.EntityStatus = eEntityStatus.Active;
                            e.CreatedAt = DateTime.UtcNow;
                            e.CreatedBy = User?.Identity;
                            e.ModifiedAt = null;
                            e.ModifiedBy = null;
                            break;
                        case EntityState.Modified:
                            e.ModifiedAt = DateTime.UtcNow;
                            e.ModifiedBy = User?.Identity;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }

        #region DbSets
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ElementType> ElementTypes { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }

        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<PokemonElementType> PokemonElementTypes { get; set; }
        public DbSet<PokemonTrainer> PokemonTrainers { get; set; }
        public DbSet<Pokedex> Pokedexs { get; set; }
        public DbSet<Log> Logs { get; set; }
        #endregion
    }
}