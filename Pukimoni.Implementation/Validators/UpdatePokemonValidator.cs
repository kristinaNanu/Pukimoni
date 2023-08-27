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
    public class UpdatePokemonValidator : AbstractValidator<UpdatePokemonDto>
    {
        public UpdatePokemonValidator(PukimoniContext context)
        {
            When(x => x.Name != null, () =>
            {
                RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name is required")
                .Must(x => x.Length <= 13).WithMessage("Name can have 13 charachters")
                .Must(x => !context.Pokemons.Any(y => y.Name == x))
                .WithMessage("Name {PropertyValue} already exists");
            });

            When(x => x.Number.HasValue, () =>
            {
                RuleFor(x => x.Number)
                 .Cascade(CascadeMode.Stop)
                 .NotEmpty().WithMessage("Number is required")
                 .Must(x => !context.Pokemons.Any(y => y.Number == x))
                 .WithMessage("Number {PropertyValue} already exists");
            });
            
            When(x => x.Description != null, () =>
            {
                RuleFor(x => x.Description)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Description is required")
                .MaximumLength(200).WithMessage("Max number of characters is 200");
            });
            
            When(x => x.RegionId.HasValue, () =>
            {
                RuleFor(x => x.RegionId)
                 .Cascade(CascadeMode.Stop)
                 .NotEmpty().WithMessage("Region is required")
                 .Must(x => context.Regions.Any(y => y.Id == x)).WithMessage("Region doesnt exist in the system");
            });
            
            When(x => x.EvolutionId.HasValue, () =>
            {
                When(x => x.EvolutionId.HasValue, () =>
                {
                    RuleFor(x => new {x.EvolutionId, x.Id })
                        .Must(x => context.Pokemons.Any(y => y.Id == x.EvolutionId)).WithMessage("Evolution doesnt exist in the system")
                        .Must(x => context.Pokemons.All(y => y.EvolutionId != x.EvolutionId)).WithMessage("Two Pokemon cant have the same evolution")
                        .Must(x => x.Id != x.EvolutionId).WithMessage("A Pokemon cant evolve into itself");
                });
            });

            When(x => x.Image != null, () =>
            {
                RuleFor(x => x.Image)
                 .Cascade(CascadeMode.Stop)
                 .NotEmpty().WithMessage("Image is required")
                 .Must(x => {
                     var allowedFormat = new List<string> { "image/jpeg", "image/png", "image/jpg" };
                     return allowedFormat.Contains(x.ContentType);
                 }
                 ).WithMessage("Allowed formats are 'image/jpeg','image/jpg' and 'image/png'");
            });

            When(x => x.PokemonTypes != null, () =>
            {
                RuleFor(x => x.PokemonTypes)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Pokemon type is required!")
               .Must(x =>
               {
                   var ingridientIds = x.Select(y => y.ElementTypeId);
                   return ingridientIds.Distinct().Count() == ingridientIds.Count();
               }).WithMessage("Duplicates for types arent allowed")
               .DependentRules(() =>
               {
                   RuleForEach(x => x.PokemonTypes)
                      .Cascade(CascadeMode.Stop)
                      .Must(x => context.ElementTypes.Any(y => y.Id == x.ElementTypeId)).WithMessage("Pokemon type does not exist in the system");
               });  
            });
           
        }
    }
}
