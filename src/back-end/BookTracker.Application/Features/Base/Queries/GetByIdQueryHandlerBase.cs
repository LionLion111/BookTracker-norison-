using BookTracker.Application.Exceptions;
using BookTracker.Persistence;

namespace BookTracker.Application.Features.Base.Queries;

public abstract class GetByIdQueryHandlerBase<TQuery, TData>(AppDbContext dbContext)
    : IQueryHandler<TQuery, TData> where TQuery : IQuery<TData> where TData : class
{
    protected abstract object[] GetKeys(TQuery request);

    public async Task<TData> Handle(TQuery request, CancellationToken cancellationToken)
    {
        var keys = GetKeys(request);
        var entity = await dbContext.Set<TData>().FindAsync(keys, cancellationToken);

        if (entity is null)
        {
            throw new BookTrackerNotFoundException(
                $"Entity not found with the provided keys: '{string.Join(", ", keys)}'");
        }

        return entity;
    }
}