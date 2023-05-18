using BakeSale.Models;
using BakeSale.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace BakeSale.Repositories
{
    public class PurchasesRepository: IPurchasesRepository
    {
        private readonly BakeSaleContext _context;

        public PurchasesRepository(BakeSaleContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Purchase>> GetAllAsync()
        {
            return await _context.Purchases.ToListAsync();
        }

        public async Task UpdateAsync(Purchase entity)
        {
            _context.Purchases.Update(entity); 
            await _context.SaveChangesAsync();
        }

        public bool EntityExists(int id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
