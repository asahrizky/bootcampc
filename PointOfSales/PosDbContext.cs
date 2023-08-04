using Microsoft.EntityFrameworkCore;
using PointOfSales.Models;

namespace PointOfSales
{
    public class PosDbContext : DbContext
    {
        public PosDbContext(DbContextOptions<PosDbContext> options) : base(options)
        {
            
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

    }
}
