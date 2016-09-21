using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace BLL.Services
{
    public interface IEntityService<TEntity>
        where TEntity : IEntity
    {
        void Create(TEntity entity);
        Task CreateAsync(TEntity entity);

        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);

        void Delete(TEntity entity);
        Task DeleteAsync(TEntity entity);

        TEntity Get(int id);
        Task<TEntity> GetAsync(int id);

        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}