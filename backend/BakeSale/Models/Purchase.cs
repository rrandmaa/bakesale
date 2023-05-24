using BakeSale.Models.Common;
using BakeSale.Models.Enums;

namespace BakeSale.Models
{
    public class Purchase: UniqueEntity
    {
        public IEnumerable<PurchaseLine> PurchaseLines { get; set; } = new List<PurchaseLine>();
    }
}
