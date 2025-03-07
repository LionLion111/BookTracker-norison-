using BookTracker.Persistence;

using Mapster;

using Microsoft.EntityFrameworkCore;

using Sieve.Models;
using Sieve.Services;

namespace BookTracker.Application.Features.Base.Queries;

public abstract class GetListQueryHandlerBase<TQuery, TData>(AppDbContext dbContext, ISieveProcessor sieveProcessor)
    : IQueryHandler<TQuery, PagedListResult<TData>> where TQuery : PagedQuery<TData> where TData : class
{
    public async Task<PagedListResult<TData>> Handle(TQuery request, CancellationToken cancellationToken)
    {
        var sieveModel = request.Adapt<SieveModel>();
        var query = dbContext.Set<TData>().AsNoTracking();

        var totalCount = await sieveProcessor
            .Apply(sieveModel, query, applyPagination: false)
            .CountAsync(cancellationToken);

        var result = await sieveProcessor
            .Apply(sieveModel, query)
            .ToListAsync(cancellationToken);

        return new PagedListResult<TData> { TotalCount = totalCount, Data = result };
    }
}