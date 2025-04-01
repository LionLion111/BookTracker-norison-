using BookTracker.Api.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookTracker.Api.Data.EntityTypeConfigurations;

public class AuthorBookEntityTypeConfiguration : AuditEntityTypeConfiguration<AuthorBook>
{
    public override void Configure(EntityTypeBuilder<AuthorBook> builder)
    {
        builder.HasKey(x => new { x.AuthorId, x.BookId });

        builder
            .HasOne(x => x.Author)
            .WithMany(x => x.AuthorBooks)
            .HasForeignKey(x => x.AuthorId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Book)
            .WithMany(x => x.AuthorBooks)
            .HasForeignKey(x => x.BookId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        base.Configure(builder);
    }
}