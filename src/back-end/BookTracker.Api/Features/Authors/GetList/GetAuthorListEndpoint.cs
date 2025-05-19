using BookTracker.Api.Data;
using FastEndpoints;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace BookTracker.Api.Features.Authors.GetList;

public class GetAuthorListEndpoint(AppDbContext dbContext, ISieveProcessor sieveProcessor)
    : Endpoint<GetAuthorListRequest, GetAuthorListResponse>
{
    public override void Configure()
    {
        Get("/");
        Group<AuthorGroup>();
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetAuthorListRequest req, CancellationToken ct)
    {
        var query = dbContext.Authors.AsNoTracking();

        var sieveModel = req.Adapt<SieveModel>();

        var totalCount = await sieveProcessor
            .Apply(sieveModel, query, applyPagination: false)
            .CountAsync(ct);

        var result = await sieveProcessor
            .Apply(sieveModel, query)
            .ProjectToType<AuthorDto>()
            .ToListAsync(ct);

        Response.TotalCount = totalCount;
        Response.Data = result;
    }
}
