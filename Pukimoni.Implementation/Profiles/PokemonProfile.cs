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
    public class PokemonProfile : Profile
    { 
        public PokemonProfile()
        {
            CreateMap<PokemonDto, Pokemon>().ReverseMap();
            CreateMap<Pokemon, PokemonDto>().ForMember(x => x.RegionName, opt => opt.MapFrom(y => y.Region.Name));
            CreateMap<Pokemon, PokemonDto>().ForMember(x => x.EvolutionName, opt => opt.MapFrom(y => y.Evolution.Name));
            CreateMap<Pokemon, PokemonDto>().ForMember(x => x.EvolutionId, opt => opt.MapFrom(y => y.Evolution.Id));
        }
    }
}
