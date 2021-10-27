using System.Threading.Tasks;
using Typiqally.Persistence.Abstractions.Entities;

namespace Typiqally.Persistence.Abstractions.Repositories
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>
        where TEntity : class, IEntity
    {
        TEntity Create(TEntity entity);
        Task<TEntity> CreateAsync(TEntity entity);
        void Update(TEntity entity);
        Task DeleteAsync(object id);
        void Delete(object id);
        void Delete(TEntity entity);
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}