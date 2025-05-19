using FastEndpoints;
using System.Security.Claims;

namespace BookTracker.Api.Features.Authors.Create;

public class CreateAuthorRequest
{
    [FromClaim(ClaimTypes.NameIdentifier)]
    public Guid UserId { get; set; }

    public string Name { get; set; } = string.Empty;
    public List<Guid> BookIds { get; set; } = new();
}
