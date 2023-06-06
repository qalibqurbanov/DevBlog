using AutoMapper;
using DevBlog.Core.Entities;
using DevBlog.WebUI.Models.ViewModels;

namespace DevBlog.WebUI.Mappings
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostViewModel>()
                .ForMember(postVM => postVM.Author,               member2 => member2.MapFrom(post => post.Author))
                .ForMember(postVM => postVM.Content,              member2 => member2.MapFrom(post => post.Content))
                .ForMember(postVM => postVM.PostTumbnailImageUrl, member2 => member2.MapFrom(post => post.PostTumbnailImageUrl))
                .ForMember(postVM => postVM.PostUrl,              member2 => member2.MapFrom(post => post.PostUrl))
                .ForMember(postVM => postVM.PublishedDate,        member2 => member2.MapFrom(post => post.PublishedDate))
                .ForMember(postVM => postVM.ShortDescription,     member2 => member2.MapFrom(post => post.ShortDescription))
                .ForMember(postVM => postVM.Title,                member2 => member2.MapFrom(post => post.Title))
                .ReverseMap();
        }
    }
}