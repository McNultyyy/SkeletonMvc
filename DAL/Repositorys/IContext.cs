using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Repository.Models.Entities;

namespace Repository.Repositorys
{
    public interface IContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity, IEntity;

        int SaveChanges();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}