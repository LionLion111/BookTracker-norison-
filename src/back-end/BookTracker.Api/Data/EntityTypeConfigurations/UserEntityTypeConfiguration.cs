using BookTracker.Api.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookTracker.Api.Data.EntityTypeConfigurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
            new User
            {
                Id = Guid.Parse("2543771A-13B7-43B7-9336-F076269A305A"),
                UserName = "ihor.matiev@gmail.com",
                Email = "ihor.matiev@gmail.com",
                NormalizedUserName = "IHOR.MATIEV@GMAIL.COM",
                NormalizedEmail = "IHOR.MATIEV@GMAIL.COM",
                PasswordHash =
                    "AQAAAAIAAYagAAAAEKR+/xNwwFrod5bMlWNUaMYDeSr16/KSRLiMSOfOz+z5GHUGcQM/Nn+3zjGQcxP/8g=="
            }
        );
    }
}