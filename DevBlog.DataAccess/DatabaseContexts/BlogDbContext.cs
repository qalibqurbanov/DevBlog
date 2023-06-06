using System.Reflection;
using DevBlog.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevBlog.DataAccess.DatabaseContexts
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {

        }

        public DbSet<Post>     Posts      { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<PostTag>      PostTags       { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("DevBlog.BusinessLogic"));
        }
    }
}