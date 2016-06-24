using System;
using System.Collections.Generic;
using Repository.Models.Interfaces;

namespace Repository.Models.Entities
{
    public class Blog : Entity, IBlog, IAuditable<BlogAudit>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<BlogAudit> AuditEntities { get; set; }
    }

    public interface IBlog
    {
        string Name { get; set; }
        string Description { get; set; }
    }

    public class BlogAudit : Entity, IBlog, IAudits<Blog>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int EntityId { get; set; }
        public Blog Entity { get; set; }

        public string ChangedBy { get; set; }
        public DateTime ChangeDate { get; set; }
        public string Action { get; set; }
    }
}