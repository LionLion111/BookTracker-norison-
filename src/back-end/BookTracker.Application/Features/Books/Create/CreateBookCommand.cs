using BookTracker.Persistence.Enums;

namespace BookTracker.Application.Features.Books.Create;

public class CreateBookCommand : ICommand<CreateBookCommandResult>
{
    public string Isbn { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int PublishedYear { get; set; }
    public int PageCount { get; set; }
    public Language Language { get; set; }
    public Genre Genre { get; set; }

    public Guid PublisherId { get; set; }
}