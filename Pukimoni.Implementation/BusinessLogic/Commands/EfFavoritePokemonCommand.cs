using Pukimoni.Application.BusinessLogic.Commands;
using Pukimoni.Application.BusinessLogic.DTO;
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
    public class EfFavoritePokemonCommand : IFavoritePokemonCommand
    {
        private readonly PukimoniContext context;
        private readonly IApplicationUser user;

        public int Id => 15;

        public string Name => "FavoritePokemon";

        public string Description => "Favorite pokemon toggle";

        public EfFavoritePokemonCommand(PukimoniContext context, IApplicationUser user)
        {
            this.context = context;
            this.user = user;
        }
       
        public void Execute(int request)
        {
            var trainersPokemon = context.PokemonTrainers.Where(x=> x.TrainerId == this.user.Id && x.Id == request).FirstOrDefault();

            if (trainersPokemon == null || trainersPokemon.EntityStatus == Domain.Enums.eEntityStatus.Deleted)
            {
                throw new NotFoundException(typeof(PokemonTrainer), request);
            }

            //radi toggle da li je fav ili ne
            trainersPokemon.Favorite = !trainersPokemon.Favorite;

            context.SaveChanges();
        }
    }
}
