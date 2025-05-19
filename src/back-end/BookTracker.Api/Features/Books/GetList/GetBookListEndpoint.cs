using BookTracker.Api.Data;
using FastEndpoints;
using Sieve.Models;
using Sieve.Services;
using Microsoft.EntityFrameworkCore;
using Mapster;

namespace BookTracker.Api.Features.Books.GetList;

public class GetBookListEndpoint(AppDbContext dbContext, ISieveProcessor sieveProcessor)
    : Endpoint<GetBookListRequest, GetBookListResponse>
{
    public override void Configure()
    {
        Get("/");
        Group<BooksGroup>();
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetBookListRequest req, CancellationToken ct)
    {
        var query = dbContext.Books.AsNoTracking();

        var sieveModel = req.Adapt<SieveModel>();

        var totalCount = await sieveProcessor
            .Apply(sieveModel, query, applyPagination: false)
            .CountAsync(ct);

        var result = await sieveProcessor
            .Apply(sieveModel, query)
            .ProjectToType<BookDto>()
            .ToListAsync(ct);

        Response.TotalCount = totalCount;
        Response.Data = result;
    }
}
