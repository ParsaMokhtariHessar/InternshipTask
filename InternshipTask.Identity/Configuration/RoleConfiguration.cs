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
                        Id = Guid.Parse("2e7041ef-7b35-4710-b567-d5120a585627"),
                        Name = "UserRole",
                        NormalizedName = "USERROLE"
                    }
                );
        }
    }
}
