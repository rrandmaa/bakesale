﻿using BakeSale.Models;
using Microsoft.EntityFrameworkCore;

namespace BakeSale.Repositories.Common
{
    public class BakeSaleContext : DbContext
    {
        public BakeSaleContext(DbContextOptions<BakeSaleContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new DbInitializer(modelBuilder).Seed();
        }
    }
}
