using BookTracker.Api.Features.Publishers.GetList;
using BookTracker.Api.Features.Publishers;

namespace BookTracker.Api.Features.Books.GetList;

public class GetBookRequestValidator : PagedRequestValidatorBase<GetBookListRequest, BookDto>;