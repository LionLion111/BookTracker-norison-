using BookTracker.Application.Features.Base.Queries;
using BookTracker.Persistence;
using BookTracker.Persistence.Entities;

using Sieve.Services;

namespace BookTracker.Application.Features.Publishers.GetList;

public class GetPublisherListQueryHandler(AppDbContext dbContext, ISieveProcessor sieveProcessor)
    : GetListQueryHandlerBase<GetPublisherListQuery, Publisher>(dbContext, sieveProcessor);