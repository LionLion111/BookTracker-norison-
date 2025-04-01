using System.Security.Claims;

using FastEndpoints;

namespace BookTracker.Api.Features.Publishers.Create;

public class CreatePublisherRequest
{
    [FromClaim(ClaimTypes.NameIdentifier)]
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
}