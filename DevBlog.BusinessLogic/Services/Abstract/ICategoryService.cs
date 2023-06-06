using DevBlog.Core.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DevBlog.BusinessLogic.Services.Abstract
{
    public interface ICategoryService
    {
        /* IRepository: */
        void Edit(Category entity, Action<EntityEntry<Category>> rules);
        void Remove(Category entity);
        void Add(Category entity);

        /* ICategoryService: */
        List<Category> GetAll(Expression<Func<Category, bool>> expression = null);
    }
}