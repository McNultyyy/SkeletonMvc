using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models.Entities;

namespace BLL.Services
{
    public interface IEntityService<TEntity>
        where TEntity : Entity
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