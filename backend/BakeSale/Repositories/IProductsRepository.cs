using BakeSale.Models;
using BakeSale.Repositories.Common;

namespace BakeSale.Repositories
{
    public interface IProductsRepository: IRepository<Product>
    {
        public Task PostRangeAsync(List<Product> products);
    }
}
