using BakeSale.Models;
using BakeSale.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace BakeSale.Repositories
{
    public class ProductsRepository : BaseRepository<Product>, IProductsRepository
    {       
        public ProductsRepository(BakeSaleContext context) : base(context) { }
        protected override DbSet<Product> GetDbSet(BakeSaleContext context) => context.Products;
        public async override Task<IEnumerable<Product>> GetAllAsync()
        {
            return await dbSet.Include(x => x.Purchases).ToListAsync();
        }
    }
}
