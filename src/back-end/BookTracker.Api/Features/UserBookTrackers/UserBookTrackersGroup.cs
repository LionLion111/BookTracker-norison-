using FastEndpoints;

namespace BookTracker.Api.Features.UserBookTrackers;

public class UserBookTrackersGroup : Group
{
    public UserBookTrackersGroup()
    {
        Configure("userBookTrackers", ep =>
        {
            ep.Description(builder => builder.WithDescription("Endpoints for managing user-book-trackers."));
        });
    }
}
