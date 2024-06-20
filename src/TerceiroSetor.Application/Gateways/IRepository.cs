using System.Linq.Expressions;
using TerceiroSetor.Domain.Entities;

namespace TerceiroSetor.Application.Gateways
{
    public interface IRepository<TEntity> : IDisposable where TEntity : EntidadeBase
    {
        Task AddAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(Guid id);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(Guid id);
        Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
