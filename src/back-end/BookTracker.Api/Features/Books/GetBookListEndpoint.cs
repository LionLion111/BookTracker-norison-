using BookTracker.Application.Features;
using BookTracker.Application.Features.Books.GetList;
using BookTracker.Persistence.Entities;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace BookTracker.Api.Features.Books;

public class GetBookListEndpoint : IEndpoint
{
    public string Group => GroupConstants.Books;

    public void Map(RouteGroupBuilder builder)
    {
        builder.MapGet("/", HandleAsync)
            .WithName("Get Book List")
            .WithDescription("Gets a list of books.")
            .Produces<PagedListResult<Book>>()
            .ProducesValidationProblem();
    }

    private static async Task<IResult> HandleAsync(
        [FromServices] ISender sender,
        [AsParameters] GetBookListQuery request,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(request, cancellationToken);
        return Results.Ok(result);
    }
}