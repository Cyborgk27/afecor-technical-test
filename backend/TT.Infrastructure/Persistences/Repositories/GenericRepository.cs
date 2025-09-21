using Microsoft.EntityFrameworkCore;
using TT.Domain.Commons;
using TT.Infrastructure.Persistences.Contexts;
using TT.Infrastructure.Persistences.Interfaces;
using TT.Utilities.Static;

namespace TT.Infrastructure.Persistences.Repositories
{
    public class GenericRepository<T, TKey> : IGenericRepository<T, TKey>
        where T : BaseEntity<TKey>
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T[]> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToArrayAsync();
        }

        public async Task<T?> GetByIdAsync(TKey id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(TKey id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return false;

            entity.State = (int)StateType.Inactive;
            entity.AuditDeleteDate = DateTime.UtcNow;
            entity.AuditDeleteUser = "system";

            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ExistsAsync(TKey id)
        {
            return await _dbSet.AnyAsync(e => e.Id!.Equals(id));
        }
    }
}
