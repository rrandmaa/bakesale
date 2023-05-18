using BakeSale.Models;

namespace BakeSale.Repositories
{
    public interface IProductsRepository {
        public List<Product> GetAll();
    }
}
