using Microsoft.EntityFrameworkCore;
using NetGroupInventory.Application.Interfaces.Repositories;

namespace NetGroupInventory.Persistent.Repositories
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        protected InventoryDbContext dbContext;
        protected DbSet<T> dbSet;

        public Repository(InventoryDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = this.dbContext.Set<T>();
        }

        public T Create(T entity)
        {
            dbContext.Add(entity);
            return entity;
        }

        public async virtual Task<bool> Delete(object id)
        {
            T entity = await dbSet.FindAsync(id);
            if (entity == null)
                return false;

            dbSet.Remove(entity);

            return true;
        }

        public async virtual Task<IList<T>> GetAll()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public async virtual Task<T> GetById(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public T Update(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
