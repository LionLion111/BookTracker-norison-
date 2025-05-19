using FastEndpoints;

using FluentValidation;

namespace BookTracker.Api.Features.Books.Create;

public class CreateBookRequestValidator : Validator<CreateBookRequest>
{
    public CreateBookRequestValidator()
    {
        RuleFor(x => x.Isbn).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.PublishedYear).InclusiveBetween(1000, 9999);
        RuleFor(x => x.PageCount).GreaterThan(0);
        RuleFor(x => x.Language).IsInEnum();
        RuleFor(x => x.Genre).IsInEnum();
    }
}
