using PersonalHub.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace PersonalHub.Application.DTOs;

public record CreateUserStoryDto(
    [Required][StringLength(75)] string Name,
    string? Description
);

public record UserStoryDto(
    Guid Id,
    string Name,
    string? Description,
    List<StoryItem> Items,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);

public record UpdateUserStoryDto(
    string? Name,
    string? Description
);