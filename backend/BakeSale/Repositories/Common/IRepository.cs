using BakeSale.Models.Common;

namespace BakeSale.Repositories.Common
{
    public interface IRepository<T> where T : UniqueEntity
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T?> GetAsync(int id);
        public Task PostAsync(T newEntity);
        public Task UpdateAsync(T entity);
        public bool EntityExists(int id);
    }
}
