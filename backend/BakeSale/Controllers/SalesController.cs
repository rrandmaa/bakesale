using Microsoft.AspNetCore.Mvc;
using BakeSale.Models;
using BakeSale.Repositories;
using System.Data;

namespace BakeSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesRepository _repo;

        public SalesController(ISalesRepository repo)
        {
            _repo = repo;
        }

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

        // POST: api/Sales
        [HttpPost]
        public async Task<ActionResult<Sale>> PostSale(Sale sale)
        { 
            await _repo.PostAsync(sale);

            return CreatedAtAction("GetSale", new { id = sale.Id }, sale);
        }
    }
}
