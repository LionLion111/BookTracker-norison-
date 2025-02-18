using Microsoft.AspNetCore.Identity;

namespace BookTracker.Persistence.Entities;

public sealed class User : IdentityUser<Guid>
{
    public User()
    {
        Id = Guid.CreateVersion7();
        SecurityStamp = Guid.NewGuid().ToString();
    }

    public ICollection<UserBook>? UserBooks { get; set; }
}