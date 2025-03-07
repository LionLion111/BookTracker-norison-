using BookTracker.Application.Features.Books.Create;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace BookTracker.Api.Features.Books;

public class CreateBookEndpoint : IEndpoint
{
    public string Group => GroupConstants.Books;
    
    public void Map(RouteGroupBuilder builder)
    {
        builder.MapPost("/", HandleAsync)
            .WithName("Create Book")
            .WithDescription("Creates a new book.")
            .Produces<CreateBookCommandResult>()
            .ProducesValidationProblem();
    }
    
    private static async Task<IResult> HandleAsync(
        [FromServices] ISender sender,
        [FromBody] CreateBookCommand request,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(request, cancellationToken);
        return Results.Ok(result);
    }
}