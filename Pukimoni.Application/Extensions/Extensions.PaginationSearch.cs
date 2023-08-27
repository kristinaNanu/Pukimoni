using AutoMapper;
using Pukimoni.Application.BusinessLogic.DTO;
using Pukimoni.Application.BusinessLogic.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Application.Extensions
{
    public static class Extensions
    {
        public static PaginationResult<T> PaginationSearch<T, TEntity>(this IQueryable<TEntity> table, PaginationSearch search, IMapper mapper)
           where T : BaseDto
        {
            var skipCount = search.PerPage.Value * (search.Page.Value - 1);

            var skipped = table.Skip(skipCount).Take(search.PerPage.Value);

            var response = new PaginationResult<T>
            {
                Page = search.Page.Value,
                PerPage = search.PerPage.Value,
                TotalCount = table.Count(),
                Data = mapper.Map<IEnumerable<T>>(skipped)
            };

            return response;
        }
    }
}
