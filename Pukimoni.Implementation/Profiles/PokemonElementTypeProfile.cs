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
    public class PokemonElementTypeProfile : Profile
    {
        public PokemonElementTypeProfile()
        {
            CreateMap<PokemonElementTypeDto, PokemonElementType>();
            CreateMap<PokemonElementType, PokemonElementTypeDto>().ForMember(x => x.Name, opt => opt.MapFrom(y => y.ElementType.Name));
        }
    }
}
