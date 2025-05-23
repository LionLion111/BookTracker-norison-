using BookTracker.Api.Constants;
using BookTracker.Api.Data.Entities;
using BookTracker.Api.Data;
using FastEndpoints;

namespace BookTracker.Api.Features.UserBooks.Create;

public class CreateUserBookEndpoint(AppDbContext dbContext) : Endpoint<CreateUserBookRequest, CreateUserBookResponse>
{
    public override void Configure()
    {
        Post("/");
        Group<UserBooksGroup>();
        Policies(AuthPolicy.Admin);
    }

    public override async Task HandleAsync(CreateUserBookRequest req, CancellationToken ct)
    {
        var dateTime = DateTime.UtcNow;

        var userBook = new UserBook
        {
            Status = req.Status,
            Mood = req.Mood,
            PageRead = req.PageRead,
            UserId = req.UserId,
            BookId = req.BookId,            
            CreatedDateTime = dateTime,
            ModifiedDateTime = dateTime,
            CreatedBy = req.UserId,
            ModifiedBy = req.UserId,
            UserBookTrackers = req.UserBookTrackersIds.Select(userBookTrackerId => new UserBookTracker
            {
                UserId = userBookTrackerId
            }).ToList(),

        };

        dbContext.UserBooks.Add(userBook);
        await dbContext.SaveChangesAsync(ct);       
    }
}
