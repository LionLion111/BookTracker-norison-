namespace BookTracker.Api.Features.Authors;

public class AuthorDto : AuditDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
