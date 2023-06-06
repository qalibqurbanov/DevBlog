using DevBlog.DataAccess;
using DevBlog.WebUI.Extensions.Configurations;

namespace DevBlog.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDefaultServices(builder.Configuration);
            builder.Services.AddCustomServices(builder.Configuration);

            var app = builder.Build();

            app.AddDefaultConfiguration(builder.Environment);

            if(builder.Environment.IsDevelopment())
                app.SeedDummyDatasToDB();
            //else
            //    app.SeedIdentityDatasToDB(builder.Configuration).Wait();

            app.Run();
        }
    }
}