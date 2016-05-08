using Model.Entities;

namespace Repository
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Model;

    public interface IContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity, IEntity;

        int SaveChanges();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

    }
}