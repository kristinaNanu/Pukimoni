using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Application.BusinessLogic.DTO
{
    public class FavoritePokemonDto
    {
        public int PokemonTrainerId { get; set; }
        public bool Favorite { get; set; }
    }
}
