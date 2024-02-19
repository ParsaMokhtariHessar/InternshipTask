using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using InternshipTask.Persistance.Data;
using Microsoft.AspNetCore.Builder;

namespace InternshipTask.Persistence
{
    public static class ProductDatabaseMigrationExtensions
    {
        public static IApplicationBuilder UseProductDatabaseMigration(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ProductDataContext>();
                dbContext.Database.Migrate();
                // You can also seed data here if needed
            }

            return app;
        }
    }
}