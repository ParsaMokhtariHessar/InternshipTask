using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace InternshipTask.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) 
        {

        }
        public DbSet<Product> Products =>Set<Product>();
    }
}