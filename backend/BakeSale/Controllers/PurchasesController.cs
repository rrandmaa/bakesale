using Microsoft.AspNetCore.Mvc;
using BakeSale.Models;
using BakeSale.Repositories;

namespace BakeSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly IPurchasesRepository _purchasesRepo;
        private readonly IProductsRepository _productsRepo;

        public PurchasesController(IPurchasesRepository purchasesRepo, IProductsRepository productsRepo)
        {
            _purchasesRepo = purchasesRepo;
            _productsRepo = productsRepo;
        }

        // GET: api/Purchases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetPurchases()
        {
            var products = await _purchasesRepo.GetAllAsync();

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
            var purchase = await _purchasesRepo.GetAsync(id);

            if (purchase is null)
            {
                return NotFound();
            }

            return purchase;
        }

        // POST: api/Purchases
        [HttpPost]
        public async Task<ActionResult<Purchase>> PostPurchase(Purchase purchase)
        {
            if (purchase.PurchaseLines.Any(x => !_productsRepo.EntityExists(x.ProductId)))
            {
                return BadRequest();
            }

            await _purchasesRepo.PostAsync(purchase);

            return CreatedAtAction("GetPurchase", new { id = purchase.Id }, purchase);
        }
    }
}
