using BookTracker.Persistence;

using Mapster;

using Microsoft.EntityFrameworkCore;

using Sieve.Models;
using Sieve.Services;

namespace BookTracker.Application.Features.Publishers.GetList;

public class GetPublisherListQueryHandler(AppDbContext dbContext, ISieveProcessor sieveProcessor)
    : IQueryHandler<GetPublisherListQuery, PagedListResult<PublisherDto>>
{
    public async Task<PagedListResult<PublisherDto>> Handle(
        GetPublisherListQuery request,
        CancellationToken cancellationToken)
    {
        var sieveModel = request.Adapt<SieveModel>();
        var query = dbContext.Publishers.AsNoTracking();

        var totalCount = await sieveProcessor
            .Apply(sieveModel, query, applyPagination: false)
            .CountAsync(cancellationToken);

        var result = await sieveProcessor
            .Apply(sieveModel, query)
            .ToListAsync(cancellationToken);

        return new PagedListResult<PublisherDto> { TotalCount = totalCount, Data = result.Adapt<List<PublisherDto>>() };
    }
}