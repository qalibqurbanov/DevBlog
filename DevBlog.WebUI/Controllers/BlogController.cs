using AutoMapper;
using DevBlog.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using DevBlog.WebUI.Models.ViewModels;
using DevBlog.WebUI.Models.Pagination;
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
        public IActionResult PostsList([FromQuery] int page = 1)
        {
            const int PostCountPerPage = 3;

            PostListViewModel postListVM = new PostListViewModel()
            {
                Posts = _postService.GetPostsByCategoryName(page, PostCountPerPage, null),
                PageInformation = new PageInformation()
                {
                    TotalPosts = _postService.GetPostCount(),
                    CurrentPage = page,
                    PostsPerPage = PostCountPerPage,
                    CurrentCategoryName = null
                }
            };

            return View(postListVM);
        }

        [HttpGet]
        public IActionResult PostsListByCategory([FromRoute] string categoryName, [FromQuery] int page = 1)
        {
            const int PostCountPerPage = 3;

            List<Post> posts = _postService.GetPostsByCategoryName(page, PostCountPerPage, categoryName);

            PostListViewModel postListVM = new PostListViewModel()
            {
                Posts = posts,
                PageInformation = new PageInformation()
                {
                    TotalPosts = posts.Count,
                    CurrentPage = page,
                    PostsPerPage = PostCountPerPage,
                    CurrentCategoryName = categoryName
                }
            };

            TempData["CategoryName"] = categoryName;

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