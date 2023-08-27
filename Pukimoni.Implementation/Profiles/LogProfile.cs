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
    public class LogProfile : Profile
    {
        public LogProfile()
        {
            CreateMap<LogDto, Log>().ReverseMap();
            CreateMap<Log, LogDto>().ForMember(x => x.ActionName, opt => opt.MapFrom(y => y.Action))
                .ForMember(x => x.ExecutedOn, opt => opt.MapFrom(y => y.ExecutedOn.ToString("dd-MM-yyyy")));
        }
    }
}
