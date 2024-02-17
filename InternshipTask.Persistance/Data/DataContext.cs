using InternshipTask.Domain.ApplicationModels;
using Microsoft.EntityFrameworkCore;


namespace InternshipTask.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Product> Products => Set<Product>();       
    }
}