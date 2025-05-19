using FastEndpoints;

namespace BookTracker.Api.Features.Authors;

public class AuthorGroup : Group
{
    public AuthorGroup()
    {
        Configure("authors", ep =>
        {
            ep.Description(builder => builder.WithDescription("Endpoints for managing authors."));
        });
    }
}