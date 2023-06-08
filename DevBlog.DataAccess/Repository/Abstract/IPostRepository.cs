using DevBlog.Core.Entities;
using System.Linq.Expressions;
using DevBlog.DataAccess.Repository.Abstract.GenericAbstracts;

namespace DevBlog.DataAccess.Repository.Abstract
{
    public interface IPostRepository : IRepository<Post>
    {
        IQueryable<Post> GetAll(Expression<Func<Post, bool>> expression = null);
        int GetPostCount();
        IQueryable<Post> GetPopularPosts();
        IQueryable<Post> SearchPostsByKeyword(string SearchKeyword);
        IQueryable<Post> GetPostsByCategoryName(int Page, int PostCountPerPage, string CategoryName = null);
    }
}