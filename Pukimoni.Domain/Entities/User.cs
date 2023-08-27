using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Domain.Entities
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Blacklisted { get; set; }
        public int? NumberOfUsernameChanges { get; set; }
        public int RoleId { get; set; }
        public DateTime? LastLogin { get; set; }

        public Role Role { get; set; }
        public ICollection<PokemonTrainer> PokemonTrainers { get; set; } = new List<PokemonTrainer>();
        public ICollection<Pokedex> Pokedexs { get; set; } = new List<Pokedex>();
    }
}
