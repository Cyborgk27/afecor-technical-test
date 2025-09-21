using TT.Domain.Commons;

namespace TT.Infrastructure.Persistences.Interfaces
{
    public interface IGenericRepository<T, TKey> where T : BaseEntity<TKey>
    {
        public Task<T[]> GetAllAsync();
        public Task<T?> GetByIdAsync(TKey id);
        public Task<T> AddAsync(T entity);
        public Task<T> UpdateAsync(T entity);
        public Task<bool> DeleteAsync(TKey id);
        public Task<bool> ExistsAsync(TKey id);
    }
}
