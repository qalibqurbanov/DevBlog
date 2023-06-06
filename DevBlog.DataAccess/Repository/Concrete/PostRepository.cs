using DevBlog.Core.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using DevBlog.DataAccess.DatabaseContexts;
using DevBlog.DataAccess.Repository.Abstract;
using DevBlog.DataAccess.Repository.Concrete.GenericConcretes;

namespace DevBlog.DataAccess.Repository.Concrete
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private readonly BlogDbContext _dbContext;
        public PostRepository(BlogDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        private DbSet<Post> TablePosts => this._dbContext.Set<Post>();

        public IQueryable<Post> GetAll(Expression<Func<Post, bool>> expression = null)
        {
            var query = this.TablePosts
                .AsNoTracking()
                .AsQueryable();

            if(expression != null)
            {
                query = query
                    .Where(expression);
            }

            return query.Include(post => post.Category);
        }
    }
}