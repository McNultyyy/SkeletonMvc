using System.Collections.Generic;
using Repository.Models.Entities;

namespace Repository.Models.Interfaces
{
    public interface IHasMany<TEntity> where TEntity : Entity
    {
        ICollection<TEntity> Entities { get; set; }
    }
}