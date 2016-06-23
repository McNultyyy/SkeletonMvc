using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Model;
using Model.Entities;

namespace Repository
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}