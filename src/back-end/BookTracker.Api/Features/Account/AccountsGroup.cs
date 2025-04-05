using FastEndpoints;

namespace BookTracker.Api.Features.Account;

public sealed class AccountsGroup : Group
{
    public AccountsGroup()
    {
        Configure("accounts", _ => { });
    }
}