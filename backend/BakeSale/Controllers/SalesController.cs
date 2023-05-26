using Microsoft.AspNetCore.Mvc;
using BakeSale.Models;
using BakeSale.Repositories;

namespace BakeSale.Controllers
{
    /// <summary>
    /// Routes for managing <see cref="Sale"/> resources.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesRepository _repo;

        public SalesController(ISalesRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Endpoint for requesting all <see cref="Sale"/> resources.
        /// </summary>
        /// <response code="200">Returned along with all sales.</response>
        /// <response code="404">Returned if no collection of sales was found.</response>
        // GET: api/Sales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSales()
        {
            var sales = await _repo.GetAllAsync();

            if (sales is null)
            {
                return NotFound();
            }
           
            return Ok(sales);
        }

        /// <summary>
        /// Endpoint for requesting a single <see cref="Sale"/> resource with the specified ID.
        /// </summary>
        /// <param name="id">A route parameter. The ID of the sale that would be returned.</param>
        /// <response code="200">Returned along with the sale with the specified ID.</response>
        /// <response code="404">Returned if no sale with the specified ID was found.</response>
        // GET: api/Sales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSale(int id)
        {
            var sale = await _repo.GetAsync(id);

            if (sale is null)
            {
                return NotFound();
            }

            return sale;
        }

        /// <summary>
        /// Endpoint for posting a <see cref="Sale"/> resource. 
        /// The purchase should be posted with an array of <see cref="Product"/> resources attatched. Refer to the schema.
        /// </summary>
        /// <param name="sale">Body of the request. The sale that would be processed and persisted.</param>
        /// <response code="201">Returned along with the sale that was successfully created.</response>
        // POST: api/Sales
        [HttpPost]
        public async Task<ActionResult<Sale>> PostSale(Sale sale)
        { 
            await _repo.PostAsync(sale);

            return CreatedAtAction("GetSale", new { id = sale.Id }, sale);
        }
    }
}
