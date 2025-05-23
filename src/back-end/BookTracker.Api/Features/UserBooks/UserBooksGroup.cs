using FastEndpoints;

namespace BookTracker.Api.Features.UserBooks;

public class UserBooksGroup : Group
{
    public UserBooksGroup()
    {
        Configure("userBooks", ep =>
        {
            ep.Description(builder => builder.WithDescription("Endpoints for managing user-books."));
        });
    }
}