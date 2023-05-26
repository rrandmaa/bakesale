using BakeSale.Models;

namespace Tests.Model
{
    [TestClass]
    public class SaleTests
    {
        private Sale _sale = new();

        [TestInitialize]
        public void TestInitialize() 
        {
            _sale = new Sale();
        }

        [DataRow(10, 8, 1, true)]
        [DataRow(10, 8, 2, true)]
        [DataRow(10, 8, 12, false)]
        [DataRow(10, 0, 12, false)]
        [TestMethod] public void ValidatePurchaseTest(int productQuantity, int purchasedQuantity, int desiredQuantity, bool expected)
        {
            var purchaseLines = new List<PurchaseLine>();

            _sale.Products = new List<Product>() { 
                TestDataHelper.NewProduct(_sale.Id, productQuantity),
                TestDataHelper.NewProduct(_sale.Id, productQuantity),
            };

            foreach (var product in _sale.Products)
            {
                var purchaseLine = TestDataHelper.NewPurchaseLine(TestDataHelper.GetId(), product.Id, purchasedQuantity);
                product.PurchasesLines = new List<PurchaseLine>(){ purchaseLine };
                purchaseLines.Add(TestDataHelper.NewPurchaseLine(TestDataHelper.GetId(), product.Id, desiredQuantity));
            }

            var purchase = new Purchase() { PurchaseLines = purchaseLines };

            Assert.AreEqual(expected, _sale.ValidatePurchase(purchase));
        }
    }
}
