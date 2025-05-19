using FastEndpoints;

using FluentValidation;

namespace BookTracker.Api.Features.Authors.Create;

public class CreateAuthorRequestValidator : Validator<CreateAuthorRequest>
{
    public CreateAuthorRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}


