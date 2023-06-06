using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using DevBlog.DataAccess.Repository.Abstract.GenericAbstracts;

namespace DevBlog.DataAccess.Repository.Concrete.GenericConcretes
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;
        public Repository(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        private DbSet<TEntity> dbTable => _dbContext.Set<TEntity>();

        public void Add(TEntity entity)
        {
            this.dbTable.Add(entity);
        }

        public void Edit(TEntity entity, Action<EntityEntry<TEntity>> rules)
        {
            if(entity == null)
            {
                throw new ArgumentNullException();
            }

            var entry = this.dbTable.Entry(entity);

            if(rules != null)
            {
                foreach(var item in typeof(TEntity).GetProperties().Where(prop => prop.CanWrite))
                {
                    entry.Property(item.Name).IsModified = false;
                }

                rules(entry);
            }

            entry.State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            this.dbTable.Remove(entity);
        }
    }
}