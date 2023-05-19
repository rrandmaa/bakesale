using BakeSale.Models;
using BakeSale.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace BakeSale.Repositories
{
    public class PurchasesRepository: BaseRepository<Purchase>, IPurchasesRepository
    {
        public PurchasesRepository(BakeSaleContext context): base(context) { }
        protected override DbSet<Purchase> GetDbSet(BakeSaleContext context) => context.Purchases;
    }
}
