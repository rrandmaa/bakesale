using BakeSale.Models;
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
    }
}
