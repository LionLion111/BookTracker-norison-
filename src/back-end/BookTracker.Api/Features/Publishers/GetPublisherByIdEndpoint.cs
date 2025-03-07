using BookTracker.Application.Features.Publishers.GetById;
using BookTracker.Persistence.Entities;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace BookTracker.Api.Features.Publishers;

public class GetPublisherByIdEndpoint : IEndpoint
{
    public string Group => GroupConstants.Publishers;

    public void Map(RouteGroupBuilder builder)
    {
        builder
            .MapGet("{id:guid}", HandleAsync)
            .WithName("Get Publisher By ID")
            .WithDescription("Gets a publisher by its ID.")
            .Produces<Publisher>()
            .ProducesValidationProblem();
    }

    private static async Task<IResult> HandleAsync(
        [FromServices] ISender sender,
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var query = new GetPublisherByIdQuery { Id = id };
        var result = await sender.Send(query, cancellationToken);
        return Results.Ok(result);
    }
}