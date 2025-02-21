using BookTracker.Application.Features;
using BookTracker.Application.Features.Publishers;
using BookTracker.Application.Features.Publishers.GetList;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace BookTracker.Api.Features.Publishers.GetList;

public class GetPublisherListEndpoint : IEndpoint
{
    public string Group => GroupConstants.Publishers;

    public void Map(RouteGroupBuilder builder)
    {
        builder
            .MapGet("", HandleAsync)
            .WithSummary("Get Publisher List")
            .WithDescription("Gets a list of publishers.")
            .Produces<PagedListResult<PublisherDto>>()
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