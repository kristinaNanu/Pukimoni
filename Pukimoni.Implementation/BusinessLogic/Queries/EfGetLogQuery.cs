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
    public class EfGetLogQuery : IGetLogQuery
    {
        private readonly PukimoniContext context;
        private readonly IMapper mapper;

        public int Id => 26;

        public string Name => "GetLogs";

        public string Description => "Get all logs";

        public EfGetLogQuery(PukimoniContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public PaginationResult<LogDto> Execute(LogSearch search)
        {
            var query = context.Logs.AsQueryable();

            if (!string.IsNullOrEmpty(search.Username))
            {
                query = query.Where(y => y.Username.ToUpper().Contains(search.Username.ToUpper()));
            }

            if (!string.IsNullOrEmpty(search.ActionName))
            {
                query = query.Where(y => y.Action.ToUpper().Contains(search.ActionName.ToUpper()));
            }

            if (search.DateFrom.HasValue)
            {
                query = query.Where(y => y.ExecutedOn >= search.DateFrom.Value);
            }

            if (search.DateTo.HasValue)
            {
                query = query.Where(y => y.ExecutedOn <= search.DateTo.Value);
            }

            var result = query.PaginationSearch<LogDto, Log>(search, mapper);
            return result;
        }
    }
}
