using DevBlog.Core.Entities;
using System.Linq.Expressions;
using DevBlog.DataAccess.Repository.Abstract.GenericAbstracts;

namespace DevBlog.DataAccess.Repository.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IQueryable<Category> GetAll(Expression<Func<Category, bool>> expression = null);
    }
}