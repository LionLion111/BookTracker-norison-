using BookTracker.Api.Data.Enums;

namespace BookTracker.Api.Features.Books;

public class BookDto : AuditDto
{
    public Guid Id { get; set; }
    public string Isbn { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int PublishedYear { get; set; }
    public int PageCount { get; set; }
    public Language Language { get; set; }
    public Genre Genre { get; set; }
    public Guid PublisherId { get; set; }
}