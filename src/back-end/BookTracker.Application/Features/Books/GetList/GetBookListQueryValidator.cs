using BookTracker.Persistence.Entities;

namespace BookTracker.Application.Features.Books.GetList;

public class GetBookListQueryValidator : PagedQueryValidator<GetBookListQuery, Book>;