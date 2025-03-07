using FluentValidation;

namespace BookTracker.Application.Features;

public abstract class PagedQueryValidator<TQuery, TData> : AbstractValidator<TQuery> where TQuery : PagedQuery<TData>
{
    protected PagedQueryValidator()
    {
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.PageSize).GreaterThan(0);
        RuleFor(x => x.Sorts).NotEmpty().When(x => !string.IsNullOrEmpty(x.Filters));
    }
}