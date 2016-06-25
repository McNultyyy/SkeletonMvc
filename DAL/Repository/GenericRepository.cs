using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Models.Entities;

namespace DAL.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        private readonly IDbSet<TEntity> _dbSet;
        private readonly IContext _dbContext;

        public GenericRepository(IContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = _dbSet.Where(predicate).AsEnumerable();
            return entity;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            var entities = _dbSet.AsEnumerable();
            return entities;
        }

        public virtual TEntity GetById(int id)
        {
            var entity = _dbSet.Find(id);
            return entity;
        }

        public virtual void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }

}
