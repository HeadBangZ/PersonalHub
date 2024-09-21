using FluentValidation;
using ProjectHub.Application.DTOs.SpaceDtos;

namespace ProjectHub.Api.Validators.SpaceValidators;

public class CreateSpaceValidator : AbstractValidator<CreateSpaceDtoRequest>
{
    public CreateSpaceValidator()
    {
        RuleFor(space => space.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(75)
            .WithMessage("Name is required");
    }
}
