using Microsoft.EntityFrameworkCore;
using Pukimoni.Application.BusinessLogic.Commands;
using Pukimoni.Application.Exceptions;
using Pukimoni.DataAccess;
using Pukimoni.DataAccess.Extensions;
using Pukimoni.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Implementation.BusinessLogic.Commands
{
    public class EfDeletePokemonCommand : IDeletePokemonCommand
    {
        private readonly PukimoniContext context;
        public int Id => 18;

        public string Name => "DeletePokemon";

        public string Description => "SoftDelete a pokemon";

        public EfDeletePokemonCommand(PukimoniContext context)
        {
            this.context = context;
        }

        public void Execute(int request)
        {
            var pokemon = context.Pokemons
                              .Include(x => x.PokemonTrainers)
                              .Include(x=>x.Pokedexs)
                              .Where(x => x.Id == request).FirstOrDefault();

            if (pokemon == null || pokemon.EntityStatus == Domain.Enums.eEntityStatus.Deleted)
            {
                throw new NotFoundException(typeof(Pokemon), request);
            }

            if (pokemon.PokemonTrainers.Any())
            {
                throw new ConflictException(typeof(Pokemon), request, typeof(PokemonTrainer));
            }

            if (pokemon.Pokedexs.Any())
            {
                throw new ConflictException(typeof(Pokemon), request, typeof(Pokedex));
            }

            context.SoftDelete(pokemon);
            context.SaveChanges();
        }
    }
}
