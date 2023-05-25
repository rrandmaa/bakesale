using Microsoft.AspNetCore.Mvc;
using BakeSale.Models;
using BakeSale.Repositories;

namespace BakeSale.Controllers
{
    [Route("api/Sales/{saleId}/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly IPurchasesRepository _purchasesRepo;
        private readonly ISalesRepository _salesRepo;

        public PurchasesController(IPurchasesRepository purchasesRepo, ISalesRepository salesRepo)
        {
            _purchasesRepo = purchasesRepo;
            _salesRepo = salesRepo;
        }

        // GET: api/Sales/5/Purchases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetPurchases(int saleId)
        {
            if (!_salesRepo.EntityExists(saleId))
            {
                return BadRequest();
            }

            var purchases = await _purchasesRepo.GetBySaleIdAsync(saleId);

            if (purchases is null)
            {
                return NotFound();
            }

            return Ok(purchases);
        }

        // GET: api/Sales/5/Purchases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Purchase>> GetPurchase(int saleId, int id)
        {
            if (!_salesRepo.EntityExists(saleId))
            {
                return BadRequest();
            }

            var purchase = await _purchasesRepo.GetAsync(id);

            if (purchase is null)
            {
                return NotFound();
            }

            return purchase;
        }

        // POST: api/Sales/5/Purchases
        [HttpPost]
        public async Task<ActionResult<Purchase>> PostPurchase(Purchase purchase, int saleId)
        {
            var sale = await _salesRepo.GetAsync(saleId);

            if (sale is null)
            {
                return BadRequest();
            }

            if (!sale.ValidatePurchase(purchase))
            {
                return BadRequest();
            }

            purchase.SaleId = sale.Id;

            await _purchasesRepo.PostAsync(purchase);

            return CreatedAtAction("GetPurchase", new { saleId = sale.Id, id = purchase.Id }, purchase);
        }
    }
}
