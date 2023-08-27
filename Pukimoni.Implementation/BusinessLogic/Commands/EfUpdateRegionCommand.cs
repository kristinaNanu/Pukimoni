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
    public class EfUpdateRegionCommand : IUpdateRegionCommand
    {
        private readonly PukimoniContext context;
        private readonly UpdateDetailsValidator validator;

        public int Id => 11;

        public string Name => "UpdateRegion";

        public string Description => "Update a region";

        public EfUpdateRegionCommand(PukimoniContext context, UpdateDetailsValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }
        public void Execute(LookupDto request)
        {
            var region = context.Regions.Find(request.Id);
            if (region == null || region.EntityStatus == Domain.Enums.eEntityStatus.Deleted)
            {
                throw new NotFoundException(typeof(Region), request.Id);
            }

            validator.ValidateAndThrow(request);

            if (!string.IsNullOrEmpty(request.Name)) {
                region.Name = request.Name;
            }
            
            if (!string.IsNullOrEmpty(request.Description)) {
                region.Description = request.Description;
            }
            
            
            context.SaveChanges();
        }
    }
}
