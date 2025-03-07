using BookTracker.Application.Exceptions;
using BookTracker.Application.Features.Base.Commands;
using BookTracker.Application.Services.Abstractions;
using BookTracker.Application.Services.DateTime;
using BookTracker.Application.Services.GuidGenerator;
using BookTracker.Persistence;
using BookTracker.Persistence.Entities;

using Microsoft.EntityFrameworkCore;

namespace BookTracker.Application.Features.Publishers.Create;

public class CreatePublisherCommandHandler(
    AppDbContext dbContext,
    IDateTimeService dateTimeService,
    ICurrentUserService currentUserService,
    IGuidGenerator guidGenerator)
    : CreateCommandHandlerBase<CreatePublisherCommand, CreatePublisherCommandResult, Publisher>(dbContext,
        dateTimeService, currentUserService)
{
    private readonly AppDbContext _dbContext = dbContext;

    protected override Publisher MapToEntity(CreatePublisherCommand request)
    {
        return new Publisher { Id = guidGenerator.Generate(), Name = request.Name };
    }

    protected override CreatePublisherCommandResult MapToResult(Publisher entity)
    {
        return new CreatePublisherCommandResult { Id = entity.Id };
    }

    protected override async Task ValidateAsync(CreatePublisherCommand request, CancellationToken cancellationToken)
    {
        var existingPublisher =
            await _dbContext.Publishers.FirstOrDefaultAsync(x => x.Name == request.Name, cancellationToken);

        if (existingPublisher is not null)
        {
            throw new BookTrackerValidationException("Publisher already exists.");
        }
    }
}