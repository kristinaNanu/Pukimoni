using Microsoft.EntityFrameworkCore;
using Pukimoni.Application.BusinessLogic.Commands;
using Pukimoni.Application.Exceptions;
using Pukimoni.DataAccess;
using Pukimoni.DataAccess.Extensions;
using Pukimoni.Domain.Entities;
using Pukimoni.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Implementation.BusinessLogic.Commands
{
    public class EfDeleteUserCommand : IDeleteUserCommand
    {
        private readonly PukimoniContext context;
        private readonly IApplicationUser user;

        public int Id => 16;

        public string Name => "DeleteTrainer";

        public string Description => "Delete a trainer";

        public EfDeleteUserCommand(PukimoniContext context, IApplicationUser user)
        {
            this.context = context;
            this.user = user;
            this.context = context;
        }
        public void Execute(int request)
        {
            var user = context.Users
                              .Include(x => x.PokemonTrainers)
                              .Where(x => x.Id == request).FirstOrDefault();

            if (user == null || user.EntityStatus == Domain.Enums.eEntityStatus.Deleted)
            {
                throw new NotFoundException(typeof(User), request);
            }

            if ( user.Id != this.user.Id)
            {
                throw new UnauthorizedException();
            }

            if (user.PokemonTrainers.Any())
            {
                var trainersPokemonIds = user.PokemonTrainers.Select(x => x.Id).ToList();
                context.SoftDelete<PokemonTrainer>(trainersPokemonIds);
            }
            
            if (user.Pokedexs.Any())
            {
                var trainersPokedexEntryIds = user.Pokedexs.Select(x => x.Id).ToList();
                context.SoftDelete<Pokedex>(trainersPokedexEntryIds);
            }

            context.SoftDelete(user);
            context.SaveChanges();

        }
    }
}
