using BookTracker.Api.Data;
using FastEndpoints;
using Sieve.Models;
using Sieve.Services;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BookTracker.Api.Features.UserBooks.GetList;

public class GetUserBookListEndpoint(AppDbContext dbContext, ISieveProcessor sieveProcessor)
    : Endpoint<GetUserBookListRequest, GetUserBookListResponse>
{
    public override void Configure()
    {
        Get("/");
        Group<UserBooksGroup>();
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetUserBookListRequest req, CancellationToken ct)
    {
        var query = dbContext.UserBooks.AsNoTracking();

        var sieveModel = req.Adapt<SieveModel>();

        var totalCount = await sieveProcessor
            .Apply(sieveModel, query, applyPagination: false)
            .CountAsync(ct);

        var result = await sieveProcessor
            .Apply(sieveModel, query)
            .ProjectToType<UserBookDto>()
            .ToListAsync(ct);

        Response.TotalCount = totalCount;
        Response.Data = result;
    }
}

