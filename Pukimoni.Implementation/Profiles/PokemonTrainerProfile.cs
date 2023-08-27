using AutoMapper;
using Pukimoni.Application.BusinessLogic;
using Pukimoni.Application.BusinessLogic.DTO;
using Pukimoni.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Implementation.Profiles
{
    public class PokemonTrainerProfile : Profile
    {
        public PokemonTrainerProfile()
        {
            CreateMap<PokemonTrainerDto, PokemonTrainer>().ReverseMap();
            CreateMap<PokemonTrainer, PokemonTrainerDto>().ForMember(x => x.CaughtOn, opt => opt.MapFrom(y => y.CreatedAt.ToString("dd-MM-yyyy")))
                .ForMember(x => x.PokemonName, opt => opt.MapFrom(y => y.Pokemon.Name))
                .ForMember(x => x.PokemonNumber, opt => opt.MapFrom(y => y.Pokemon.Number));
        }
    }
}
