using BakeSale.Models.Common;
using BakeSale.Models.Enums;

namespace BakeSale.Models
{
    public class Sale : UniqueEntity
    {
        public string? Name { get; set; }
        public SaleStatus Status { get; set; }
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
