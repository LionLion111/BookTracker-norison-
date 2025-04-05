using BookTracker.Api.Constants;
using BookTracker.Api.Data;
using BookTracker.Api.Data.Entities;

using FastEndpoints;

using Microsoft.AspNetCore.Identity;

namespace BookTracker.Api.Features.Account.Register;

public class RegisterUserEndpoint(UserManager<User> userManager, AppDbContext dbContext)
    : Endpoint<RegisterUserRequest>
{
    public override void Configure()
    {
        Post("/register");
        Group<AccountsGroup>();
        AllowAnonymous();
    }

    public override async Task HandleAsync(RegisterUserRequest req, CancellationToken ct)
    {
        var user = new User { Id = Guid.CreateVersion7(), UserName = req.Email, Email = req.Email };

        var result = await userManager.CreateAsync(user, req.Password);

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, RoleConstants.User);
        }

        foreach (var error in result.Errors)
        {
            AddError(error.Description, error.Code);
        }
    }
}