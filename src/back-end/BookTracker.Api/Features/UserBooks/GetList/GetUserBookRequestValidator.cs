using BookTracker.Api.Features.Books.GetList;
using BookTracker.Api.Features.Books;

namespace BookTracker.Api.Features.UserBooks.GetList;

public class GetUserBookRequestValidator : PagedRequestValidatorBase<GetUserBookListRequest, UserBookDto>;
