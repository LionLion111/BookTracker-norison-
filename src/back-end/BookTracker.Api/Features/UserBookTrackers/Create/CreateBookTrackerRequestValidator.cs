using FastEndpoints;

using FluentValidation;

namespace BookTracker.Api.Features.UserBookTrackers.Create;

public class CreateBookTrackerRequestValidator : Validator<CreateUserBookTrackerRequest>
{
    public CreateBookTrackerRequestValidator()
    {
        RuleFor(x => x.StartDateTime).NotEmpty();
        RuleFor(x => x.EndDateTime).NotEmpty();
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.BookId).NotEmpty();
    }
}
