namespace BookTracker.Api.Features;

public class AuditDto
{
    public DateTime CreatedDateTime { get; set; }
    public DateTime ModifiedDateTime { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid ModifiedBy { get; set; }
}