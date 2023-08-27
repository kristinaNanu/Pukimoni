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
    public class ElementTypeProfile : Profile
    {
        public ElementTypeProfile()
        {
            CreateMap<LookupDto, ElementType>().ReverseMap();
        }
    }
}
