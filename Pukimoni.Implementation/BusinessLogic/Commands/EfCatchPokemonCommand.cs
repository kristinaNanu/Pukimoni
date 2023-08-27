using FluentValidation;
using Pukimoni.Application.BusinessLogic.Commands;
using Pukimoni.Application.BusinessLogic.DTO;
using Pukimoni.DataAccess;
using Pukimoni.Domain.Entities;
using Pukimoni.Domain.Interfaces;
using Pukimoni.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Implementation.BusinessLogic.Commands
{
    public class EfCatchPokemonCommand : ICatchPokemonCommand
    {
        private readonly PukimoniContext context;
        private readonly CatchPokemonValidator validator;
        private readonly IApplicationUser user;
        public int Id => 24;

        public string Name => "CatchPokemon";

        public string Description => "Catch a pokemon";

        public EfCatchPokemonCommand(PukimoniContext context, CatchPokemonValidator validator, IApplicationUser user)
        {
            this.context = context;
            this.validator = validator;
            this.user = user;
        }
        public void Execute(CatchPokemonDto request)
        {

            this.validator.ValidateAndThrow(request);

            var random = new Random();
            var shinyProbability = random.Next(101)<=2;
            var randomCp = random.Next(10, 101);
            var randomAtk = random.Next(10, 191);
            var randomDef = random.Next(5, 250);
            //Chansey i Happiny imaju base 5 def :(
            //sta god niantic da kaze za stats u PokemonGo totalno su random - source: ja, igram od 2016
             

            var caughtPokemon = new PokemonTrainer
            {
                TrainerId = this.user.Id,
                PokemonId = request.PokemonId,
                Cp = randomCp,
                Atk = randomAtk,
                Def = randomDef,
                Shiny = shinyProbability
            };

            this.context.PokemonTrainers.Add(caughtPokemon);

            var pokedexEntry = context.Pokedexs.Where(x => x.TrainerId == this.user.Id && x.PokemonId == request.PokemonId).FirstOrDefault();

            if (pokedexEntry == null) //ili da je == null?
            {
                //ako ga nema u pokedexu dodaj
                var newPokemon = new Pokedex
                {
                    TrainerId = this.user.Id,
                    PokemonId = request.PokemonId,
                    AmountCaught = 1,
                    AmountCaughtShiny = shinyProbability ? 1 : 0
                };

                this.context.Pokedexs.Add(newPokemon);
            }
            else
            {
                pokedexEntry.AmountCaught++;
                if (shinyProbability)
                {
                    pokedexEntry.AmountCaughtShiny++;
                }
            }
            this.context.SaveChanges();
        
        }
    }
}
