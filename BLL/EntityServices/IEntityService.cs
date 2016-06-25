using System.Collections.Generic;
using DAL.Models.Entities;

namespace BLL.EntityServices
{
    public interface IEntityService<TEntity>
        where TEntity : Entity
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}