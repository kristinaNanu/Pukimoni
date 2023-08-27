using AutoMapper;
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
    public class EfGetRegionsQuery : IGetRegionsQuery
    {
        private readonly PukimoniContext context;
        private readonly IMapper mapper;

        public int Id => 3;

        public string Name => "GetRegions";

        public string Description => "Get details of regions";

        public EfGetRegionsQuery(PukimoniContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public PaginationResult<LookupDto> Execute(PaginationSearch search)
        {
            var query = context.Regions.Where(x => x.EntityStatus == Domain.Enums.eEntityStatus.Active);


            if (!string.IsNullOrEmpty(search.Keyword))
            {
                var keyword = search.Keyword.ToUpper();
                query = query.Where(x => x.Name.ToUpper().Contains(keyword));
            }

            return query.PaginationSearch<LookupDto, Region>(search, mapper);
        }
    }
}
