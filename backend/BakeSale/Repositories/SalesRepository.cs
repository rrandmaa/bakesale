using BakeSale.Models;
using BakeSale.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace BakeSale.Repositories
{
    public class SalesRepository : BaseRepository<Sale>, ISalesRepository
    {
        public SalesRepository(BakeSaleContext context) : base(context){ }
        protected override DbSet<Sale> GetDbSet(BakeSaleContext context) => context.Sales;
        public async override Task<IEnumerable<Sale>> GetAllAsync()
        {
            return await dbSet
                .Include(x => x.Products)
                .ThenInclude(x => x.Purchases)
                .ToListAsync();
        }
    }
}
