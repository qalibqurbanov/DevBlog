using Microsoft.AspNetCore.Mvc;
using DevBlog.BusinessLogic.Services.Abstract;

namespace DevBlog.WebUI.ViewComponents
{
    /// <summary>
    /// Bu ViewComponent-in meqsedi populyar postlari DB-dan elde ederek hemin bu ViewComponent-in View-suna gondermekdir.
    /// </summary>
    public class PopularPostsViewComponent : ViewComponent
    {
        private readonly IPostService _postService;
        public PopularPostsViewComponent(IPostService postService)
        {
            this._postService = postService;
        }

		/* ViewComponent-in Entry Point-i olan hemin bu 'Invoke()' icerisinde (hemin bu ViewComponent-in View-sunda) lazimim olacaq datalari DB-dan elde ederek gonderirem 'PopularPostsViewComponent'-in View-suna: */
		public IViewComponentResult Invoke()
        {
			/* 'PopularPostsViewComponent'-in 'View'-suna populyar postlari gonderirik: */
			return View(_postService.GetPopularPosts());
        }
    }
}