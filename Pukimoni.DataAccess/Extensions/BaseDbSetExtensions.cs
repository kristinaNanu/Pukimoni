using Pukimoni.DataAccess.Exceptions;
using Microsoft.EntityFrameworkCore;
using Pukimoni.Domain.Entities;
using Pukimoni.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pukimoni.DataAccess.Extensions
{
    public static class BaseDbSetExtensions
    {
        public static void SoftDelete(this DbContext context, Entity entity)
        {
            entity.EntityStatus = eEntityStatus.Deleted;
            context.Entry(entity).State = EntityState.Modified;
        }

        public static void SoftDelete<T>(this DbContext context, int id)
            where T : Entity
        {
            var itemToDeactivate = context.Set<T>().Find(id);

            if (itemToDeactivate == null)
            {
                throw new NotFoundException();
            }

            itemToDeactivate.EntityStatus = eEntityStatus.Deleted;
        }

        public static void SoftDelete<T>(this DbContext context, IEnumerable<int> ids)
            where T : Entity
        {
            var toDeactivate = context.Set<T>().Where(x => ids.Contains(x.Id));

            foreach (var d in toDeactivate)
            {
                d.EntityStatus = eEntityStatus.Deleted;
            }
        }
    }
}
