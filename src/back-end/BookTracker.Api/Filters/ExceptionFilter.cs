using BookTracker.Application.Exceptions;

using FluentValidation;

namespace BookTracker.Api.Filters;

public class ExceptionFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        try
        {
            return await next(context);
        }
        catch (Exception exception)
        {
            return HandleException(exception);
        }
    }

    private static IResult HandleException(Exception exception)
    {
        return exception switch
        {
            BookTrackerNotFoundException notFoundException => Results.Problem(
                detail: notFoundException.Details,
                statusCode: StatusCodes.Status404NotFound,
                title: notFoundException.Message),
            BookTrackerValidationException validationException => Results.Problem(
                detail: validationException.Details,
                statusCode: StatusCodes.Status400BadRequest,
                title: validationException.Message),
            ValidationException fluentValidationException => Results.ValidationProblem(
                errors: fluentValidationException.Errors.ToDictionary(x => x.ErrorCode, x => new[] { x.ErrorMessage })),
            _ => Results.Problem(exception.Message)
        };
    }
}