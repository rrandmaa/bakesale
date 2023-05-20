using Microsoft.AspNetCore.Mvc;
using BakeSale.Models;
using BakeSale.Repositories;
using BakeSale.Models.Enums;
using System.Data;

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
            if (!_productsRepo.EntityExists(purchase.ProductId))
            {
                return BadRequest();
            }

            purchase.Status = PurchaseStatus.Pending;

            await _purchasesRepo.PostAsync(purchase);

            return CreatedAtAction("GetPurchase", new { id = purchase.Id }, purchase);
        }

        // POST: api/Purchases/5/confirm
        [HttpPost("{id}/confirm")]
        public async Task<ActionResult> ConfirmPurchase(int id)
        {
            try
            {
                await _purchasesRepo.ConfirmPurchase(id);
            } 
            catch (DataException)
            {
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Purchases/5/cancel
        [HttpPost("{id}/cancel")]
        public async Task<ActionResult> CancelPurchase(int id)
        {
            try
            {
                await _purchasesRepo.CancelPurchase(id);
            }
            catch (DataException)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
