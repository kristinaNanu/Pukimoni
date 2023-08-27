using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Domain.Entities
{
    public class ElementType : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<PokemonElementType> PokemonElementTypes = new List<PokemonElementType>();
    }
}
