using BookTracker.Application.Features.Base.Queries;
using BookTracker.Persistence;
using BookTracker.Persistence.Entities;

namespace BookTracker.Application.Features.Books.GetById;

public class GetBookByIdQueryHandler(AppDbContext dbContext) : GetByIdQueryHandlerBase<GetBookByIdQuery, Book>(dbContext)
{
    protected override object[] GetKeys(GetBookByIdQuery request)
    {
        return [request.Id];
    }
}