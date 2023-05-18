﻿using BakeSale.Models;
using BakeSale.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace BakeSale.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly BakeSaleContext _context;

        public ProductsRepository(BakeSaleContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            _context.Products.Update(entity);
            await _context.SaveChangesAsync();
        }

        public bool EntityExists(int id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
