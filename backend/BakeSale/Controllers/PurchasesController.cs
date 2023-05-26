using Microsoft.AspNetCore.Mvc;
using BakeSale.Models;
using BakeSale.Repositories;

namespace BakeSale.Controllers
{
    /// <summary>
    /// Routes for managing <see cref="Purchase"/> resources. A purchase is a sub-resource of <see cref="Sale"/>.
    /// </summary>
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

        /// <summary>
        /// Endpoint for requesting all <see cref="Purchase"/> resources with a specified sale ID.
        /// </summary>
        /// <param name="saleId">A route parameter. ID of the sale these purchases belongs to.</param>
        /// <response code="200">Returned along with all purchases that have the speficied sale ID.</response>
        /// <response code="400">Returned if no <see cref="Sale"/> with the specified ID exists.</response>
        /// <response code="404">Returned if no collection of purchases is found.</response>
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

        /// <summary>
        /// Endpoint for requesting a single <see cref="Purchase"/> resource.
        /// </summary>
        /// <param name="saleId">A route parameter. ID of the sale this purchase belongs to.</param>
        /// <param name="id">A route parameter. ID of the purchase that would be returned.</param>
        /// <response code="200">Returned along with the purchases that has the speficied ID.</response>
        /// <response code="400">Returned if no <see cref="Sale"/> with the specified sale ID exists.</response>
        /// <response code="404">Returned if no the purchase with the specified ID is found.</response>
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

        /// <summary>
        /// Endpoint for posting a <see cref="Purchase"/> resource. 
        /// The purchase should be posted with an array of <see cref="PurchaseLine"/> resources attatched. Refer to the schema.
        /// </summary>
        /// <param name="purchase">Body of the request. The purchase that would be processed and persisted.</param>
        /// <param name="saleId">A route parameter. ID of the <see cref="Sale"/> this purchase belongs to.</param>
        /// <response code="201">Returned along with the purchase that was successfully created.</response>
        /// <response code="400">Returned if no <see cref="Sale"/> with the specified sale ID exists 
        /// or if products did not have enough stock for this purchase to be valid.</response>
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
