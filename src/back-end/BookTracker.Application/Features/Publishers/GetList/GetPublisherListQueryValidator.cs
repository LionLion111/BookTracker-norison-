using FluentValidation;

namespace BookTracker.Application.Features.Publishers.GetList;

public class GetPublisherListQueryValidator : AbstractValidator<GetPublisherListQuery>
{
    public GetPublisherListQueryValidator()
    {
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.PageSize).GreaterThan(0);
        RuleFor(x => x.Sorts).NotEmpty().When(x => !string.IsNullOrEmpty(x.Filters));
    }
}