using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TerceiroSetor.Application.Gateways;
using TerceiroSetor.Domain.Entities;

namespace TerceiroSetor.Data.Repositories
{
    public abstract class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : EntidadeBase, new()
    {
        private readonly TerceiroSetorDbContext _dbContext;
        protected DbSet<TEntity> _dbSet;

        protected Repository(TerceiroSetorDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
            DatabaseTools.CheckDatabase(dbContext);
        }
        public async Task AddAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            await _dbContext.SaveChangesAsync();
        }
        public void Dispose() =>_dbContext.Dispose();
        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.AsNoTracking().ToArrayAsync();
        public async Task<TEntity> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);
        public async Task RemoveAsync(Guid id)
        {
            _dbSet.Remove(new TEntity { Id = id });
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate)
            => await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
