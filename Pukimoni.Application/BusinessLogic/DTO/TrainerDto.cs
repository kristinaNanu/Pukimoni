using Pukimoni.Application.BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Application.BusinessLogic
{
    public class TrainerDto : BaseDto
    {
       // public string Username { get; set; }
        public List<PokemonTrainerDto> Pokemons { get; set; }
        //public List<PokedexDto> Pokedex { get; set; }
        
    }
}
