﻿using DevBlog.Core.Entities;
using System.Linq.Expressions;
using DevBlog.DataAccess.Repository.Abstract.GenericAbstracts;

namespace DevBlog.DataAccess.Repository.Abstract
{
    public interface IPostRepository : IRepository<Post>
    {
        IQueryable<Post> GetAll(Expression<Func<Post, bool>> expression = null);
    }
}