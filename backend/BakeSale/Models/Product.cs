using BakeSale.Models.Common;
using BakeSale.Models.Enums;

namespace BakeSale.Models
{
    public class Product: UniqueEntity
    {
        public ProductType Type { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<Purchase>? Purchases { get; set; }
    }
}
