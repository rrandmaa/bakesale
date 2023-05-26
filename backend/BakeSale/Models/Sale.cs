using BakeSale.Models.Common;
using BakeSale.Models.Enums;

namespace BakeSale.Models
{
    public class Sale : UniqueEntity
    {
        public string? Name { get; set; }
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public bool ValidatePurchase(Purchase purchase)
        {
            foreach (PurchaseLine purchaseLine in purchase.PurchaseLines)
            {
                Product? product = Products.FirstOrDefault(x => x.Id == purchaseLine.ProductId);

                if (product is null) { 
                    return false; 
                }

                if (purchaseLine.Quantity > product.RemainingQuantity)
                {
                    return false;
                }
            }
            return true;
        } 
    }
}
