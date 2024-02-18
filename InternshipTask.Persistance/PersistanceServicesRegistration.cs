using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using InternshipTask.Persistance.Data;
using InternshipTask.Persistance.Services.ProductService;
using InternshipTask.Application.Contracts;

namespace InternshipTask.Persistance;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistanceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ProductDataContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IProductService, ProductService>();


        return services;
    }
}
