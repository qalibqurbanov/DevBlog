using FluentValidation;
using System.Reflection;
using DevBlog.Core.Entities;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using DevBlog.BusinessLogic.Validators;
using DevBlog.DataAccess.DatabaseContexts;
using DevBlog.DataAccess.Repository.Abstract;
using DevBlog.DataAccess.Repository.Concrete;
using DevBlog.DataAccess.UnitOfWork.Abstract;
using DevBlog.DataAccess.UnitOfWork.Concrete;
using DevBlog.BusinessLogic.Services.Abstract;
using DevBlog.BusinessLogic.Services.Concrete;

namespace DevBlog.WebUI.Extensions.Configurations
{
    /// <summary>
    /// ASP Core-un built-in/default servislerini ve menim custom servislerimi IoC Containera yerlewdirme emeliyyatlarini saxlayan sinifdir.
    /// </summary>
    public static class RegisterServices
    {
        public static void AddDefaultServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<BlogDbContext>(options => { options.UseSqlServer(configuration.GetConnectionString("BlogConnectionString1")); });

            serviceCollection.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });

            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly()); /* Hazirki assembly icerisinde reflection komeyile 'Profile'-den miras alan profil siniflerimi tapacaq */

            serviceCollection.AddControllersWithViews()
                .AddRazorRuntimeCompilation()
                .AddFluentValidation(options =>
                {
                    options.RegisterValidatorsFromAssemblyContaining<PostValidator>();
                });
        }

        public static void AddCustomServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IValidator<Post>, PostValidator>();
            serviceCollection.AddScoped<IValidator<Category>, CategoryValidator>();

            serviceCollection.AddScoped<IPostRepository, PostRepository>();
            serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();

            serviceCollection.AddScoped<IPostService, PostManager>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}