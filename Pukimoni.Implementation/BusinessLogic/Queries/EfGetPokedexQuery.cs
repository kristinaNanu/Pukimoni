using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pukimoni.Application.BusinessLogic.DTO;
using Pukimoni.Application.BusinessLogic.Queries;
using Pukimoni.Application.BusinessLogic.Search;
using Pukimoni.Application.Extensions;
using Pukimoni.DataAccess;
using Pukimoni.Domain.Entities;
using Pukimoni.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Implementation.BusinessLogic.Queries
{
    public class EfGetPokedexQuery : IGetPokedexQuery
    {
        private readonly PukimoniContext context;
        private readonly IMapper mapper;
        private readonly IApplicationUser user;

        public int Id => 26;

        public string Name => "GetPokedex";

        public string Description => "Get pokedex";

        public EfGetPokedexQuery(PukimoniContext context, IMapper mapper, IApplicationUser user)
        {
            this.context = context;
            this.mapper = mapper;
            this.user = user;
        }
        public PaginationResult<PokedexDto> Execute(PaginationSearch search)
        {

            var query = context.Pokedexs
                .Include(x=> x.Pokemon)
                .Where(x => x.TrainerId == this.user.Id && x.EntityStatus == Domain.Enums.eEntityStatus.Active);


            if (!string.IsNullOrEmpty(search.Keyword))
            {
                var keyword = search.Keyword.ToUpper();
                query = query.Where(x => x.Pokemon.Name.ToUpper().Contains(keyword)
                                 || x.Pokemon.Number.Equals(keyword)
                );
            }

            return query.PaginationSearch<PokedexDto, Pokedex>(search, mapper);
        }
    }
}
