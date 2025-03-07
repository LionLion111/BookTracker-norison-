using BookTracker.Application.Features.Publishers.Create;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace BookTracker.Api.Features.Publishers;

public class CreatePublisherEndpoint : IEndpoint
{
    public string Group => GroupConstants.Publishers;

    public void Map(RouteGroupBuilder builder)
    {
        builder
            .MapPost("/", HandleAsync)
            .WithName("Create Publisher")
            .WithDescription("Creates a new publisher.")
            .Produces<CreatePublisherCommandResult>()
            .ProducesValidationProblem();
    }

    private static async Task<IResult> HandleAsync(
        [FromServices] ISender sender,
        [FromBody] CreatePublisherCommand request,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(request, cancellationToken);
        return Results.Ok(result);
    }
}