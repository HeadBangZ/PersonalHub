using FluentValidation;
using ProjectHub.Application.DTOs.SpaceDtos;

namespace ProjectHub.Api.Validators.SpaceValidators;

public class UpdateSpaceValidator : AbstractValidator<UpdateSpaceDtoRequest>
{
    public UpdateSpaceValidator()
    {
        RuleFor(space => space.Name)
            .MinimumLength(2)
            .MaximumLength(75)
            .When(space => !string.IsNullOrWhiteSpace(space.Name))
            .WithMessage("The name must be betweeb 2 - 75 characters long");

        RuleFor(space => space.State)
            .IsInEnum()
            .WithMessage("Invalid State provided.");
    }
}
