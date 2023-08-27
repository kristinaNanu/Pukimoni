using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Domain.Entities
{
    public class Image : Entity
    {
        public string Path { get; set; }
        public string Alt { get; set; }

        public Pokemon Pokemon { get; set; }
    }
}
