using BakeSale.Models.Common;

namespace BakeSale.Models
{
    public class Purchase: UniqueEntity
    {
        public int SaleId { get; set; }
        public IEnumerable<PurchaseLine> PurchaseLines { get; set; } = new List<PurchaseLine>();
    }
}
