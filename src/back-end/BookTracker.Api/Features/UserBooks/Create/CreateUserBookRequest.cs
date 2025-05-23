using System.Security.Claims;
using BookTracker.Api.Data.Enums;

using FastEndpoints;

namespace BookTracker.Api.Features.UserBooks.Create;

public class CreateUserBookRequest
{
    [FromClaim(ClaimTypes.NameIdentifier)]
    public Guid UserId { get; set; }

    public UserBookStatus Status { get; set; }
    public UserBookMood Mood { get; set; }
    public int PageRead { get; set; }
    public Guid BookId { get; set; }
    public List<Guid>? UserBookTrackersIds { get; set; } = new();
}
