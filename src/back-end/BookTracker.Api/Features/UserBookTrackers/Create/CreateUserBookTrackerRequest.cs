using FastEndpoints;
using System.Security.Claims;

namespace BookTracker.Api.Features.UserBookTrackers.Create;

public class CreateUserBookTrackerRequest
{
    [FromClaim(ClaimTypes.NameIdentifier)]
    public Guid Id { get; set; }

    public DateTime StartDateTime { get; set; }
    public DateTime? EndDateTime { get; set; }

    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
}
