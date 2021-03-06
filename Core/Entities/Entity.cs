using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    /// <summary>
    /// The base implementation of an entity.
    /// </summary>
    /// <seealso cref="BaseEntity" />
    /// <seealso cref="IEntity" />
    public class Entity : BaseEntity, IEntity
    {
        /// <inheritdoc />
        public virtual int Id { get; set; }

        /// <inheritdoc />
        [Timestamp]
        public virtual byte[] RowVersion { get; set; }

        /// <inheritdoc/>
        public virtual bool IsDeleted { get; set; }
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

        bool IsDeleted { get; set; }
    }
}