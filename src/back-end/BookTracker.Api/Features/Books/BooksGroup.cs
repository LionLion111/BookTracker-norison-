using FastEndpoints;

namespace BookTracker.Api.Features.Books;

public sealed class BooksGroup : Group
{
    public BooksGroup()
    {
        Configure("books", ep =>
        {
            ep.Description(builder => builder
                .Produces(StatusCodes.Status401Unauthorized)
                .RequireAuthorization());
        });
    }
}