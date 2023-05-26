using BakeSale.Models.Enums;
using BakeSale.Models;

namespace Tests
{
    public static class TestDataHelper
    {
        public static List<Sale> GetTestSaleData()
        {
            List<Sale> sales = new()
            {
                new Sale() { Name = "Sale 1", Status = SaleStatus.Active },
                new Sale() { Name = "Sale 2", Status = SaleStatus.Finished },
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
                new Product() { Name = "Product 1", InitialQuantity = 10, Price = 10, SaleId = saleId },
                new Product() { Name = "Product 2", InitialQuantity = 10, Price = 10, SaleId = saleId },
                new Product() { Name = "Product 3", InitialQuantity = 10, Price = 10, SaleId = saleId },
                new Product() { Name = "Product 4", InitialQuantity = 10, Price = 10, SaleId = saleId },
            };
        }

        public static List<PurchaseLine> GetTestPurchaseLineData(int purchaseId, int productId)
        {
            return new()
            {
                new PurchaseLine() { ProductId = productId, PurchaseId = purchaseId, Quantity = 1 },
                new PurchaseLine() { ProductId = productId, PurchaseId = purchaseId, Quantity = 1 },
                new PurchaseLine() { ProductId = productId, PurchaseId = purchaseId, Quantity = 1 },
            };
        }
    }
}
