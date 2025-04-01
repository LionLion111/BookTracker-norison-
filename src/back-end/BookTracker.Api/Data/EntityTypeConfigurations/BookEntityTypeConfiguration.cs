using BookTracker.Api.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookTracker.Api.Data.EntityTypeConfigurations;

public class BookEntityTypeConfiguration : AuditEntityTypeConfiguration<Book>
{
    public override void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Isbn).IsRequired().HasMaxLength(13);
        builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);
        builder.Property(x => x.PublishedYear).IsRequired();
        builder.Property(x => x.PageCount).IsRequired();
        builder.Property(x => x.Language).IsRequired();
        builder.Property(x => x.Genre).IsRequired();

        builder
            .HasOne(x => x.Publisher)
            .WithMany(x => x.Books)
            .HasForeignKey(x => x.PublisherId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        base.Configure(builder);
    }
}