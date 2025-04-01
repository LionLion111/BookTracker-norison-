namespace BookTracker.Api.Data.Entities;

public abstract class AuditEntity
{
    public DateTime CreatedDateTime { get; set; }
    public DateTime ModifiedDateTime { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid ModifiedBy { get; set; }
}