namespace BakeSale.Repositories.Common
{
    public interface IRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task UpdateAsync(T entity);
        public bool EntityExists(int id);
    }
}
