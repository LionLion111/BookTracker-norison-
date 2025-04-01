namespace BookTracker.Api.Data.Entities;

public class UserBookTracker : AuditEntity
{
    public Guid Id { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime? EndDateTime { get; set; }

    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
    public UserBook? UserBook { get; set; }
}