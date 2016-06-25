namespace DAL.Models.Entities
{
    public class Blog : Entity, IBlog
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public interface IBlog
    {
        string Name { get; set; }
        string Description { get; set; }
    }
}