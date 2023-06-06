using DevBlog.Core.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DevBlog.BusinessLogic.Services.Abstract
{
    public interface IPostService
    {
        /* IRepository: */
        List<Post> GetAll(Expression<Func<Post, bool>> expression = null);
        void Edit(Post entity, Action<EntityEntry<Post>> rules);
        void Remove(Post entity);
        void Add(Post entity);
    }
}