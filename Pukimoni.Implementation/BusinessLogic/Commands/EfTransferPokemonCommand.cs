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

namespace Pukimoni.Implementation.BusinessLogic.Queries
{
    public class EfTransferPokemonCommand : ITransferPokemonCommand
    {
        private readonly PukimoniContext context;
        private readonly IApplicationUser user;

        public int Id => 14;

        public string Name => "Transfer Pokemon";

        public string Description => "Transfer a Pokemon to the professor";

        public EfTransferPokemonCommand(PukimoniContext context, IApplicationUser user)
        {
            this.context = context;
            this.user = user;
        }

        public void Execute(int request)
        {
            var pokemonToTransfer = context.PokemonTrainers.Where(x=> x.TrainerId == this.user.Id && x.Id == request).FirstOrDefault();

            if (pokemonToTransfer == null)
            {
                throw new NotFoundException(typeof(PokemonTrainer), request);
            }

            //context.SoftDelete(pokemonToTransfer);
            context.Remove(pokemonToTransfer);
            //nije logicno da se cuva tolika kolicina podataka koji nisu potrebni vise
            //yall are never getting that pokemon back
            context.SaveChanges();
        }
    }
}
