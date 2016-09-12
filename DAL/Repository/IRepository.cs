using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Models.Entities;

namespace DAL.Repository
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity Get(int id);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetAsync(int id);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        void Update(TEntity entity);


        void Remove(TEntity entity);

    }
}