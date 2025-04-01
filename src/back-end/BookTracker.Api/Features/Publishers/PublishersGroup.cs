using FastEndpoints;

namespace BookTracker.Api.Features.Publishers;

public sealed class PublishersGroup : Group
{
    public PublishersGroup()
    {
        Configure("publishers", ep =>
        {
            ep.Description(builder => builder
                .Produces(StatusCodes.Status401Unauthorized)
                .RequireAuthorization());
        });
    }
}