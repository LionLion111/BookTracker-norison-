using BookTracker.Application.Features.Base.Queries;
using BookTracker.Persistence;
using BookTracker.Persistence.Entities;

namespace BookTracker.Application.Features.Publishers.GetById;

public class GetPublisherByIdQueryHandler(AppDbContext dbContext)
    : GetByIdQueryHandlerBase<GetPublisherByIdQuery, Publisher>(dbContext)
{
    protected override object[] GetKeys(GetPublisherByIdQuery request)
    {
        return [request.Id];
    }
}