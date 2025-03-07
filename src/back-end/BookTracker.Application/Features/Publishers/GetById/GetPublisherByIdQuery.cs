using BookTracker.Persistence.Entities;

namespace BookTracker.Application.Features.Publishers.GetById;

public class GetPublisherByIdQuery : IQuery<Publisher>
{
    public Guid Id { get; set; }
}