using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Application.BusinessLogic.DTO
{
    public class PokemonDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        //slika
        public string RegionName { get; set; }
        public int EvolutionId { get; set; }
        public string EvolutionName { get; set; }
        public List<PokemonElementTypeDto> PokemonElementTypes { get; set; }
    }
}
