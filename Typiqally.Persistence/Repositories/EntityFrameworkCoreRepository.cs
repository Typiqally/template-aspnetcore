using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Typiqally.Persistence.Abstractions.Entities;
using Typiqally.Persistence.Abstractions.Repositories;

namespace Typiqally.Persistence.Repositories
{
    public class EntityFrameworkCoreRepository<TEntity, TContext> : EntityFrameworkCoreReadOnlyRepository<TEntity, TContext>, IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        public EntityFrameworkCoreRepository(TContext context) : base(context)
        {
        }

        public TEntity Create(TEntity entity)
        {
            var created = Context.Set<TEntity>().Add(entity);
            return created.Entity;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var created = await Context.Set<TEntity>().AddAsync(entity);
            return created.Entity;
        }

        public void Update(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;

            if (entity is IModificationDateTime time)
            {
                Context.Entry(time).Property(x => x.CreatedAt).IsModified = false;
            }
        }
        
        public async Task DeleteAsync(object id)
        {
            var entity = await FindAsync(id);
            Delete(entity);
        }
        
        public void Delete(object id)
        {
            var entity = Find(id);
            Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}