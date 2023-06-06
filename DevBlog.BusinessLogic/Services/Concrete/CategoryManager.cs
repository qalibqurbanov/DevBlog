using FluentValidation;
using DevBlog.Core.Entities;
using System.Linq.Expressions;
using DevBlog.DataAccess.UnitOfWork.Abstract;
using DevBlog.BusinessLogic.Services.Abstract;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DevBlog.BusinessLogic.Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<Category> _validator;
        public CategoryManager(IUnitOfWork unitOfWork, IValidator<Category> validator)
        {
            this._unitOfWork = unitOfWork;
            this._validator = validator;
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> expression = null)
        {
            return _unitOfWork.Categories.GetAll(expression).ToList();
        }

        public void Add(Category entity)
        {
            var result = this._validator.Validate(entity);

            if(result.IsValid)
            {
                _unitOfWork.Categories.Add(entity);
                _unitOfWork.SaveToDB();
            }
        }

        public void Edit(Category entity, Action<EntityEntry<Category>> rules)
        {
            var result = this._validator.Validate(entity);

            if(result.IsValid)
            {
                _unitOfWork.Categories.Edit(entity, rules);
                _unitOfWork.SaveToDB();
            }
        }

        public void Remove(Category entity)
        {
            var result = this._validator.Validate(entity);

            if(result.IsValid)
            {
                _unitOfWork.Categories.Remove(entity);
            }
        }
    }
}