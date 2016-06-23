using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repository.Model.Entities
{
    /// <summary>
    /// The base implementation of an entity.
    /// </summary>
    /// <seealso cref="Model.Entities.BaseEntity" />
    /// <seealso cref="Model.Entities.IEntity" />
    public class Entity : BaseEntity, IEntity
    {
        /// <inheritdoc />
        public virtual int Id { get; set; }

        /// <inheritdoc />
        [Timestamp]
        public virtual byte[] RowVersion { get; set; }
    }

    /// <summary>
    /// Base Entity.
    /// </summary>
    public class BaseEntity { }

    /// <summary>
    /// Entity mandatory properties.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the row version.
        /// </summary>
        /// <value>
        /// The row version.
        /// </value>
        byte[] RowVersion { get; set; }
    }

    public interface IPerson
    {
        string Name { get; set; }
    }
    public class Person : Entity, IPerson, IAuditable<PersonAudit>
    {
        public string Name { get; set; }

        public ICollection<PersonAudit> AuditEntities { get; set; }
    }



    public class PersonAudit : Person, IAuditEntity
    {
        public int EntityId { get; set; }
        public Person Entity { get; set; }

        public string ChangedBy { get; set; }
        public DateTime ChangeDate { get; set; }
        public string Action { get; set; }
    }


    public interface IAuditable<T> where T : Entity
    {
        ICollection<T> AuditEntities { get; set; }
    }

    public interface IAuditEntity
    {
        string ChangedBy { get; set; }
        DateTime ChangeDate { get; set; }
        string Action { get; set; }
    }
}