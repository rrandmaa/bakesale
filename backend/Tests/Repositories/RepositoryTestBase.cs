using BakeSale.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace Tests.Repositories
{
    public abstract class RepositoryTestBase
    {
        private static DbContextOptions<BakeSaleContext> options = new DbContextOptionsBuilder<BakeSaleContext>()
            .UseInMemoryDatabase("BakeSaleTests")
            .Options;

        protected BakeSaleContext _context;
        public RepositoryTestBase()
        {
            _context = new BakeSaleContext(options);
        }

        [TestInitialize] 
        public void Initialize()
        {
            _context.Database.EnsureCreated();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
        }
    }
}
