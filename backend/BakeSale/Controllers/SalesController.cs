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
        private readonly IPurchasesRepository _puchasesRepo;

        public SalesController(ISalesRepository salesRepo, IPurchasesRepository purchasesRepo)
        {
            _salesRepo = salesRepo;
            _puchasesRepo = purchasesRepo;
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

        // GET: api/Sales/5/Purchases
        [HttpGet("{id}/Purchases")]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetSalePurchases(int id)
        {
            if (!_salesRepo.EntityExists(id))
            {
                return BadRequest();
            }

            var purchases = await _puchasesRepo.GetBySaleIdAsync(id);

            if (purchases is null)
            {
                return NotFound();
            }

            return Ok(purchases);
        }
    }
}
