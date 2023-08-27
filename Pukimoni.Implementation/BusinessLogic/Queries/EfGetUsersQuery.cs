using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pukimoni.Application.BusinessLogic;
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
    
    public class EfGetUsersQuery : IGetUsersQuery
    {
        private readonly PukimoniContext context;
        private readonly IMapper mapper;

        public int Id => 1; //id permission za onog ko rardi ovo

        public string Name => "GetUsers"; //name permission

        public string Description => "Get all users"; //permission description

        public EfGetUsersQuery(PukimoniContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public PaginationResult<UserDto> Execute(PaginationSearch search)
        {
            var query = context.Users
                               .Where(x => x.EntityStatus == Domain.Enums.eEntityStatus.Active);

            //broj pokemona koje ima ????
            //pretraga njegovih pokemona ???? po nazivu, stats

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                var keyword = search.Keyword.ToUpper();
                query = query.Where(x => x.Username.ToUpper().Contains(keyword)
                                      || x.Email.ToUpper().Contains(keyword));
            }

            var result = query.PaginationSearch<UserDto, User>(search, mapper);
            return result;
        }
    }
}
