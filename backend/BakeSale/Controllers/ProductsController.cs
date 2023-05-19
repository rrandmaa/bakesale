using Microsoft.AspNetCore.Mvc;
using BakeSale.Models;
using BakeSale.Repositories;
using Microsoft.EntityFrameworkCore;

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

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id) return BadRequest();

            try
            {
                await _repo.UpdateAsync(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repo.EntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
    }
}
