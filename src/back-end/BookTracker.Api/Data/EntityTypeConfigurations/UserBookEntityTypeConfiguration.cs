using BookTracker.Api.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookTracker.Api.Data.EntityTypeConfigurations;

public class UserBookEntityTypeConfiguration : AuditEntityTypeConfiguration<UserBook>
{
    public override void Configure(EntityTypeBuilder<UserBook> builder)
    {
        builder.HasKey(x => new { x.UserId, x.BookId });
        builder.Property(x => x.Status).IsRequired();
        builder.Property(x => x.Mood).IsRequired();
        builder.Property(x => x.PageRead).IsRequired();

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.UserBooks)
            .HasForeignKey(x => x.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Book)
            .WithMany(x => x.UserBooks)
            .HasForeignKey(x => x.BookId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        base.Configure(builder);
    }
}