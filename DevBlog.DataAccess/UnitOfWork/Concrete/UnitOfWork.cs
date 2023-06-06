using DevBlog.DataAccess.DatabaseContexts;
using DevBlog.DataAccess.Repository.Abstract;
using DevBlog.DataAccess.UnitOfWork.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace DevBlog.DataAccess.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        /* IoC Container-dan obyekt orneyi teleb edecem deye lazimdir: */
        private readonly IServiceProvider _serviceProvider;

        /* Uzerinde iwleyeceyimiz Database: */
        private readonly BlogDbContext _dbContext;

        public UnitOfWork(BlogDbContext dbContext, IServiceProvider serviceProvider)
        {
            this._dbContext = dbContext;
            this._serviceProvider = serviceProvider;
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }

        public void SaveToDB()
        {
            this._dbContext.SaveChanges();
        }

        /* = - + - + - + - + - + - + - + - + - + - + - + - + - + - + - + - + - + - + - + - + - + - + - + - + - + - + - + = */

        /* Awagida 'lazy loading' tetbiq edirem, yeni lazim oldu-olmadi Repository-ler HEAP-de yer ayrilmayacaq (eger Concrete Repositoryleri 'UnitOfWork' konstruktorunda initializasiya etseydim, her 'UnitOfWork'-un obyekt yaradiliwinda lazim oldu-olmadi her bir Repository ucun de bir obyekt yaradilacaq idi). Awagidaki public getter propertyler sayesinde yalniz lazim olan Repositoryleri initialize edirik, meselen: yalniz 'Posts' cagirilanda yeni bir 'PostRepository' orneyi IoC Containerdan elde olunaraq verilecek 'Posts'-a ve elecede her bir diger repo, yalniz uygun public property cagirilanda initialize edilecek Repositorymiz: */

        /// <summary>
        /// IoC Containerdan teleb olunan(T) tipde bir obyekt elde edir.
        /// </summary>
        /// <typeparam name="T">IoC Containerdan ne tipli obyekt teleb edirik.</typeparam>
        /// <param name="member">IoC Containerdan elde olunmuw obyekt hara set olunsun ve ya bawqa sozle hara verilsin.</param>
        /// <returns>Geriye, IoC Containerdan elde etdiyi obyekti dondurur.</returns>
        private T InitializeService<T>(T member) => member ??= _serviceProvider.GetService<T>(); /* 'member' nulldursa, IoC-den 'T' orneyi elde ederek menimset 'member'-a ve geri dondur, eks halda 'member' geri dondurulsun */

        private readonly IPostRepository     _Posts;
        private readonly ICategoryRepository _Categories;

        public IPostRepository     Posts      { get { return InitializeService(_Posts);      } }
        public ICategoryRepository Categories { get { return InitializeService(_Categories); } }
    }
}