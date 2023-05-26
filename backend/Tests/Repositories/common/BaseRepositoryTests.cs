using BakeSale.Models;
using BakeSale.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Tests.Repositories.common
{
    [TestClass]
    public class BaseRepositoryTests : RepositoryTestBase
    {
        // Since this is an abstract class, it is tested as a stub implementation for a plain domain object
        private class testRepoClass : BaseRepository<PurchaseLine>
        {
            public testRepoClass(BakeSaleContext context) : base(context) { }
            protected override DbSet<PurchaseLine> GetDbSet(BakeSaleContext context) => context.PurchaseLines;
        }

        private readonly testRepoClass _repo;

        public BaseRepositoryTests() : base() 
        {
            _repo = new testRepoClass(_context);
        }

        [TestMethod] public void InheritanceTest()
        {
            Assert.IsInstanceOfType(_repo, typeof(IRepository<PurchaseLine>));
        }

        [TestMethod] public async Task GetAllAsyncTest()
        {
            var expected = TestDataHelper.GetTestPurchaseLineData(0, 0);

            await _context.PurchaseLines.AddRangeAsync(expected);
            await _context.SaveChangesAsync();

            var actual = await _repo.GetAllAsync();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count, actual.Count());
        }

        [TestMethod] public async Task GetAsyncTest()
        {
            var expected = TestDataHelper.NewPurchaseLine(0, 0);

            await _context.PurchaseLines.AddAsync(expected);
            await _context.SaveChangesAsync();

            var actual = await _repo.GetAsync(expected.Id);

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod] public async Task PostAsyncTest()
        {
            var expected = TestDataHelper.NewPurchaseLine(0, 0);

            await _repo.PostAsync(expected);

            var actual = await _context.PurchaseLines.FindAsync(expected.Id);

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod] public async Task UpdateAsyncTest()
        {
            var initial = TestDataHelper.NewPurchaseLine(0, 0);

            await _context.PurchaseLines.AddAsync(initial);
            await _context.SaveChangesAsync();

            var expected = new PurchaseLine() { Id = initial.Id, ProductId = initial.ProductId, PurchaseId = initial.PurchaseId, Quantity = 99 };

            await _repo.UpdateAsync(expected);

            var actual = await _context.PurchaseLines.SingleAsync(x => x.Id == expected.Id);

            Assert.AreNotEqual(initial, actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod] public async Task DeleteAsyncTest()
        {
            var expected = TestDataHelper.NewPurchaseLine(0, 0);

            await _context.PurchaseLines.AddAsync(expected);
            await _context.SaveChangesAsync();

            var actual = await _context.PurchaseLines.FindAsync(expected.Id);

            Assert.AreEqual(expected, actual);

            await _repo.DeleteAsync(expected.Id);

            actual = await _context.PurchaseLines.FindAsync(expected.Id);

            Assert.IsNull(actual);
        }

        [TestMethod] public async Task EntityExistsTest()
        {
            var expected = TestDataHelper.NewPurchaseLine(0, 0);

            var actual = _repo.EntityExists(expected.Id);

            Assert.IsFalse(actual);

            await _context.PurchaseLines.AddAsync(expected);
            await _context.SaveChangesAsync();

            actual = _repo.EntityExists(expected.Id);

            Assert.IsTrue(actual);
        }
    }
}
