using FluentValidation;

namespace BookTracker.Application.Features;

public abstract class PagedQueryValidator<T, TData> : AbstractValidator<T> where T : PagedQuery<TData>
{
    protected PagedQueryValidator()
    {
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.PageSize).GreaterThan(0);
        RuleFor(x => x.Sorts).NotEmpty().When(x => !string.IsNullOrEmpty(x.Filters));
    }
}