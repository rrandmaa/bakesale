using BakeSale.Models;
using BakeSale.Repositories;
using BakeSale.Repositories.Common;

namespace Tests.Repositories
{
    [TestClass]
    public class SalesRepositoryTests : RepositoryTestBase
    {
        private readonly SalesRepository _repo;
        public SalesRepositoryTests() : base()
        {
            _repo = new SalesRepository(_context);
        }

        [TestMethod] public void InheritanceTests()
        {
            Assert.IsInstanceOfType(_repo, typeof(BaseRepository<Sale>));
            Assert.IsInstanceOfType(_repo, typeof(ISalesRepository));
        }

        [TestMethod] public async Task GetAllAsyncTest()
        {
            var expected = TestDataHelper.GetTestSaleData();
            
            await _context.Sales.AddRangeAsync(expected);
            await _context.SaveChangesAsync();

            var actual = await _repo.GetAllAsync();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count, actual.Count());

            foreach (var sale in actual)
            {
                Assert.AreNotEqual(0, sale.Products.Count());

                foreach (var product in sale.Products)
                {
                    Assert.AreNotEqual(0, product.PurchasesLines.Count());
                }
            }
        }

        [TestMethod] public async Task GetAsyncTest()
        {
            var expected = TestDataHelper.GetTestSaleData()[0];

            await _context.Sales.AddAsync(expected);
            await _context.SaveChangesAsync();

            var actual = await _repo.GetAsync(expected.Id);

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(0, actual.Products.Count());

            foreach (var product in actual.Products)
            {
                Assert.AreNotEqual(0, product.PurchasesLines);
            }
        }
    }
}
