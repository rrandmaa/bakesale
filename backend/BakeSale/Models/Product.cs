using BakeSale.Models.Common;
using BakeSale.Models.Enums;
using System.Text.Json.Serialization;

namespace BakeSale.Models
{
    public class Product: UniqueEntity
    {
        public string? Name { get; set; }
        public ProductType Type { get; set; }
        public int SaleId { get; set; }
        public int InitialQuantity { get; set; }
        public decimal Price { get; set; }
        [JsonIgnore] public IEnumerable<PurchaseLine> PurchasesLines { get; set; } = new List<PurchaseLine>();
        public int RemainingQuantity => InitialQuantity - PurchasesLines.Sum(p => p.Quantity);
    }
}
