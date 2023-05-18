using BakeSale.Models;

namespace BakeSale.Repositories
{
    public interface IProductsRepository {
        public Task<IEnumerable<Product>> GetAllAsync();
    }
}
