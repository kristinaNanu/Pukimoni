using BCrypt.Net;
using FluentValidation;
using Pukimoni.Application.BusinessLogic.Commands;
using Pukimoni.Application.BusinessLogic.DTO;
using Pukimoni.Application.Emails;
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
    public class EfCreateUserCommand : ICreateUserCommand
    {

        public int Id => 20;

        public string Name => "CreateUser";

        public string Description => "Create a trainer";

        private readonly PukimoniContext context;
        private readonly CreateUserValidator validator;
        private readonly IApplicationUser user;
        private readonly IEmailSender emailSender;

        public EfCreateUserCommand(PukimoniContext context, CreateUserValidator validator, IEmailSender emailSender, IApplicationUser user)
        {
            this.context = context;
            this.validator = validator;
            this.emailSender = emailSender;
            this.user = user;
        }

        public void Execute(CreateUserDto request)
        {
            this.validator.ValidateAndThrow(request);

            var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                Password = hash,
                RoleId = this.user.Id == 0 ? 1 : 2
                //admin pravi admina, a ako nisu ulogovan pravis novi basic nalog
            };

            this.context.Users.Add(user);
            this.context.SaveChanges();

            this.emailSender.Send(new MailDto
            {
               To = request.Email,
                Title = "Gotta catch them all!",
                Body = $"Oi welcome {request.Username}! \n Go on my dude. Catch them all! \n Love Mr. Nintendo <3"
            });
        }
    }
}
