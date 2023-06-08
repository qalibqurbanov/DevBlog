using DevBlog.Core.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DevBlog.BusinessLogic.Services.Abstract
{
    public interface IPostService
    {
        /* IRepository: */
        void Edit(Post entity, Action<EntityEntry<Post>> rules);
        void Remove(Post entity);
        void Add(Post entity);

        /* IPostRepository: */
        List<Post> GetAll(Expression<Func<Post, bool>> expression = null);
        int GetPostCount();
        List<Post> GetPopularPosts();
        List<Post> SearchPostsByKeyword(string SearchKeyword);
		List<Post> GetPostsByCategoryName(int Page, int PostCountPerPage, string CategoryName = null);
    }
}