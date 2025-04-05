using BookTracker.Api.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookTracker.Api.Data.EntityTypeConfigurations;

public class RoleEntityTypeConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(
            new Role
            {
                Id = Guid.Parse("CB444E26-D3B2-4F53-9C20-5853CB1FC46B"), Name = "Admin", NormalizedName = "ADMIN"
            },
            new Role
            {
                Id = Guid.Parse("2591B964-1B50-457D-B237-2FCCE31FC441"),
                Name = "Moderator",
                NormalizedName = "MODERATOR"
            },
            new Role { Id = Guid.Parse("B0BA862C-9A5D-484D-A7D7-E9F2C52FF89C"), Name = "User", NormalizedName = "USER" }
        );
    }
}