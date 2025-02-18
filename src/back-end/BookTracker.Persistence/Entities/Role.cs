using Microsoft.AspNetCore.Identity;

namespace BookTracker.Persistence.Entities;

public sealed class Role : IdentityRole<Guid>
{
    public Role()
    {
        Id = Guid.CreateVersion7();
    }
}