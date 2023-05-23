using BakeSale.Models;
using BakeSale.Repositories.Common;

namespace BakeSale.Repositories
{
    public interface IProductsRepository: IRepository<Product>
    {
        public Task PostRangeAsync(IEnumerable<Product> products);
    }
}
