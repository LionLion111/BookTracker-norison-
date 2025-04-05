using BookTracker.Api.Data;

using FastEndpoints;

using Mapster;

using Microsoft.EntityFrameworkCore;

using Sieve.Models;
using Sieve.Services;

namespace BookTracker.Api.Features.Publishers.GetList;

public class GetPublisherListEndpoint(AppDbContext dbContext, ISieveProcessor sieveProcessor)
    : Endpoint<GetPublisherListRequest, GetPublisherListResponse>
{
    public override void Configure()
    {
        Get("/");
        Group<PublishersGroup>();
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetPublisherListRequest req, CancellationToken ct)
    {
        var query = dbContext.Publishers.AsNoTracking();

        var sieveModel = req.Adapt<SieveModel>();

        var totalCount = await sieveProcessor
            .Apply(sieveModel, query, applyPagination: false)
            .CountAsync(ct);

        var result = await sieveProcessor
            .Apply(sieveModel, query)
            .ProjectToType<PublisherDto>()
            .ToListAsync(ct);
        
        Response.TotalCount = totalCount;
        Response.Data = result;
    }
}