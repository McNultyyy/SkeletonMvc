using System;

namespace Core.Entities
{
    public class AuditData : IEntity, IAuditData
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
        public bool IsDeleted { get; set; }
        public string Action { get; set; }
        public DateTime ChangeDate { get; set; }
        public string DataModel { get; set; }
        public string Changes { get; set; }
        public string ValueBefore { get; set; }
        public string ValueAfter { get; set; }
    }

    public interface IAuditData
    {
        string Action { get; set; }

        DateTime ChangeDate { get; set; }

        string DataModel { get; set; }

        string Changes { get; set; }

        string ValueBefore { get; set; }

        string ValueAfter { get; set; }
    }
}