using BakeSale.Models;

namespace BakeSale.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        public List<Product> GetAll()
        {
            return new List<Product>
            {
                new Product { Id = 1 },
                new Product { Id = 2 },
                new Product { Id = 3 },
                new Product { Id = 4 }
            };
        }
    }
}
