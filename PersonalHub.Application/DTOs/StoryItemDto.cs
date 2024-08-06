using PersonalHub.Domain.Entities;
using PersonalHub.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonalHub.Application.DTOs;

public record CreateStoryItemDto(
    [Required][StringLength(75)] string Name,
    string? Description,
    Guid UserStoryId,
    ItemType? Type = null,
    Priority? Priority = null
);

public record StoryItemDto(
    Guid Id,
    string Name,
    string? Description,
    ItemType Type,
    Priority Priority,
    bool IsCompleted,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    Guid UserStoryId,
    UserStory UserStory
);