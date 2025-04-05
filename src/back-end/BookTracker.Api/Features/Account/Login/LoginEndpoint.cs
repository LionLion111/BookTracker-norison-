using BookTracker.Api.Data.Entities;

using FastEndpoints;

using Microsoft.AspNetCore.Identity;

namespace BookTracker.Api.Features.Account.Login;

public class LoginEndpoint(SignInManager<User> signInManager) : Endpoint<LoginUserRequest>
{
    public override void Configure()
    {
        Post("/login");
        Group<AccountsGroup>();
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginUserRequest req, CancellationToken ct)
    {
        var useCookieScheme = (req.UseCookies == true) || (req.UseSessionCookies == true);
        var isPersistent = (req.UseCookies == true) && (req.UseSessionCookies != true);
        signInManager.AuthenticationScheme =
            useCookieScheme ? IdentityConstants.ApplicationScheme : IdentityConstants.BearerScheme;

        var result =
            await signInManager.PasswordSignInAsync(req.Email, req.Password, isPersistent, lockoutOnFailure: true);

        if (!result.Succeeded)
        {
            await SendUnauthorizedAsync(ct);
        }
    }
}