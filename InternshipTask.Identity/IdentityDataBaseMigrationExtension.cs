using InternshipTask.Identity.IdentityData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InternshipTask.Identity
{
    public static class IdentityDatabaseMigrationExtensions
    {
        public static IApplicationBuilder UseIdentityDatabaseMigration(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IntershipTaskIdentityDbContext>();
                dbContext.Database.Migrate();
                // You can also seed data here if needed
            }

            return app;
        }
    }

}
