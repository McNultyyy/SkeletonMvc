using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Repository.Model.Entities;

namespace Repository.Repository
{
    public interface IContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity, IEntity;

        int SaveChanges();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

    }
}