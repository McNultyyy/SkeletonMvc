namespace Model
{
    public class Entity : BaseEntity, IEntity
    {
        public virtual int Id { get; set; }
    }

    public class BaseEntity { }

    public interface IEntity
    {
        int Id { get; set; }
    }

}