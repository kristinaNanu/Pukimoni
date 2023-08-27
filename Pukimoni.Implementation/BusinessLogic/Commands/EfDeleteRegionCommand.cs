using Pukimoni.Application.BusinessLogic.Commands;
using Pukimoni.Application.Exceptions;
using Pukimoni.DataAccess;
using Pukimoni.DataAccess.Extensions;
using Pukimoni.Domain.Entities;
using Pukimoni.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Implementation.BusinessLogic.Commands
{
    public class EfDeleteRegionCommand : IDeleteRegionCommand
    {
        private readonly PukimoniContext context;
        public int Id => 17;

        public string Name => "DeleteRegion";

        public string Description => "SoftDelete a region";

        public EfDeleteRegionCommand(PukimoniContext context)
        {
            this.context = context;
        }

        public void Execute(int request)
        {
            var region = context.Regions.Find(request);
            if (region == null || region.EntityStatus == Domain.Enums.eEntityStatus.Deleted)
            {
                throw new NotFoundException(typeof(Region), request);
            }

            if (region.Pokemons.Any())
            {
                throw new ConflictException(typeof(Region), request, typeof(Pokemon));
            }

            context.SoftDelete(region);
            context.SaveChanges();
        }
    }
}
