using FluentValidation;
using DevBlog.Core.Entities;
using System.Linq.Expressions;
using DevBlog.DataAccess.UnitOfWork.Abstract;
using DevBlog.BusinessLogic.Services.Abstract;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DevBlog.BusinessLogic.Services.Concrete
{
    public class PostManager : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<Post> _validator;
        public PostManager(IUnitOfWork unitOfWork, IValidator<Post> validator)
        {
            this._unitOfWork = unitOfWork;
            this._validator = validator;
        }

        public List<Post> GetAll(Expression<Func<Post, bool>> expression = null)
        {
            return _unitOfWork.Posts.GetAll(expression).ToList();
        }

        public void Add(Post entity)
        {
            var result = this._validator.Validate(entity);

            if(result.IsValid)
            {
                _unitOfWork.Posts.Add(entity);
                _unitOfWork.SaveToDB();
            }
        }

        public void Edit(Post entity, Action<EntityEntry<Post>> rules)
        {
            var result = this._validator.Validate(entity);

            if(result.IsValid)
            {
                _unitOfWork.Posts.Edit(entity, rules);
                _unitOfWork.SaveToDB();
            }
        }

        public void Remove(Post entity)
        {
            var result = this._validator.Validate(entity);

            if(result.IsValid)
            {
                _unitOfWork.Posts.Remove(entity);
            }
        }
    }
}