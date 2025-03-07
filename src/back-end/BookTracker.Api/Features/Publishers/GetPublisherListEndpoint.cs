using BookTracker.Application.Features;
using BookTracker.Application.Features.Publishers.GetList;
using BookTracker.Persistence.Entities;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace BookTracker.Api.Features.Publishers;

public class GetPublisherListEndpoint : IEndpoint
{
    public string Group => GroupConstants.Publishers;

    public void Map(RouteGroupBuilder builder)
    {
        builder
            .MapGet("", HandleAsync)
            .WithSummary("Get Publisher List")
            .WithDescription("Gets a list of publishers.")
            .Produces<PagedListResult<Publisher>>()
            .ProducesValidationProblem();
    }

    private static async Task<IResult> HandleAsync(
        [FromServices] ISender sender,
        [AsParameters] GetPublisherListQuery query,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(query, cancellationToken);
        return Results.Ok(result);
    }
}