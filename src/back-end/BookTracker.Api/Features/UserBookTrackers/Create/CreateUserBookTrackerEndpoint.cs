using BookTracker.Api.Constants;
using BookTracker.Api.Data.Entities;
using BookTracker.Api.Data;
using FastEndpoints;

namespace BookTracker.Api.Features.UserBookTrackers.Create;

public class CreateUserBookTrackerEndpoint(AppDbContext dbContext) : Endpoint<CreateUserBookTrackerRequest, CreateUserBookTrackerResponse>
{
    public override void Configure()
    {
        Post("/");
        Group<UserBookTrackersGroup>();
        Policies(AuthPolicy.Admin);
    }

    public override async Task HandleAsync(CreateUserBookTrackerRequest req, CancellationToken ct)
    {
        var dateTime = DateTime.UtcNow;

        var userBookTracker = new UserBookTracker
        {
            Id = Guid.CreateVersion7(),            
            StartDateTime = req.StartDateTime,
            EndDateTime = req.EndDateTime,
            UserId = req.UserId,
            BookId = req.BookId,
            CreatedDateTime = dateTime,
            ModifiedDateTime = dateTime,
            CreatedBy = req.UserId,
            ModifiedBy = req.UserId
        };

        dbContext.UserBookTrackers.Add(userBookTracker);
        await dbContext.SaveChangesAsync(ct);
    }
}
