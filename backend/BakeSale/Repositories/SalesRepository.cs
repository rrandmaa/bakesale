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
        public async override Task<IEnumerable<Sale>> GetAllAsync()
        {
            return await dbSet
                .Include(x => x.Products)
                .ThenInclude(x => x.Purchases)
                .ToListAsync();
        }
        public async Task FinishSale(int id)
        {
            Sale sale = await GetAsync(id) ?? throw new DataException();

            if (sale.Status is not SaleStatus.Active) throw new DataException();

            sale.Status = SaleStatus.Finished;

            await UpdateAsync(sale);
        }
    }
}
