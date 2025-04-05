using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookTracker.Api.Data.EntityTypeConfigurations;

public class UserRoleEntityTypeConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
    {
        builder.HasData(new IdentityUserRole<Guid>
        {
            UserId = Guid.Parse("2543771A-13B7-43B7-9336-F076269A305A"),
            RoleId = Guid.Parse("CB444E26-D3B2-4F53-9C20-5853CB1FC46B")
        });
    }
}