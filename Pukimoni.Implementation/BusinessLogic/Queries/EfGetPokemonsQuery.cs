using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pukimoni.Application.BusinessLogic.DTO;
using Pukimoni.Application.BusinessLogic.Queries;
using Pukimoni.Application.BusinessLogic.Search;
using Pukimoni.Application.Extensions;
using Pukimoni.DataAccess;
using Pukimoni.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Implementation.BusinessLogic.Queries
{
    public class EfGetPokemonsQuery : IGetPokemonsQuery
    {
        private readonly PukimoniContext context;
        private readonly IMapper mapper;

        public int Id => 6;

        public string Name => "GetPokemons";

        public string Description => "Get all pokemon";

        public EfGetPokemonsQuery(PukimoniContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public PaginationResult<PokemonDto> Execute(PaginationSearch search)
        {
            var query = context.Pokemons.Include(x=> x.Region).Include(x=> x.PokemonElementTypes).ThenInclude(x=>x.ElementType).Where(x => x.EntityStatus == Domain.Enums.eEntityStatus.Active);


            if (!string.IsNullOrEmpty(search.Keyword))
            {
                var keyword = search.Keyword.ToUpper();
                query = query.Where(x => x.Name.ToUpper().Contains(keyword) 
                                 || x.Number.Equals(keyword)
                                 || x.PokemonElementTypes.Any(y=> y.ElementType.Name.ToUpper().Contains(keyword)));
            }

            var result = query.PaginationSearch<PokemonDto, Pokemon>(search, mapper);
            return result;
        }
    }
}
