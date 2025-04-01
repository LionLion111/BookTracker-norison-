namespace BookTracker.Api.Features.Publishers;

public class PublisherDto : AuditDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}