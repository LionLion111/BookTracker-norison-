using System.Security.Claims;

using BookTracker.Persistence;
using BookTracker.Persistence.Entities;

namespace BookTracker.Api.Features.Publishers.Create;

public class CreatePublisherEndpoint : IEndpoint
{
    public string Group => GroupConstants.Publishers;

    public void Map(RouteGroupBuilder builder)
    {
        builder.MapPost("/",
                async (AppDbContext dbContext, ClaimsPrincipal user, CreatePublisherRequest request,
                    CancellationToken cancellationToken) =>
                {
                    var now = DateTime.UtcNow;
                    var userId = Guid.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier)!);

                    var publisher = new Publisher
                    {
                        Id = Guid.CreateVersion7(),
                        Name = request.Name,
                        CreatedDateTime = now,
                        ModifiedDateTime = now,
                        CreatedBy = userId,
                        ModifiedBy = userId
                    };

                    await dbContext.Publishers.AddAsync(publisher, cancellationToken);
                    await dbContext.SaveChangesAsync(cancellationToken);

                    return Results.Ok(new CreatePublisherResponse { Id = publisher.Id });
                })
            .WithName("Create Publisher")
            .WithDescription("Creates a new publisher.")
            .Produces<CreatePublisherResponse>();
    }
}