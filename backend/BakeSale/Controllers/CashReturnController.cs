using BakeSale.Models.CashReturn;
using Microsoft.AspNetCore.Mvc;

namespace BakeSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashReturnController : ControllerBase
    {
        public CashReturnController() { }

        // POST: api/CashReturn
        [HttpPost]
        public ActionResult<List<CashReturnResponseLine>> CalculateCashReturn(decimal cashPaid, decimal totalPrice)
        {
            return EuroCashReturnCalculator.FindReturnCurrencyNotes(cashPaid - totalPrice);
        }
    }
}
