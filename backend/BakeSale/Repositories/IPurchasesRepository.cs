using BakeSale.Models;
using BakeSale.Repositories.Common;

namespace BakeSale.Repositories
{
    public interface IPurchasesRepository: IRepository<Purchase> {
        public Task<IEnumerable<Purchase>> GetBySaleIdAsync(int saleId);
    }
}
