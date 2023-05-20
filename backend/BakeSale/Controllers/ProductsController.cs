using Microsoft.AspNetCore.Mvc;
using BakeSale.Models;
using BakeSale.Repositories;

namespace BakeSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepo;
        private readonly ISalesRepository _salesRepo;

        public ProductsController(IProductsRepository repo, ISalesRepository salesRepo)
        {
            _productsRepo = repo;
            _salesRepo = salesRepo;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productsRepo.GetAllAsync();
            
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
            var product = await _productsRepo.GetAsync(id);

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
            if (!_salesRepo.EntityExists(product.SaleId))
            {
                return BadRequest();
            }

            await _productsRepo.PostAsync(product);

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // POST: api/Products/Range
        [HttpPost("Range")]
        public async Task<ActionResult<List<Product>>> PostProducts(List<Product> products)
        {
            //TODO: add range posting validation

            await _productsRepo.PostRangeAsync(products);

            return Ok();
        }
    }
}
