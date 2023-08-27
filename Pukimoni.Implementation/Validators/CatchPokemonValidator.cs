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
    public class CatchPokemonValidator : AbstractValidator<CatchPokemonDto>
    {

        public CatchPokemonValidator(PukimoniContext context)
        {
            /*
            RuleFor(x => x.TrainerId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Trainer is required")
                .Must(x => context.Users.Any(y => y.Id == x))
                .WithMessage("Trainer id {PropertyValue} doesn't exists.");
            //ili direktno user koji je ulogovanffsdfjsldf
            */

            RuleFor(x => x.PokemonId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Pokemon is required")
                .Must(x => context.Pokemons.Any(y => y.Id == x))
                .WithMessage("Pokemon id {PropertyValue} doesn't exists.");
        }
    }
}
