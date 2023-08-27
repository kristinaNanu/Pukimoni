using FluentValidation;
using Pukimoni.Application.BusinessLogic.Commands;
using Pukimoni.Application.BusinessLogic.DTO;
using Pukimoni.Application.Emails;
using Pukimoni.Application.Exceptions;
using Pukimoni.DataAccess;
using Pukimoni.Domain.Entities;
using Pukimoni.Domain.Interfaces;
using Pukimoni.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Implementation.BusinessLogic.Commands
{
    public class EfUpdateUserCommand : IUpdateUserCommand
    {

        private readonly PukimoniContext context;
        private readonly UpdateUserValidator validator;
        private readonly IApplicationUser user;

        public int Id => 10;

        public string Name => "UpdateUser";

        public string Description => "Update a username and/or password";

        public EfUpdateUserCommand(PukimoniContext context, UpdateUserValidator validator, IApplicationUser user)
        {
            this.context = context;
            this.validator = validator;
            this.user = user;
        }
        public void Execute(UpdateUserDto request)
        {
            var user = context.Users.Find(request.Id);

            if (user == null || user.EntityStatus == Domain.Enums.eEntityStatus.Deleted)
            {
                throw new NotFoundException(typeof(User), request.Id);
            }
            if (user.Id != this.user.Id)
            {
                throw new UnauthorizedException();
            }

            validator.ValidateAndThrow(request);
            if (request.Username != null)
            {
                user.Username = request.Username;
                user.NumberOfUsernameChanges++;
            }

            if (request.Password != null)
            {
                var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);
                user.Password = hash;
            }
            context.SaveChanges();
        }
    }
}
