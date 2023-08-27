﻿using FluentValidation;
using Pukimoni.Application.BusinessLogic.DTO;
using Pukimoni.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Implementation.Validators
{
    public class CreateRegionValidator : AbstractValidator<LookupDto>
    {
        public CreateRegionValidator(PukimoniContext context)
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name is required")
                .Must(x => x.Length <= 15).WithMessage("Name can have 15 charachters")
                .Must(x => !context.Regions.Any(y => y.Name == x))
                .WithMessage("Name {PropertyValue} already exists.");

            RuleFor(x => x.Description)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Description is required");
        }
    }
}
