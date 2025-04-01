using FastEndpoints;

using FluentValidation;

namespace BookTracker.Api.Features;

public class PagedRequestValidatorBase<TQuery, TData> : Validator<TQuery> where TQuery : PagedRequestBase
{
    protected PagedRequestValidatorBase()
    {
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.PageSize).GreaterThan(0);
        RuleFor(x => x.Sorts).NotEmpty().When(x => !string.IsNullOrEmpty(x.Filters));
    }
}