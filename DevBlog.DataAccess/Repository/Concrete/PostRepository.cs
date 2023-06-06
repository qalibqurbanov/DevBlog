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

        public int GetPostCount()
        {
            return TablePosts.AsNoTracking().Count();
        }

        public IQueryable<Post> GetPopularPosts()
        {
            if(GetPostCount() >= 3)
                return TablePosts.OrderBy(post => post.Content).Include(post => post.Category).Take(3);
            else
                return GetAll();
        }

        public IQueryable<Post> SearchPostsByKeyword(string SearchKeyword)
        {
            var posts = TablePosts
                .AsNoTracking()
                .Where(post => post.Title.ToLower().Contains(SearchKeyword.ToLower()) || post.Content.ToLower().Contains(SearchKeyword.ToLower()) || post.ShortDescription.ToLower().Contains(SearchKeyword.ToLower()))
                .Include(post => post.Category);

            return posts;
        }
    }
}