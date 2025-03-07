using FluentValidation;

namespace BookTracker.Application.Features.Books.Create;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(x => x.Isbn).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.PublishedYear).NotEmpty();
        RuleFor(x => x.PageCount).NotEmpty();
        RuleFor(x => x.Language).IsInEnum();
        RuleFor(x => x.Genre).IsInEnum();
        RuleFor(x => x.PublisherId).NotEmpty();
    }
}