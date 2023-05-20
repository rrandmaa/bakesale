﻿using BakeSale.Models.Enums;
using BakeSale.Models;
using Microsoft.EntityFrameworkCore;

namespace BakeSale.Repositories.Common
{
    public class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            _modelBuilder.Entity<Sale>().HasData(
                new Sale
                {
                    Id = 1,
                    Name = "Charity Bake Sale",
                    Status = SaleStatus.Active
                }
            );

            _modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Type = ProductType.Edible,
                    Name = "Brownie",
                    SaleId = 1,
                    InitialQuantity = 48,
                    Price = 0.65m,
                },
                new Product
                {
                    Id = 2,
                    Type = ProductType.Edible,
                    Name = "Muffin",
                    SaleId = 1,
                    InitialQuantity = 36,
                    Price = 1.00m,
                },
                new Product
                {
                    Id = 3,
                    Type = ProductType.Edible,
                    Name = "Cake Pop",
                    SaleId = 1,
                    InitialQuantity = 24,
                    Price = 1.35m,
                },
                new Product
                {
                    Id = 4,
                    Type = ProductType.Edible,
                    Name = "Apple Tart",
                    SaleId = 1,
                    InitialQuantity = 60,
                    Price = 1.50m,
                },
                new Product
                {
                    Id = 5,
                    Type = ProductType.Edible,
                    Name = "Water",
                    SaleId = 1,
                    InitialQuantity = 30,
                    Price = 1.50m,
                }
            );

            _modelBuilder.Entity<Purchase>().HasData(
                new Purchase
                {
                    Id = 1,
                    ProductId = 1,
                    Status = PurchaseStatus.Completed,
                    Quantity = 5,
                },
                new Purchase
                {
                    Id = 2,
                    ProductId = 1,
                    Status = PurchaseStatus.Completed,
                    Quantity = 3,
                },
                new Purchase
                {
                    Id = 3,
                    ProductId = 2,
                    Status = PurchaseStatus.Pending,
                    Quantity = 2,
                },
                new Purchase
                {
                    Id = 4,
                    ProductId = 2,
                    Status = PurchaseStatus.Pending,
                    Quantity = 10,
                }
            );
        }
    }
}
