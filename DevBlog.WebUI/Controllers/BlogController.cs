using AutoMapper;
using DevBlog.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using DevBlog.WebUI.Models.ViewModels;
using DevBlog.BusinessLogic.Services.Abstract;

namespace DevBlog.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        public BlogController(IPostService postService, IMapper mapper)
        {
            this._postService = postService;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult PostsList()
        {
            PostListViewModel postListVM = new PostListViewModel()
            {
                Posts = _postService.GetAll()
            };

            return View(postListVM);
        }

        [HttpGet]
        public IActionResult PostsListByCategory([FromRoute] string categoryName)
        {
            PostListViewModel postListVM;

            if(!string.IsNullOrEmpty(categoryName))
            {
                postListVM = new PostListViewModel()
                {
                    Posts = _postService.GetAll(post => post.Category.Name == categoryName)
                };

                TempData["CategoryName"] = categoryName;
            }
            else
            {
                postListVM = new PostListViewModel()
                {
                    Posts = _postService.GetAll()
                };
            }

            return View(nameof(PostsList), postListVM);
        }

        [HttpGet]
        public IActionResult PostDetails([FromRoute] string postUrl)
        {
            if(string.IsNullOrEmpty(postUrl)) return NotFound();

            Post? post = _postService.GetAll(post => post.PostUrl == postUrl).FirstOrDefault();

            if(post != null)
            {
                PostViewModel postVM = _mapper.Map<PostViewModel>(post);

                return View(postVM);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult SearchResult([FromQuery] string q) /* '_search' partialinda bu 'q' parametrini yerlewdirmiwdik Query Stringe. Burada 'SearchResult()' actioninda hemin 'q'-nin datasini(?q=...) yaxalayiriq */
		{
            PostListViewModel postListVM = new PostListViewModel()
            {
                Posts = _postService.SearchPostsByKeyword(q)
            };

            return View(postListVM);
        }
    }
}