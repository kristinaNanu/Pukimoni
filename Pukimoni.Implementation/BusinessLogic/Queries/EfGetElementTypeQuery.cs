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
    public class EfGetElementTypeQuery : IGetElementTypeQuery
    {
        private readonly PukimoniContext context;
        private readonly IMapper mapper;

        public int Id => 9;

        public string Name => "GetElementType";

        public string Description => "Get details of a pokemon type";

        public EfGetElementTypeQuery(PukimoniContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public LookupDto Execute(int search)
        {
            var elementType = context.ElementTypes.Find(search);

            if (elementType == null || elementType.EntityStatus == Domain.Enums.eEntityStatus.Deleted)
            {
                throw new NotFoundException(typeof(ElementType), search);
            }

            return mapper.Map<LookupDto>(elementType);
        }
    }
}
