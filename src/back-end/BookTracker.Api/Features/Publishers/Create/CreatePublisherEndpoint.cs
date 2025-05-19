using BookTracker.Api.Constants;
using BookTracker.Api.Data;
using BookTracker.Api.Data.Entities;

using FastEndpoints;

namespace BookTracker.Api.Features.Publishers.Create;

public class CreatePublisherEndpoint(AppDbContext dbContext) : Endpoint<CreatePublisherRequest, CreatePublisherResponse>
{
    public override void Configure()
    {
        Post("/");
        Group<PublishersGroup>();
        Policies(AuthPolicy.Admin);
    }

    public override async Task HandleAsync(CreatePublisherRequest req, CancellationToken ct)
    {
        var dateTime = DateTime.UtcNow;

        var publisher = new Publisher
        {
            Id = Guid.CreateVersion7(),
            Name = req.Name,
            CreatedDateTime = dateTime,
            ModifiedDateTime = dateTime,
            CreatedBy = req.UserId,
            ModifiedBy = req.UserId
        };

        dbContext.Publishers.Add(publisher);
        await dbContext.SaveChangesAsync(ct);

        Response.Id = Guid.NewGuid(); // publisher.Id;
    }
}