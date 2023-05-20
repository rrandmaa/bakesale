using BakeSale.Models;
using BakeSale.Repositories.Common;

namespace BakeSale.Repositories
{
    public interface IPurchasesRepository: IRepository<Purchase> 
    {
        public Task ConfirmPurchase(int id);
        public Task CancelPurchase(int id);
    }
}
