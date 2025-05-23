namespace BookTracker.Api.Features.UserBookTrackers.Create;

public class CreateUserBookTrackerResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
}
