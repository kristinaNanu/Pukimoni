using FluentValidation;
using Pukimoni.Application.BusinessLogic.DTO;
using Pukimoni.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Implementation.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserValidator(PukimoniContext context)
        {

            RuleFor(x => x.Username).NotEmpty().MaximumLength(50).When(x => x.Username != null);
            RuleFor(x => x.Password)
                .NotEmpty()
                .Matches("^(?:(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8,15})$").WithMessage("Password must contain at least one uppercased letter, one lowercased letter and one number and must be 8-15 characters long.")
                .When(x => x.Password != null);
        }
    }
}