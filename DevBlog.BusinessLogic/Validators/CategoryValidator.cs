using FluentValidation;
using DevBlog.Core.Entities;

namespace DevBlog.BusinessLogic.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(prop => prop.Name).MaximumLength(20).NotEmpty();
        }
    }
}