using DevBlog.DataAccess.Repository.Abstract;

namespace DevBlog.DataAccess.UnitOfWork.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository Posts { get; }
        ICategoryRepository Categories { get; }

        public void SaveToDB();
    }
}