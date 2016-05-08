using System.Collections.Generic;

namespace Model.Entities
{
    public class Blog : Entity
    {
        public override int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

    }
}