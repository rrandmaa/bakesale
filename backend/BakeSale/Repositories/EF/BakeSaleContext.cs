using BakeSale.Models;
using Microsoft.EntityFrameworkCore;

namespace BakeSale.Repositories.Common
{
    public class BakeSaleContext : DbContext
    {
        public BakeSaleContext(DbContextOptions<BakeSaleContext> options) : base(options) { }
        public DbSet<Sale> Sales { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Purchase> Purchases { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new DbInitializer(modelBuilder).Seed();
        }
    }
}
