namespace DevBlog.WebUI.Extensions.Configurations
{
    public static class SetupMiddleware
    {
        /// <summary>
        /// Bu metod cagirilanda Middleware-lari aktivlewdirir.
        /// </summary>
        public static void AddDefaultConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                #region Pages: About, Contact
                endpoints.MapControllerRoute
                (
                    name: "AboutPage",
                    pattern: "about",
                    defaults: new { controller = "Home", action = "About" }
                );

                endpoints.MapControllerRoute
                (
                    name: "ContactPage",
                    pattern: "contact",
                    defaults: new { controller = "Home", action = "Contact" }
                );
                #endregion Pages: About, Contact

                #region Page: Post
                endpoints.MapControllerRoute
                (
                    name: "Search",
                    pattern: "search",
                    defaults: new { controller = "Blog", action = "SearchResult" }
                );

                endpoints.MapControllerRoute
                (
                    name: "PostsListByCategoryPage",
                    pattern: "posts/category/{categoryName}",
                    defaults: new { controller = "Blog", action = "PostsListByCategory" }
                );

                endpoints.MapControllerRoute
                (
                    name: "PostDetailsPage",
                    pattern: "post/{postUrl}",
                    defaults: new { controller = "Blog", action = "PostDetails" }
                );

                endpoints.MapControllerRoute
                (
                    name: "PostsListPage",
                    pattern: "posts",
                    defaults: new { controller = "Blog", action = "PostsList" }
                );
                #endregion Page: Post

                #region Page: Default
                endpoints.MapControllerRoute
                (
                    name: "default",
                    pattern: "{controller=Blog}/{action=PostsList}"
                );
                #endregion Page: Default
            });
        }
    }
}