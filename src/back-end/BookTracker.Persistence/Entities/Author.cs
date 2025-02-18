namespace BookTracker.Persistence.Entities;

public class Author : AuditEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<AuthorBook>? AuthorBooks { get; set; }
}