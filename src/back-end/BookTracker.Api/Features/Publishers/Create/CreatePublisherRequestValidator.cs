using FastEndpoints;

using FluentValidation;

namespace BookTracker.Api.Features.Publishers.Create;

public class CreatePublisherRequestValidator : Validator<CreatePublisherRequest>
{
    public CreatePublisherRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}