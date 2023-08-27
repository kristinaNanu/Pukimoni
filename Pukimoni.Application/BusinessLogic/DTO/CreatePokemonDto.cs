using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Application.BusinessLogic.DTO
{
    public class CreatePokemonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public int RegionId { get; set; }
        public int? EvolutionId { get; set; }
        public List<PokemonElementTypeDto> PokemonTypes { get; set; }

       public IFormFile Image { get; set; }
    }
}
