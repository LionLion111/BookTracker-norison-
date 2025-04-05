namespace BookTracker.Api.Features.Account.Register;

public class RegisterUserRequest
{
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}