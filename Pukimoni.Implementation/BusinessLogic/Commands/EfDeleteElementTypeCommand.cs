using Microsoft.EntityFrameworkCore;
using Pukimoni.Application.BusinessLogic.Commands;
using Pukimoni.Application.Exceptions;
using Pukimoni.DataAccess;
using Pukimoni.DataAccess.Extensions;
using Pukimoni.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Implementation.BusinessLogic.Commands
{
    public class EfDeleteElementTypeCommand : IDeleteElementTypeCommand
    {
        private readonly PukimoniContext context;
        public int Id => 19;

        public string Name => "DeleteElementType";

        public string Description => "SoftDelete a pokemon type";

        public EfDeleteElementTypeCommand(PukimoniContext context)
        {
            this.context = context;
        }

        public void Execute(int request)
        {
            var elementType = context.ElementTypes
                              .Include(x => x.PokemonElementTypes)
                              .Where(x => x.Id == request).FirstOrDefault();

            if (elementType == null || elementType.EntityStatus == Domain.Enums.eEntityStatus.Deleted)
            {
                throw new NotFoundException(typeof(ElementType), request);
            }

            if (elementType.PokemonElementTypes.Any())
            {
                throw new ConflictException(typeof(ElementType), request, typeof(PokemonElementType));
            }

            context.SoftDelete(elementType);
            context.SaveChanges();
        }
    }
}
