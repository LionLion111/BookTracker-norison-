using BookTracker.Application.Features.Base.Queries;
using BookTracker.Persistence;
using BookTracker.Persistence.Entities;

using Sieve.Services;

namespace BookTracker.Application.Features.Books.GetList;

public class GetBookListQueryHandler(AppDbContext dbContext, ISieveProcessor sieveProcessor)
    : GetListQueryHandlerBase<GetBookListQuery, Book>(dbContext, sieveProcessor);