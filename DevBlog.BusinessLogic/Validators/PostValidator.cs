using FluentValidation;
using DevBlog.Core.Entities;

namespace DevBlog.BusinessLogic.Validators
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(prop => prop.Title).NotEmpty();
            RuleFor(prop => prop.ShortDescription).NotEmpty();
            RuleFor(prop => prop.PublishedDate).NotEmpty();
            RuleFor(prop => prop.Content).NotEmpty();
            RuleFor(prop => prop.Author).MaximumLength(20).NotEmpty();
            RuleFor(prop => prop.PostTumbnailImageUrl).NotEmpty();
            RuleFor(prop => prop.PostUrl).NotEmpty();
        }
    }
}