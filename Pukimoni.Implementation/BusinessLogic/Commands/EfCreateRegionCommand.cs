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
    public class EfCreateRegionCommand : ICreateRegionCommand
    {

        private readonly PukimoniContext context;
        private readonly CreateRegionValidator validator;
        public int Id => 21;

        public string Name => "CreateRegion";

        public string Description => "Create a new region";

        public EfCreateRegionCommand(PukimoniContext context, CreateRegionValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }
        public void Execute(LookupDto request)
        {

            this.validator.ValidateAndThrow(request);

            var region = new Region
            {
                Name = request.Name,
                Description = request.Description
            };

            this.context.Regions.Add(region);
            this.context.SaveChanges();
        }
    }
}
