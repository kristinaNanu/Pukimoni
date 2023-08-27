using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Application.BusinessLogic.DTO
{
    public class PokedexDto : BaseDto
    {
        public int PokemonNumber { get; set; }
        public string PokemonName { get; set; }
        public string PokemonDescription { get; set; }
        //mage
        public int AmountCaught { get; set; }
        public int AmountCaughtShiny { get; set; }

    }
}
