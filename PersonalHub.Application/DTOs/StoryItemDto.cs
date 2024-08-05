using PersonalHub.Domain.Entities;
using PersonalHub.Domain.Enums;
using PersonalHub.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalHub.Application.DTOs
{
    public record CreateStoryItemDto(
        [Required][StringLength(75)] string Name,
        string? Description,
        UserStoryId UserStoryId,
        ItemType? Type = null,
        Priority? Priority = null
    );

    public record StoryItemDto(
        StoryItemId Id,
        string Name,
        string? Description,
        ItemType Type,
        Priority Priority,
        bool IsCompleted,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        UserStoryId UserStoryId,
        UserStory UserStory
    );
}