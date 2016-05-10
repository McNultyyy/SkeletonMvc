using System.ComponentModel.DataAnnotations;

namespace Model.Entities
{
    public class Entity : BaseEntity, IEntity
    {
        public virtual int Id { get; set; }

        [Timestamp]
        public virtual byte[] RowVersion { get; set; }
    }

    public class BaseEntity { }

    public interface IEntity
    {
        int Id { get; set; }
        byte[] RowVersion { get; set; }
    }
}