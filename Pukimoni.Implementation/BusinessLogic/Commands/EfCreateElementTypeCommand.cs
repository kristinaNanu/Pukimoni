using FluentValidation;
using Pukimoni.Application.BusinessLogic.Commands;
using Pukimoni.Application.BusinessLogic.DTO;
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
    public class EfCreateElementTypeCommand : ICreateElementTypeCommand
    {

        private readonly PukimoniContext context;
        private readonly CreateElementTypeValidator validator;
        public int Id => 23;

        public string Name => "CreateElementType";

        public string Description => "Create a new pokemon type";

        public EfCreateElementTypeCommand(PukimoniContext context, CreateElementTypeValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }
        public void Execute(LookupDto request)
        {

            this.validator.ValidateAndThrow(request);

            var elementType = new ElementType
            {
                Name = request.Name,
                Description = request.Description
            };

            this.context.ElementTypes.Add(elementType);
            this.context.SaveChanges();
        }
    }
 }
