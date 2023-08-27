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
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator(PukimoniContext context)
        {

            RuleFor(x => x.Username)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Userame is required.")
                .MaximumLength(15).WithMessage("Lenght can not exceed 15 characters.");

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format.")
                .Must(x => !context.Users.Any(y => y.Email == x)).WithMessage("Email already exists.");

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Password is required.")
                .Matches("^(?:(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8,15})$").WithMessage("Password must contain at least one uppercased letter, one lowercased letter and one number and must be 8-15 characters long.");

        }
    }
}
