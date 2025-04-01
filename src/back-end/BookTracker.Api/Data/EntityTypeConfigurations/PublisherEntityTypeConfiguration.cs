using BookTracker.Api.Data.Entities;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookTracker.Api.Data.EntityTypeConfigurations;

public class PublisherEntityTypeConfiguration : AuditEntityTypeConfiguration<Publisher>
{
    public override void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

        base.Configure(builder);
    }
}