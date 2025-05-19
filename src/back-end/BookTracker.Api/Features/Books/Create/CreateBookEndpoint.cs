using BookTracker.Api.Constants;
using BookTracker.Api.Data.Entities;
using BookTracker.Api.Data;
using BookTracker.Api.Features.Publishers;
using FastEndpoints;

namespace BookTracker.Api.Features.Books.Create;

public class CreateBookEndpoint(AppDbContext dbContext) : Endpoint<CreateBookRequest, CreateBookResponse>
{
    public override void Configure()
    {
        Post("/");
        Group<BooksGroup>();
        Policies(AuthPolicy.Admin);
    }

    public override async Task HandleAsync(CreateBookRequest req, CancellationToken ct)
    {
        var dateTime = DateTime.UtcNow;

        var book = new Book
        {
            Id = Guid.CreateVersion7(),
            Isbn = req.Isbn,
            Title = req.Title,
            Description = req.Description,
            PublishedYear = req.PublishedYear,
            PageCount = req.PageCount,
            Language = req.Language,
            Genre = req.Genre,
            PublisherId = req.PublisherId,
            CreatedDateTime = dateTime,
            ModifiedDateTime = dateTime,
            CreatedBy = req.UserId,
            ModifiedBy = req.UserId,
            AuthorBooks = new List<AuthorBook>()
        };

        if (req.AuthorIds?.Any() == true)
        {
            foreach (var authorId in req.AuthorIds)
            {
                book.AuthorBooks.Add(new AuthorBook
                {
                    AuthorId = authorId
                });
            }
        }

        dbContext.Books.Add(book);
        await dbContext.SaveChangesAsync(ct);

        Response.Id = book.Id;
    }
}
