using BakeSale.Models.Common;

namespace BakeSale.Models
{
    public class PurchaseLine: UniqueEntity
    {
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
