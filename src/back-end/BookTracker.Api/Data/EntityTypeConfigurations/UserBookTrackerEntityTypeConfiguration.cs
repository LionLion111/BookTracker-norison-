using BookTracker.Api.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookTracker.Api.Data.EntityTypeConfigurations;

public class UserBookTrackerEntityTypeConfiguration : AuditEntityTypeConfiguration<UserBookTracker>
{
    public override void Configure(EntityTypeBuilder<UserBookTracker> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.StartDateTime).IsRequired();
        builder.Property(x => x.EndDateTime).IsRequired(false);

        builder
            .HasOne(x => x.UserBook)
            .WithMany(x => x.UserBookTrackers)
            .HasForeignKey(x => new { x.UserId, x.BookId })
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        base.Configure(builder);
    }
}