using DevBlog.Core.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using DevBlog.DataAccess.DatabaseContexts;
using DevBlog.DataAccess.Repository.Abstract;
using DevBlog.DataAccess.Repository.Concrete.GenericConcretes;

namespace DevBlog.DataAccess.Repository.Concrete
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly BlogDbContext _dbContext;
        public CategoryRepository(BlogDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        private DbSet<Category> TableCategories => this._dbContext.Set<Category>();

        public IQueryable<Category> GetAll(Expression<Func<Category, bool>> expression = null)
        {
            var query = this.TableCategories
                .AsNoTracking()
                .AsQueryable();

            if(expression != null)
            {
                query = query
                    .Where(expression);
            }

            return query.Include(post => post.Posts);
        }
    }
}