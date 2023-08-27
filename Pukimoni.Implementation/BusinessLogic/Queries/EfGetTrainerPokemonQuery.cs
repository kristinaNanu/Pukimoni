

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pukimoni.Application.BusinessLogic;
using Pukimoni.Application.BusinessLogic.DTO;
using Pukimoni.Application.BusinessLogic.Queries;
using Pukimoni.Application.BusinessLogic.Search;
using Pukimoni.Application.Exceptions;
using Pukimoni.Application.Extensions;
using Pukimoni.DataAccess;
using Pukimoni.Domain.Entities;
using Pukimoni.Domain.Interfaces;
using System.Linq;

namespace Pukimoni.Implementation.BusinessLogic.Queries
{
    public class EfGetTrainerPokemonQuery : IGetTrainerPokemonQuery
    {
        private readonly PukimoniContext context;
        private readonly IMapper mapper;
        private readonly IApplicationUser user;

        public int Id => 5;

        public string Name => "GetPokemonsTrainers";

        public string Description => "Get list of pokemon that a trainer has";

        public EfGetTrainerPokemonQuery(PukimoniContext context, IMapper mapper, IApplicationUser user)
        {
            this.context = context;
            this.mapper = mapper;
            this.user = user;
        }

        public PaginationResult<PokemonTrainerDto> Execute(PaginationSearch search)
        {
            //var query = context.Users
            var query = context.PokemonTrainers
                .Include(x => x.Pokemon)
                .ThenInclude(x => x.PokemonElementTypes)
                .ThenInclude(x => x.ElementType)
                .Where(x => x.TrainerId == this.user.Id && x.EntityStatus == Domain.Enums.eEntityStatus.Active);

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                var keyword = search.Keyword.ToUpper();
                query = query.Where(y => y.Pokemon.Name.ToUpper().Contains(keyword)
                                         || y.Pokemon.PokemonElementTypes.Any(y => y.ElementType.Name.Contains(keyword))
                                         || y.Pokemon.Number.ToString().Contains(keyword)
                                     );
            }

            //moze genericki al nah
            if (!string.IsNullOrEmpty(search.SortBy))
            {
                switch (search.SortBy)
                {
                    case "Number":
                        query = query
                            .OrderBy(x => x.Pokemon.Number);
                        break;
                    case "NumberDESC":
                       query = query
                            .OrderByDescending(y => y.Pokemon.Number);
                        break;
                    case "CP":
                       query = query
                            .OrderBy(y=> y.Cp);
                        break;
                    case "CPDESC":
                        query = query
                            .OrderByDescending(y => y.Cp);
                        break;
                    default:
                        break;
                }
            }

           var result = query.PaginationSearch<PokemonTrainerDto, PokemonTrainer>(search, mapper);
            return result;
        }
    }
}
