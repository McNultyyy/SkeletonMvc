using System.ComponentModel.DataAnnotations;

namespace Model.Entities
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
}