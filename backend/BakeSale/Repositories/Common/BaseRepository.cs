using BakeSale.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace BakeSale.Repositories.Common
{
    public abstract class BaseRepository<T> : IRepository<T> where T : UniqueEntity
    {
        protected readonly BakeSaleContext _context;
        public BaseRepository(BakeSaleContext context)
        {
            _context = context;
        }
        protected abstract DbSet<T> GetDbSet();
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await GetDbSet().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            GetDbSet().Update(entity);
            await _context.SaveChangesAsync();
        }

        public bool EntityExists(int id)
        {
            return (GetDbSet()?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
