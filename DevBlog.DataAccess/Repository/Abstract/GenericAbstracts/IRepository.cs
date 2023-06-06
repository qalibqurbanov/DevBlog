using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DevBlog.DataAccess.Repository.Abstract.GenericAbstracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Edit(TEntity entity, Action<EntityEntry<TEntity>> rules);
        void Remove(TEntity entity);
        void Add(TEntity entity);
    }
}