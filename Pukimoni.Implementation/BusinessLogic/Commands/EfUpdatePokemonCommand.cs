using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Pukimoni.Application.BusinessLogic.Commands;
using Pukimoni.Application.BusinessLogic.DTO;
using Pukimoni.Application.Exceptions;
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
    public class EfUpdatePokemonCommand : IUpdatePokemonCommand
    {

        private readonly PukimoniContext context;
        private readonly UpdatePokemonValidator validator;

        public int Id => 12;

        public string Name => "UpdatePokemon";

        public string Description => "Update a pokemon";

        public EfUpdatePokemonCommand(PukimoniContext context, UpdatePokemonValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }
        public void Execute(UpdatePokemonDto request)
        {
            var pokemon = context.Pokemons.Include(x=>x.Image)
                .Include(x=>x.PokemonElementTypes)
                         .FirstOrDefault(x => x.Id == request.Id);

            if (pokemon == null || pokemon.EntityStatus == Domain.Enums.eEntityStatus.Deleted)
            {
                throw new NotFoundException(typeof(Pokemon), request.Id);
            }

            validator.ValidateAndThrow(request);


            if (request.PokemonTypes.Any())
            {
                var oldPokemonTypes = pokemon.PokemonElementTypes;
                context.PokemonElementTypes.RemoveRange(oldPokemonTypes);
                context.SaveChanges();

                foreach (var pokeType in request.PokemonTypes)
                {
                    pokemon.PokemonElementTypes.Add(new PokemonElementType
                    {
                        ElementTypeId = pokeType.ElementTypeId,
                        PokemonId     = pokemon.Id
                    });
                }
            }
            
            if(!string.IsNullOrEmpty(request.Name))
            {
                pokemon.Name = request.Name;
            }
            if(!string.IsNullOrEmpty(request.Description))
            {
                pokemon.Description = request.Description;
            }
            if (request.Number.HasValue)
            {
                pokemon.Number = request.Number.Value;
            }
            if (request.RegionId.HasValue)
            {
                pokemon.RegionId = request.RegionId.Value;
            }
            if (request.EvolutionId.HasValue)
            {
                pokemon.EvolutionId = request.EvolutionId.Value;
            }
            

            if (request.Image != null)
            {
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

                pokemon.Image = img;
            }
            context.SaveChanges();
        }
    }
}
