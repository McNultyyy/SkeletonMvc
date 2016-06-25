using System.Collections.Generic;
using DAL.Models.Entities;

namespace DAL.Models.Interfaces
{
    public interface IAuditable<TEntity> where TEntity : Entity
    {


        ICollection<TEntity> AuditEntities { get; set; }
    }
}