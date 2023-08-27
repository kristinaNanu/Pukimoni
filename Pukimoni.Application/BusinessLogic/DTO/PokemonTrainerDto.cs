using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Application.BusinessLogic.DTO
{
    public class PokemonTrainerDto : BaseDto//PokemonDto
    {
        public string PokemonName { get; set; }
        public int PokemonNumber { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Cp { get; set; }
        public bool Shiny { get; set; }
        public bool Favorite { get; set; }

        public string CaughtOn { get; set; }

    }
}
