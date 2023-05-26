using BakeSale.Models;
using BakeSale.Models.Enums;
using BakeSale.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BakeSale.Repositories
{
    public class SalesRepository : BaseRepository<Sale>, ISalesRepository
    {
        public SalesRepository(BakeSaleContext context) : base(context){ }
        protected override DbSet<Sale> GetDbSet(BakeSaleContext context) => context.Sales;
        public override async Task<IEnumerable<Sale>> GetAllAsync()
        {
            return await dbSet
                .Include(x => x.Products)
                .ThenInclude(x => x.PurchasesLines)
                .ToListAsync();
        }
        public override async Task<Sale?> GetAsync(int id)
        {
            return await dbSet
                .Include(x => x.Products)
                .ThenInclude(x => x.PurchasesLines)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
