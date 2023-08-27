using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pukimoni.Application.BusinessLogic.DTO;
using Pukimoni.Application.BusinessLogic.Queries;
using Pukimoni.Application.Exceptions;
using Pukimoni.DataAccess;
using Pukimoni.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Implementation.BusinessLogic.Queries
{
    public class EfGetPokemonQuery : IGetPokemonQuery
    {
        private readonly PukimoniContext context;
        private readonly IMapper mapper;

        public int Id => 7;

        public string Name => "GetPokemon";

        public string Description => "Get a pokemonr";

        public EfGetPokemonQuery(PukimoniContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public PokemonDto Execute(int id)
        {
            var pokemon = context.Pokemons
                .Include(x=> x.Region)
                .Include(x=> x.Evolution)
                                .Include(x => x.PokemonElementTypes.Where(x => x.EntityStatus == Domain.Enums.eEntityStatus.Active)).ThenInclude(x => x.ElementType)
                                .Where(x => x.Id == id).FirstOrDefault();

            if (pokemon == null || pokemon.EntityStatus == Domain.Enums.eEntityStatus.Deleted)
            {
                throw new NotFoundException(typeof(Pokemon), id);
            }


            return mapper.Map<PokemonDto>(pokemon);
        }
    }
}
