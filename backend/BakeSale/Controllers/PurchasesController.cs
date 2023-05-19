using Microsoft.AspNetCore.Mvc;
using BakeSale.Models;
using BakeSale.Repositories;

namespace BakeSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly PurchasesRepository _repo;

        public PurchasesController(PurchasesRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Purchases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetPurchases()
        {
            var products = await _repo.GetAllAsync();

            if (products is null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        // GET: api/Purchases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Purchase>> GetPurchase(int id)
        {
            var purchase = await _repo.GetAsync(id);

            if (purchase == null)
            {
                return NotFound();
            }

            return purchase;
        }


        // POST: api/Purchases
        [HttpPost]
        public async Task<ActionResult<Purchase>> PostPurchase(Purchase purchase)
        {
            await _repo.PostAsync(purchase);

            return CreatedAtAction("GetPurchase", new { id = purchase.Id }, purchase);
        }
    }
}
