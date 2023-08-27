using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Domain.Entities
{
    public class PokemonTrainer : Entity
    {
        public int TrainerId { get; set; }
        public int PokemonId { get; set; }
        //public DateTime DateCaught { get; set; }
        //ne treba, to je isto kao i CreatedAt
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Cp { get; set; }
        public bool Shiny { get; set; }
        public bool Favorite { get; set; }
       
        public User Trainer { get; set; }
        public Pokemon Pokemon { get; set; }
    }
}
