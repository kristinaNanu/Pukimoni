using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pukimoni.Application.BusinessLogic;
using Pukimoni.Application.BusinessLogic.Queries;
using Pukimoni.Application.Exceptions;
using Pukimoni.DataAccess;
using Pukimoni.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Implementation.BusinessLogic
{
    public class EfGetUserQuery : IGetUserQuery
    {
        private readonly PukimoniContext context;
        private readonly IMapper mapper;

        public int Id => 2; //id permission za onog ko rardi ovo

        public string Name => "GetUser"; //name permission

        public string Description => "Get a user"; //permission description

        public EfGetUserQuery(PukimoniContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public UserDto Execute(int id)
        {
            var user = context.Users.Where(x => x.Id == id).FirstOrDefault();

            if (user == null || user.EntityStatus == Domain.Enums.eEntityStatus.Deleted)
            {
                throw new NotFoundException(typeof(User), id);
            }

            return mapper.Map<UserDto>(user);
        }
    }
}
