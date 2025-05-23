using BookTracker.Api.Data;
using BookTracker.Api.Features.UserBooks.GetList;
using BookTracker.Api.Features.UserBooks;
using FastEndpoints;
using Sieve.Models;
using Sieve.Services;
using Microsoft.EntityFrameworkCore;
using Mapster;

namespace BookTracker.Api.Features.UserBookTrackers.GetList;

public class GetUserBookTrackerListEndpoint(AppDbContext dbContext, ISieveProcessor sieveProcessor)
    : Endpoint<GetUserBookTrackerListRequest, GetUserBookTrackerListResponse>
{
    public override void Configure()
    {
        Get("/");
        Group<UserBookTrackersGroup>();
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetUserBookTrackerListRequest req, CancellationToken ct)
    {
        var query = dbContext.UserBookTrackers.AsNoTracking();

        var sieveModel = req.Adapt<SieveModel>();

        var totalCount = await sieveProcessor
            .Apply(sieveModel, query, applyPagination: false)
            .CountAsync(ct);

        var result = await sieveProcessor
            .Apply(sieveModel, query)
            .ProjectToType<UserBookTrackerDto>()
            .ToListAsync(ct);

        Response.TotalCount = totalCount;
        Response.Data = result;
    }
}
