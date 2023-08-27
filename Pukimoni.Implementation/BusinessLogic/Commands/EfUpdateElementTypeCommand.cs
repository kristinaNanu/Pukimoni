using FluentValidation;
using Pukimoni.Application.BusinessLogic.Commands;
using Pukimoni.Application.BusinessLogic.DTO;
using Pukimoni.Application.Exceptions;
using Pukimoni.DataAccess;
using Pukimoni.Domain.Entities;
using Pukimoni.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Implementation.BusinessLogic.Commands
{
    public class EfUpdateElementTypeCommand : IUpdateElementTypeCommand
    {
        private readonly PukimoniContext context;
        private readonly UpdateDetailsValidator validator;

        public int Id => 13;

        public string Name => "UpdateElementType";

        public string Description => "Update a pokemon type";

        public EfUpdateElementTypeCommand(PukimoniContext context, UpdateDetailsValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }
        public void Execute(LookupDto request)
        {
            var elementType = context.ElementTypes.Find(request.Id);
            if (elementType == null || elementType.EntityStatus == Domain.Enums.eEntityStatus.Deleted)
            {
                throw new NotFoundException(typeof(ElementType), request.Id);
            }

            validator.ValidateAndThrow(request);

            if (!string.IsNullOrEmpty(request.Name))
            {
                elementType.Name = request.Name;
            }

            if (!string.IsNullOrEmpty(request.Description))
            {
                elementType.Description = request.Description;
            }
            
            context.SaveChanges();
        }
    }
}
