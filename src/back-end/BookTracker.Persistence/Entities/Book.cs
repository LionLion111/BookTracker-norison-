using BookTracker.Persistence.Enums;

namespace BookTracker.Persistence.Entities;

public class Book : AuditEntity
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
    public Publisher? Publisher { get; set; }

    public ICollection<AuthorBook>? AuthorBooks { get; set; }
    public ICollection<UserBook>? UserBooks { get; set; }
}