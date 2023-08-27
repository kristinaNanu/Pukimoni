using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pukimoni.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.DataAccess.Configurations
{
    public class PermissionConfiguration : EntityConfiguration<Permission>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Permission> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired();

            builder.HasIndex(x => x.Name).IsUnique();;

            builder.HasMany(x => x.RolePermissions).WithOne(x => x.Permission).HasForeignKey(x => x.PermissionId).OnDelete(DeleteBehavior.Restrict);
          
        }
    }
}
