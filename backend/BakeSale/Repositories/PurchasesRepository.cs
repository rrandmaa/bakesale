using BakeSale.Models;
using BakeSale.Models.Enums;
using BakeSale.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BakeSale.Repositories
{
    public class PurchasesRepository: BaseRepository<Purchase>, IPurchasesRepository
    {
        public PurchasesRepository(BakeSaleContext context): base(context) { }
        protected override DbSet<Purchase> GetDbSet(BakeSaleContext context) => context.Purchases;
        public async Task ConfirmPurchase(int id)
        {
            Purchase purchase = await GetAsync(id) ?? throw new DataException();

            if (purchase.Status is not PurchaseStatus.Pending) throw new DataException();

            purchase.Status = PurchaseStatus.Completed;

            await UpdateAsync(purchase);
        }
        public async Task CancelPurchase(int id)
        {
            Purchase purchase = await GetAsync(id) ?? throw new DataException();

            if (purchase.Status is not PurchaseStatus.Pending) throw new DataException();

            await DeleteAsync(id);
        }
    }
}
