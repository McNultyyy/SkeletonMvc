using System.Collections.Generic;

namespace DAL.Audit
{
    public class AuditChange
    {
        public string DateTimeStamp { get; set; }
        public string AuditActionType { get; set; }
        public string AuditActionTypeName { get; set; }
        public IEnumerable<AuditDelta> Changes { get; set; }
        public AuditChange()
        {
            Changes = new List<AuditDelta>();
        }
    }
}