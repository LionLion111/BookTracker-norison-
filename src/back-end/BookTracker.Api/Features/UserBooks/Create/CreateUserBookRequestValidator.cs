using FastEndpoints;

using FluentValidation;

namespace BookTracker.Api.Features.UserBooks.Create;

public class CreateUserBookRequestValidator : Validator<CreateUserBookRequest>
{
    public CreateUserBookRequestValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.BookId).NotEmpty();
        RuleFor(x => x.Status).IsInEnum();
        RuleFor(x => x.Mood).IsInEnum();
        RuleFor(x => x.PageRead).NotEmpty();
    }
}
