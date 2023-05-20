using BakeSale.Models;
using BakeSale.Repositories.Common;

namespace BakeSale.Repositories
{
    public interface ISalesRepository : IRepository<Sale> 
    {
        public Task FinishSale(int id);
    }
}
