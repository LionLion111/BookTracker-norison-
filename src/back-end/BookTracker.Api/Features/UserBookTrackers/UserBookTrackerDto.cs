namespace BookTracker.Api.Features.UserBookTrackers;

public class UserBookTrackerDto : AuditDto
{
    public Guid Id { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime? EndDateTime { get; set; }

    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
}
