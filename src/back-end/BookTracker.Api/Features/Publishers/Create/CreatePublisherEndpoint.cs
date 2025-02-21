using BookTracker.Application.Features.Publishers.Create;

using Mapster;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace BookTracker.Api.Features.Publishers.Create;

public class CreatePublisherEndpoint : IEndpoint
{
    public string Group => GroupConstants.Publishers;

    public void Map(RouteGroupBuilder builder)
    {
        builder
            .MapPost("/", HandleAsync)
            .WithName("Create Publisher")
            .WithDescription("Creates a new publisher.")
            .Produces<CreatePublisherResponse>()
            .ProducesValidationProblem();
    }

    private static async Task<IResult> HandleAsync(
        [FromServices] ISender sender,
        [FromBody] CreatePublisherRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.Adapt<CreatePublisherCommand>();
        var result = await sender.Send(command, cancellationToken);
        var response = result.Adapt<CreatePublisherResponse>();
        return Results.Ok(response);
    }
}