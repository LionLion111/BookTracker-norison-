using Microsoft.AspNetCore.Identity;

namespace BookTracker.Api.Data.Entities;

public sealed class Role : IdentityRole<Guid>
{
    public Role()
    {
        Id = Guid.CreateVersion7();
    }
}