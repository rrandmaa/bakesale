using BakeSale.Models.Enums;

namespace BakeSale.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public PurchaseStatus Status { get; set; }
        public int Quantity { get; set; }
    }
}
