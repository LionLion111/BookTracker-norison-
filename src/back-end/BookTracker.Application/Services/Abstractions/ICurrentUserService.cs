namespace BookTracker.Application.Services.Abstractions;

public interface ICurrentUserService
{
    bool HasUser { get; }
    bool IsAuthenticated { get; }
    Guid UserId { get; }
}