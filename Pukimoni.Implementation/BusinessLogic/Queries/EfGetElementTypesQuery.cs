using AutoMapper;
using Pukimoni.Application.BusinessLogic.DTO;
using Pukimoni.Application.BusinessLogic.Search;
using Pukimoni.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pukimoni.Domain.Entities;
using Pukimoni.Application.BusinessLogic.Queries;
using Pukimoni.Application.Extensions;

namespace Pukimoni.Implementation.BusinessLogic.Queries
{
    public class EfGetElementTypesQuery : IGetElementTypesQuery
    {
        private readonly PukimoniContext context;
        private readonly IMapper mapper;

        public int Id => 8;

        public string Name => "GetElementTypes";

        public string Description => "Get details of a pokemon types";

        public EfGetElementTypesQuery(PukimoniContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public PaginationResult<LookupDto> Execute(PaginationSearch search)
        {
            var query = context.ElementTypes.Where(x => x.EntityStatus == Domain.Enums.eEntityStatus.Active);


            if (!string.IsNullOrEmpty(search.Keyword))
            {
                var keyword = search.Keyword.ToUpper();
                query = query.Where(x => x.Name.ToUpper().Contains(keyword));
            }

            return query.PaginationSearch<LookupDto, ElementType>(search, mapper);
        }
    }
}
