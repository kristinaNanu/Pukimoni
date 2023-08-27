using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Domain.Entities
{
    public class Pokedex : Entity
    {
        public int TrainerId { get; set; }
        public int PokemonId { get; set; }
        public int AmountCaught { get; set; }
        public int AmountCaughtShiny { get; set; }

        public User Trainer { get; set; }
        public Pokemon Pokemon { get; set; }
    }
}
