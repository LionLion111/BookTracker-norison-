using BookTracker.Persistence.Entities;

namespace BookTracker.Application.Features.Publishers.GetList;

public class GetPublisherListQueryValidator : PagedQueryValidator<GetPublisherListQuery, Publisher>;