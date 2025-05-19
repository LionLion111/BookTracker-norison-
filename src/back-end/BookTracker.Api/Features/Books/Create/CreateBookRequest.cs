using BookTracker.Api.Data.Enums;

using FastEndpoints;
using System.Security.Claims;

namespace BookTracker.Api.Features.Books.Create;

public class CreateBookRequest
{
    [FromClaim(ClaimTypes.NameIdentifier)]
    public Guid UserId { get; set; }

    public string Isbn { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int PublishedYear { get; set; }
    public int PageCount { get; set; }
    public Language Language { get; set; }
    public Genre Genre { get; set; }

    public Guid PublisherId { get; set; }
    public List<Guid> AuthorIds { get; set; } = new();
}
