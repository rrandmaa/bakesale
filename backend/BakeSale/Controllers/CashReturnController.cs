using BakeSale.Models.CashReturn;
using Microsoft.AspNetCore.Mvc;

namespace BakeSale.Controllers
{
    /// <summary>
    /// Route for actions related to cash returns on purchases
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CashReturnController : ControllerBase
    {
        public CashReturnController() { }

        /// <summary>
        /// Provides the means to calculate the cash return on a payment with the least amount of notes or coins.
        /// </summary>
        /// <param name="cashPaid">The amount of cash provided by the client to pay for the purchase.</param>
        /// <param name="totalPrice">Total price of the purchase being made.</param>
        /// <response code="200">An array of <see cref="CashReturnResponseLine"/> objects, each containing a note or coin value 
        /// and the amount that note or coin should be given back as the cash return.</response>
        /// <response code="400">Is returned if the cash paid is smaller than the total price to be paid.</response>
        // GET: api/CashReturn?cashPaid=16&totalPrice=9
        [HttpGet]
        public ActionResult<List<CashReturnResponseLine>> CalculateCashReturn(decimal cashPaid, decimal totalPrice)
        {
            if (cashPaid < totalPrice)
            {
                return BadRequest();
            }
            return EuroCashReturnCalculator.FindReturnCurrencyNotes(cashPaid - totalPrice);
        }
    }
}
