using FluentValidation;

namespace BookTracker.Application.Features.Publishers.GetById;

public class GetPublisherByIdQueryValidator : AbstractValidator<GetPublisherByIdQuery>
{
    public GetPublisherByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}