using FluentValidation;

using MediatR;

namespace BookTracker.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!validators.Any())
        {
            return await next();
        }

        var validationTasks = validators.Select(x => x.ValidateAsync(request, cancellationToken));

        var validationResults = await Task.WhenAll(validationTasks);

        var failures = validationResults
            .Where(x => !x.IsValid)
            .SelectMany(x => x.Errors)
            .ToList();

        throw new ValidationException(null, failures);
    }
}