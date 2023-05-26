using BakeSale.Models.Common;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BakeSale.Repositories.Common
{
    public abstract class BaseRepository<T> : IRepository<T> where T : UniqueEntity
    {
        private readonly BakeSaleContext _context;
        protected readonly DbSet<T> dbSet;
        public BaseRepository(BakeSaleContext context)
        {
            _context = context;
            dbSet = GetDbSet(context);
        }
        protected abstract DbSet<T> GetDbSet(BakeSaleContext context);
        protected async Task SaveChangesAsync() => await _context.SaveChangesAsync();
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }
        public virtual async Task<T?> GetAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }
        public async Task PostAsync(T newEntity)
        {
            dbSet.Add(newEntity);

            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            await DeleteAsync(entity.Id);

            dbSet.Add(entity);

            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id) ?? throw new DataException();

            dbSet.Remove(entity);

            await _context.SaveChangesAsync();
        }
        public bool EntityExists(int id)
        {
            return (dbSet?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
