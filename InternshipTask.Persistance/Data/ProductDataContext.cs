using InternshipTask.Domain.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using System.Globalization;


namespace InternshipTask.Persistance.Data
{
    public class ProductDataContext : DbContext
    {
        public ProductDataContext()
        {
        }
        public ProductDataContext(DbContextOptions<ProductDataContext> options) : base(options)
        {

        }
        public DbSet<Product> Products => Set<Product>();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=PARSA-PC;Database=InternshipTask;Trusted_Connection=true;TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductDataContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}