using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Domain.Entities
{
    public class Pokemon : Entity
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public int? ImageId { get; set; }
        public int? EvolutionId { get; set; }
        public int RegionId { get; set; }

        public Region Region { get; set; }
        public Pokemon Evolution { get; set; }
        public Image Image { get; set; }

        public ICollection<Pokedex> Pokedexs { get; set; } = new List<Pokedex>();
        public ICollection<PokemonTrainer> PokemonTrainers { get; set; } = new List<PokemonTrainer>();
        public ICollection<PokemonElementType> PokemonElementTypes { get; set; } = new List<PokemonElementType>();
    }
}
