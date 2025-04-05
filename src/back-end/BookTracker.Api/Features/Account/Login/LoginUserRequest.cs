namespace BookTracker.Api.Features.Account.Login;

public class LoginUserRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool? UseCookies { get; set; }
    public bool? UseSessionCookies { get; set; }
}