using BookTracker.Application.Services.Abstractions;
using BookTracker.Application.Services.DateTime;
using BookTracker.Application.Services.GuidGenerator;
using BookTracker.Persistence;
using BookTracker.Persistence.Entities;

using Mapster;

namespace BookTracker.Application.Features.Publishers.Create;

public class CreatePublisherCommandHandler(
    AppDbContext dbContext,
    IDateTimeService dateTimeService,
    IGuidGenerator guidGenerator,
    ICurrentUserService currentUserService) : ICommandHandler<CreatePublisherCommand, CreatePublisherCommandResult>
{
    public async Task<CreatePublisherCommandResult> Handle(
        CreatePublisherCommand request,
        CancellationToken cancellationToken)
    {
        var userId = currentUserService.UserId;
        var time = dateTimeService.UtcNow;

        var publisher = request.Adapt<Publisher>();

        publisher.Id = guidGenerator.Generate();
        publisher.CreatedDateTime = time;
        publisher.ModifiedDateTime = time;
        publisher.CreatedBy = userId;
        publisher.ModifiedBy = userId;

        await dbContext.Publishers.AddAsync(publisher, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreatePublisherCommandResult { Id = publisher.Id };
    }
}