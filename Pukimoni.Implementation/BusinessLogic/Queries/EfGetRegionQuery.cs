using AutoMapper;
using Pukimoni.Application.BusinessLogic.DTO;
using Pukimoni.Application.BusinessLogic.Queries;
using Pukimoni.Application.Exceptions;
using Pukimoni.DataAccess;
using Pukimoni.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Implementation.BusinessLogic.Queries
{
    public class EfGetRegionQuery : IGetRegionQuery
    {
        private readonly PukimoniContext context;
        private readonly IMapper mapper;

        public int Id => 4;

        public string Name => "GetRegion";

        public string Description => "Get details of a region";

        public EfGetRegionQuery(PukimoniContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public LookupDto Execute(int search)
        {
            var region = context.Regions.Find(search);

            if (region == null || region.EntityStatus == Domain.Enums.eEntityStatus.Deleted)
            {
                throw new NotFoundException(typeof(Region), search);
            }

            return mapper.Map<LookupDto>(region);
        }
    }
 }
