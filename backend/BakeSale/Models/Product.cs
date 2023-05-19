using BakeSale.Models.Common;
using BakeSale.Models.Enums;
using System.Text.Json.Serialization;

namespace BakeSale.Models
{
    public class Product: UniqueEntity
    {
        public ProductType Type { get; set; }
        public string? Name { get; set; }
        public int InitialQuantity { get; set; }
        public decimal Price { get; set; }
        [JsonIgnore] public IEnumerable<Purchase> Purchases { get; set; } = new List<Purchase>();
        public int RemainingQuantity => InitialQuantity - Purchases.Sum(p => p.Quantity);
    }
}
