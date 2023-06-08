using DevBlog.Core.Entities;
using DevBlog.WebUI.Models.Pagination;

namespace DevBlog.WebUI.Models.ViewModels
{
    public class PostListViewModel
    {
        public List<Post>      Posts           { get; set; }
        public PageInformation PageInformation { get; set; }
    }
}