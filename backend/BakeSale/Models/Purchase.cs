using BakeSale.Models.Common;
using BakeSale.Models.Enums;

namespace BakeSale.Models
{
    public class Purchase: UniqueEntity
    {
        public int ProductId { get; set; }
        public PurchaseStatus Status { get; set; }
        public int Quantity { get; set; }
    }
}
