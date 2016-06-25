using System;
using DAL.Models.Entities;

namespace DAL.Models.Interfaces
{
    public interface IAudits<TEntity> where TEntity : Entity
    {
        int EntityId { get; set; }
        TEntity Entity { get; set; }

        string ChangedBy { get; set; }
        DateTime ChangeDate { get; set; }
        string Action { get; set; }
    }
}