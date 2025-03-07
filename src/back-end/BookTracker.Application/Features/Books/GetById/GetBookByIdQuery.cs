using BookTracker.Persistence.Entities;

namespace BookTracker.Application.Features.Books.GetById;

public class GetBookByIdQuery : IQuery<Book>
{
    public Guid Id { get; set; }
}