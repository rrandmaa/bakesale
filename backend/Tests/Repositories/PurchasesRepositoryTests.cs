using BakeSale.Models;
using BakeSale.Repositories;
using BakeSale.Repositories.Common;

namespace Tests.Repositories
{
    [TestClass]
    public class PurchasesRepositoryTests : RepositoryTestBase
    {
        private readonly PurchasesRepository _repo;
        public PurchasesRepositoryTests() : base()
        {
            _repo = new PurchasesRepository(_context);
        }

        [TestMethod] public void InheritanceTests()
        {
            Assert.IsInstanceOfType(_repo, typeof(BaseRepository<Purchase>));
            Assert.IsInstanceOfType(_repo, typeof(IPurchasesRepository));
        }

        [TestMethod] public async Task GetBySaleIdTests()
        {
            var expectedSaleId = TestDataHelper.GetId();
            var expected = TestDataHelper.GetTestPurchaseData(expectedSaleId);
            var purchasesWithDifferentSaleIds = TestDataHelper.GetTestPurchaseData(TestDataHelper.GetId());

            await _context.Purchases.AddRangeAsync(expected);
            await _context.Purchases.AddRangeAsync(purchasesWithDifferentSaleIds);
            await _context.SaveChangesAsync();
            
            var actual = await _repo.GetBySaleIdAsync(expectedSaleId);

            Assert.IsNotNull(actual); 
            Assert.AreEqual(expected.Count, actual.Count());

            foreach (var product in actual)
            {
                Assert.AreNotEqual(0, product.PurchaseLines.Count());
            }
        }
    }
}
