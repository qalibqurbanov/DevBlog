using Microsoft.AspNetCore.Mvc;
using DevBlog.BusinessLogic.Services.Abstract;

namespace DevBlog.WebUI.ViewComponents
{
    /// <summary>
    /// Bu ViewComponent-in meqsedi kateqoriyalari DB-dan elde ederek hemin bu ViewComponent-in View-suna gondermekdir.
    /// </summary>
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public CategoriesViewComponent(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        /* ViewComponent-in Entry Point-i olan hemin bu 'Invoke()' icerisinde (hemin bu ViewComponent-in View-sunda) lazimim olacaq datalari DB-dan elde ederek gonderirem 'CategoriesViewComponent'-in View-suna: */
        public IViewComponentResult Invoke()
        {
            /* 'CategoriesViewComponent'-nin 'View'-suna kateqoriyalari gonderirik: */
            return View(_categoryService.GetAll());
        }
    }
}