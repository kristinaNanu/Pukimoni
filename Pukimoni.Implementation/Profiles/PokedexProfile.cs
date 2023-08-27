using AutoMapper;
using Pukimoni.Application.BusinessLogic.DTO;
using Pukimoni.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Implementation.Profiles
{
    class PokedexProfile : Profile
    {
        public PokedexProfile()
        {
            CreateMap<PokedexDto, Pokedex>();
            CreateMap<Pokedex, PokedexDto>().ForMember(x => x.PokemonName, opt => opt.MapFrom(y => y.Pokemon.Name));
            CreateMap<Pokedex, PokedexDto>().ForMember(x => x.PokemonNumber, opt => opt.MapFrom(y => y.Pokemon.Number));
            CreateMap<Pokedex, PokedexDto>().ForMember(x => x.PokemonDescription, opt => opt.MapFrom(y => y.Pokemon.Description));
        }
    }
}
