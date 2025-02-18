using System.Security.Claims;

using BookTracker.Persistence;
using BookTracker.Persistence.Entities;

using Microsoft.EntityFrameworkCore;

namespace BookTracker.Api.Features.Publishers.GetById;

public class GetPublisherByIdEndpoint : IEndpoint
{
    public string Group => GroupConstants.Publishers;

    public void Map(RouteGroupBuilder builder)
    {
        builder.MapGet("{id:guid}",
                async (AppDbContext dbContext, ClaimsPrincipal user, Guid id, CancellationToken cancellationToken) =>
                {
                    var userId = Guid.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier)!);
                    var publisher = await dbContext.Publishers.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

                    if (publisher == null || publisher.CreatedBy != userId)
                    {
                        return Results.NotFound();
                    }

                    return Results.Ok(publisher);
                })
            .WithName("Get Publisher by Id")
            .WithDescription("Gets a publisher by its Id.")
            .Produces<Publisher>();
    }
}