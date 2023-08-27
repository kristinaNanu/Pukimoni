using Pukimoni.Application.BusinessLogic.Commands;
using Pukimoni.Application.Exceptions;
using Pukimoni.DataAccess;
using Pukimoni.Domain.Entities;
using Pukimoni.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Implementation.BusinessLogic.Commands
{
    public class EfBanUserCommand : IBanUserCommand
    {
        private readonly PukimoniContext context;
        private readonly IApplicationUser user;

        public int Id => 25;
        public string Name => "BanUser";

        public string Description => "Ban a user";

        public EfBanUserCommand(PukimoniContext context, IApplicationUser user)
        {
            this.context = context;
            this.user = user;
        }

        public void Execute(int request)
        {
            var userToBan = context.Users.Find(request);

            if (userToBan == null || userToBan.EntityStatus == Domain.Enums.eEntityStatus.Deleted)
            {
                throw new NotFoundException(typeof(User), request);
            }

            userToBan.Blacklisted = !userToBan.Blacklisted;

            context.SaveChanges();
        }
    }
}
