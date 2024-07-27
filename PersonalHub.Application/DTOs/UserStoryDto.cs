using PersonalHub.Domain.Contracts;
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
    public record CreateUserStoryDto(
        [Required][StringLength(75)] string Name,
        string? Description
    );

    public record UserStoryDto(
        UserStoryId Id,
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
}