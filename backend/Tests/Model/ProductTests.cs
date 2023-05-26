using BakeSale.Models;

namespace Tests.Model
{
    [TestClass]
    public class ProductTests
    {
        [DataRow(10, 4, 2)]
        [DataRow(10, 5, 0)]
        [DataRow(10, 0, 10)]
        [TestMethod] public void RemainingQuantityTest(int initalQuanity, int singlePurchaseLineQuantity, int expected)
        {
            var product = TestDataHelper.NewProduct(TestDataHelper.GetId());
            product.InitialQuantity = initalQuanity;

            product.PurchasesLines = new List<PurchaseLine>()
            {
                TestDataHelper.NewPurchaseLine(TestDataHelper.GetId(), product.Id, singlePurchaseLineQuantity),
                TestDataHelper.NewPurchaseLine(TestDataHelper.GetId(), product.Id, singlePurchaseLineQuantity),
            };

            Assert.AreEqual(expected, product.RemainingQuantity);
        }
    }
}
