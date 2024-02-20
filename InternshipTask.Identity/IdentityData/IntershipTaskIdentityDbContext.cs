using InternshipTask.Identity.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InternshipTask.Identity.IdentityData
{
    internal class IntershipTaskIdentityDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public IntershipTaskIdentityDbContext()
        {
            
        }
        public IntershipTaskIdentityDbContext(DbContextOptions<IntershipTaskIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=PARSA-PC;Database=InternshipTask;Trusted_Connection=true;TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(IntershipTaskIdentityDbContext).Assembly);
        }
    }
}
