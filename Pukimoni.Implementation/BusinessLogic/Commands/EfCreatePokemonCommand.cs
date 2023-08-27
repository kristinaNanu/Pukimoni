using FluentValidation;
using Pukimoni.Application.BusinessLogic.Commands;
using Pukimoni.Application.BusinessLogic.DTO;
using Pukimoni.DataAccess;
using Pukimoni.Domain.Entities;
using Pukimoni.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Implementation.BusinessLogic.Commands
{
    public class EfCreatePokemonCommand : ICreatePokemonCommand
    {
        private readonly PukimoniContext context;
        private readonly CreatePokemonValidator validator;

        public int Id => 22;

        public string Name => "CreatePokemon";

        public string Description => "Create a pokemon";

        public EfCreatePokemonCommand(PukimoniContext context, CreatePokemonValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }
        public void Execute(CreatePokemonDto request)
        {
            validator.ValidateAndThrow(request);

            //dodavanje slikeeeeeeeaaaaa
            ///!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!SLIKAAAAAA
            var image = request.Image;
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(image.FileName);
            var newFileName = guid + "_" + Path.GetFileNameWithoutExtension(image.FileName) + extension;
            var path = Path.Combine("wwwroot", "images", newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }

            var img = new Image { Path = newFileName, Alt = Path.GetFileNameWithoutExtension(image.FileName) };

            var pokemon = new Pokemon
            {
                Name = request.Name,
                Number = request.Number,
                Description = request.Description,
                RegionId = request.RegionId,
                EvolutionId = request.EvolutionId,
                Image = img,
                PokemonElementTypes = request.PokemonTypes.Select(x => new PokemonElementType
                {
                    ElementTypeId = x.ElementTypeId
                }).ToList()
            };

            context.Pokemons.Add(pokemon);
            context.SaveChanges();
        }
    }
}
