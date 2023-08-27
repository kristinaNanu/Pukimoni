using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Domain.Entities
{
    public class Region : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
    }
}
