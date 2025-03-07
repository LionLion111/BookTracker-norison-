using FluentValidation;

namespace BookTracker.Application.Features.Books.GetById;

public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
{
    public GetBookByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}