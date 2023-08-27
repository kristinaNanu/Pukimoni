using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Domain.Entities
{
    public class PokemonElementType : Entity
    {
        public int PokemonId { get; set; }
        public int ElementTypeId { get; set; }

        public Pokemon Pokemon { get; set; }
        public ElementType ElementType { get; set; }

    }
}
