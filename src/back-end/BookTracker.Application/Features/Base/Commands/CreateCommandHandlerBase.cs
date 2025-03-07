using BookTracker.Application.Services.Abstractions;
using BookTracker.Application.Services.DateTime;
using BookTracker.Persistence;
using BookTracker.Persistence.Entities;

namespace BookTracker.Application.Features.Base.Commands;

public abstract class CreateCommandHandlerBase<TCommand, TResult, TData>(
    AppDbContext dbContext,
    IDateTimeService dateTimeService,
    ICurrentUserService currentUserService)
    : ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult> where TData : AuditEntity
{
    protected abstract TData MapToEntity(TCommand request);
    protected abstract TResult MapToResult(TData entity);

    protected virtual async Task ValidateAsync(TCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    public async Task<TResult> Handle(TCommand request, CancellationToken cancellationToken)
    {
        await ValidateAsync(request, cancellationToken);
        
        var userId = currentUserService.UserId;
        var time = dateTimeService.UtcNow;

        var entity = MapToEntity(request);
        entity.CreatedDateTime = time;
        entity.ModifiedDateTime = time;
        entity.CreatedBy = userId;
        entity.ModifiedBy = userId;

        await dbContext.Set<TData>().AddAsync(entity, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return MapToResult(entity);
    }
}