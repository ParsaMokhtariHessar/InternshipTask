using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipTask.Identity.Configuration
{
    internal class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {
            builder.HasData(
                    new IdentityRole<Guid>
                    {
                        Id = Guid.Parse("cd1f3faf-3b03-4ced-85b8-1ad18aa1e406"),
                        Name = "UserRole",
                        NormalizedName = "USERROLE"
                    }
                );
        }
    }
}
