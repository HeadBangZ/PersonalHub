using FluentValidation;
using ProjectHub.Application.DTOs.SectionDtos;

namespace ProjectHub.Api.Validators.SectionValidators;

public class CreateSectionValidator : AbstractValidator<CreateSectionDtoRequest>
{
    public CreateSectionValidator()
    {
        RuleFor(section => section.SpaceId)
            .NotEmpty()
            .Must(BeValidGuid)
            .WithMessage("SpaceId is required");

        RuleFor(section => section.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(75)
            .WithMessage("Name is required");
    }

    private bool BeValidGuid(Guid spaceId)
    {
        return Guid.TryParse(spaceId.ToString(), out _);
    }
}
