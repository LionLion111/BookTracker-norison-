namespace BookTracker.Persistence.Entities;

public class Publisher : AuditEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Book>? Books { get; set; }
}