using System.Collections.Generic;

namespace Model.Entities
{
    public class Blog: Entity
    {
        public Blog()
        {
            Posts = new List<Post>();
        }

        public override int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public virtual IList<Post> Posts { get; set; }
    }
}