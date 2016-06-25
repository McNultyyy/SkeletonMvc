using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DAL.Models.Entities;

namespace DAL.Repository
{
    public interface IContext : IDisposable
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity, IEntity;

        int SaveChanges();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}