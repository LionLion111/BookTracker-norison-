namespace BookTracker.Application.Features.Publishers.Create;

public class CreatePublisherCommand : ICommand<CreatePublisherCommandResult>
{
    public string Name { get; set; } = string.Empty;
}