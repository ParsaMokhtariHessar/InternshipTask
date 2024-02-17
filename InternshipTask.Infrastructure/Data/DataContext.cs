using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using InternshipTask.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace InternshipTask.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Product> Products => Set<Product>();
        public DbSet<User> Users => Set<User>();
    }
}