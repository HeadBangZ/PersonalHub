using PersonalHub.Application.DTOs;
using PersonalHub.Domain.Entities;

namespace PersonalHub.Application.Extensions;

public static class UserStoryExtensions
{
    public static UserStoryDto ToUserStoryDto(this UserStory userStory)
    {
        return new UserStoryDto(
           userStory.Id,
           userStory.Name,
           userStory.Description,
           userStory.Items,
           userStory.CreatedAt,
           userStory.UpdatedAt
        );
    }

    public static UserStory ToUserStory(this UserStoryDto userStoryDto)
    {
        return new UserStory(
           userStoryDto.Id,
           userStoryDto.Name,
           userStoryDto.Description,
           userStoryDto.Items,
           userStoryDto.CreatedAt,
           userStoryDto.UpdatedAt
        );
    }

    public static UserStory ToUserStory(this CreateUserStoryDto userStoryDto)
    {
        return new UserStory(
           userStoryDto.Name,
           userStoryDto.Description
        );
    }
}


