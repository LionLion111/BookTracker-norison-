using System.Security.Claims;

using BookTracker.Application.Services.Abstractions;

namespace BookTracker.Api.Services.Implementations;

public class CurrentUserService(IHttpContextAccessor accessor) : ICurrentUserService
{
    public bool HasUser => accessor.HttpContext?.User != null;
    public bool IsAuthenticated => accessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;

    public Guid UserId => IsAuthenticated
        ? Guid.Parse(accessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!)
        : Guid.Empty;
}