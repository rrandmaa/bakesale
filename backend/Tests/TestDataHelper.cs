using BakeSale.Models.Enums;
using BakeSale.Models;

namespace Tests
{
    public static class TestDataHelper
    {
        private static IEnumerator<int> IdEnumerator = Enumerable.Range(0, int.MaxValue).GetEnumerator();
        public static List<Sale> GetTestSaleData()
        {
            List<Sale> sales = new()
            {
                NewSale(),
                NewSale(),
            };

            foreach (Sale sale in sales)
            {
                sale.Products = GetTestProductData(sale.Id);

                foreach (Product product in sale.Products)
                {
                    product.PurchasesLines = GetTestPurchaseLineData(0, product.Id);
                }
            }

            return sales;
        }

        public static List<Product> GetTestProductData(int saleId)
        {
            return new()
            {
                NewProduct(saleId),
                NewProduct(saleId),
                NewProduct(saleId),
                NewProduct(saleId),
            };
        }

        public static List<Purchase> GetTestPurchaseData(int saleId)
        {
            List<Purchase> purchases = new()
            {
                NewPurchase(saleId),
                NewPurchase(saleId),
                NewPurchase(saleId),
            };

            foreach (var purchase in purchases)
            {
                purchase.PurchaseLines = GetTestPurchaseLineData(purchase.Id, 0);
            }

            return purchases;
        }

        public static List<PurchaseLine> GetTestPurchaseLineData(int purchaseId, int productId)
        {
            return new()
            {
                NewPurchaseLine(purchaseId, productId),
                NewPurchaseLine(purchaseId, productId),
                NewPurchaseLine(purchaseId, productId),
            };
        }
        public static Sale NewSale() => new() { Id = GetId(), Name = "Sale X" };
        public static Product NewProduct(int saleId) => new() { Id = GetId(), Name = "Product X", InitialQuantity = 10, Price = 10, SaleId = saleId };
        public static Product NewProduct(int saleId, int initialQuantity) 
            => new() { Id = GetId(), Name = "Product X", InitialQuantity = initialQuantity, Price = 10, SaleId = saleId };
        public static Purchase NewPurchase(int saleId) => new() { Id = GetId(), SaleId = saleId };
        public static PurchaseLine NewPurchaseLine(int purchaseId, int productId) 
            => new() { Id = GetId(), ProductId = productId, PurchaseId = purchaseId, Quantity = 1 };
        public static PurchaseLine NewPurchaseLine(int purchaseId, int productId, int quantity)
            => new() { Id = GetId(), ProductId = productId, PurchaseId = purchaseId, Quantity = quantity };
        public static int GetId()
        {
            IdEnumerator.MoveNext();
            return IdEnumerator.Current;
        }
    }
}
