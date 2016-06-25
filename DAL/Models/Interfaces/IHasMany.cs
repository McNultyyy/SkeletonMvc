using System.Collections.Generic;
using DAL.Models.Entities;

namespace DAL.Models.Interfaces
{
    public interface IHasMany<TEntity> where TEntity : Entity
    {
        ICollection<TEntity> Entities { get; set; }
    }
}