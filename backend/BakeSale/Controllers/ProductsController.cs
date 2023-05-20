using Microsoft.AspNetCore.Mvc;
using BakeSale.Models;
using BakeSale.Repositories;

namespace BakeSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _repo;

        public ProductsController(IProductsRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _repo.GetAllAsync();
            
            if (products is null)
            {
                return NotFound();
            }
            
            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _repo.GetAsync(id);

            if (product is null)
            {
                return NotFound();
            }

            return product;
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            await _repo.PostAsync(product);

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // POST: api/Products/Range
        [HttpPost("Range")]
        public async Task<ActionResult<List<Product>>> PostProducts(List<Product> products)
        {
            await _repo.PostRangeAsync(products);

            return Ok();
        }
    }
}
