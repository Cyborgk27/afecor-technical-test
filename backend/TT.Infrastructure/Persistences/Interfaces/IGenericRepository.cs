using System.Linq.Expressions;
using TT.Domain.Commons;

namespace TT.Infrastructure.Persistences.Interfaces
{
    public interface IGenericRepository<T, TKey> where T : BaseEntity<TKey>
    {
        Task<T[]> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<T?> GetByIdAsync(TKey id, params Expression<Func<T, object>>[] includes);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(TKey id);
        Task<bool> ExistsAsync(TKey id);
    }
}
