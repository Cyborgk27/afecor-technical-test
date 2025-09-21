using TT.Utilities.Static;

namespace TT.Domain.Commons
{
    public abstract class BaseEntity<TKey>
    {
        public TKey? Id { get; protected set; }
        public string AuditCreateUser { get; set; } = string.Empty;
        public DateTime AuditCreateDate { get; set; } = DateTime.UtcNow;
        public string? AuditUpdateUser { get; set; }
        public DateTime? AuditUpdateDate { get; set; }
        public string? AuditDeleteUser { get; set; }
        public DateTime? AuditDeleteDate { get; set; }
        public int State { get; set; } = (int)StateType.Active;
    }
}
