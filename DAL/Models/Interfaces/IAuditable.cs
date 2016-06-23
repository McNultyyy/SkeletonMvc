using System.Collections.Generic;
using Repository.Models.Entities;

namespace Repository.Models.Interfaces
{
    public interface IAuditable<TEntity> where TEntity : Entity
    {


        ICollection<TEntity> AuditEntities { get; set; }
    }
}