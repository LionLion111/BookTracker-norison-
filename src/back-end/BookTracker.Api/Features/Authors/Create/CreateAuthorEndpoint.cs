using BookTracker.Api.Constants;
using BookTracker.Api.Data;
using BookTracker.Api.Data.Entities;

using FastEndpoints;


namespace BookTracker.Api.Features.Authors.Create;

public class CreateAuthorEndpoint(AppDbContext dbContext) : Endpoint<CreateAuthorRequest, CreateAuthorResponse>
{
    public override void Configure()
    {
        Post("/");
        Group<AuthorGroup>();
        Policies(AuthPolicy.Admin);
    }

    public override async Task HandleAsync(CreateAuthorRequest req, CancellationToken ct)
    {
        var dateTime = DateTime.UtcNow;

        var author = new Author
        {
            Id = Guid.CreateVersion7(),
            Name = req.Name,
            CreatedDateTime = dateTime,
            ModifiedDateTime = dateTime,
            CreatedBy = req.UserId,
            ModifiedBy = req.UserId,
            AuthorBooks = req.BookIds.Select(bookId => new AuthorBook
            {
                BookId = bookId
            }).ToList(),
        };        

        dbContext.Authors.Add(author);
        await dbContext.SaveChangesAsync(ct);

        Response.Id = author.Id;
    }
}
