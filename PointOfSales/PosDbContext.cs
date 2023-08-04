using Microsoft.EntityFrameworkCore;
using PointOfSales.Models;

namespace PointOfSales
{
    public class PosDbContext : DbContext
    {
        public PosDbContext(DbContextOptions<PosDbContext> options) : base(options)
        {
            
        }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Category> Category { get; set; }

    }
}
