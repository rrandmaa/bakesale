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
        private readonly ISalesRepository _salesRepo;
        private readonly IProductsRepository _productsRepo;

        public SalesController(ISalesRepository salesRepo, IProductsRepository productsRepo)
        {
            _salesRepo = salesRepo;
            _productsRepo = productsRepo;
        }

        // GET: api/Sales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSales()
        {
            var sales = await _salesRepo.GetAllAsync();

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
            var sale = await _salesRepo.GetAsync(id);

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
            await _salesRepo.PostAsync(sale);

            await _productsRepo.PostRangeAsync(sale.Products);

            return CreatedAtAction("GetSale", new { id = sale.Id }, sale);
        }

        // POST: api/Sales/5/finish
        [HttpPost("{id}/Finish")]
        public async Task<ActionResult> FinishSale(int id)
        {
            try
            {
                await _salesRepo.FinishSale(id);
            }
            catch (DataException)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
