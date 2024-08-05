using PersonalHub.Application.DTOs;
using PersonalHub.Domain.Entities;
using PersonalHub.Domain.Enums;
using PersonalHub.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalHub.Application.Extensions
{
    public static class StoryItemExtensions
    {
        public static StoryItemDto ToStoryItemDto(this StoryItem storyItem)
        {
            return new StoryItemDto(
                storyItem.Id,
                storyItem.Name,
                storyItem.Description,
                storyItem.Type,
                storyItem.Priority,
                storyItem.IsCompleted,
                storyItem.CreatedAt,
                storyItem.UpdatedAt,
                storyItem.UserStoryId,
                storyItem.UserStory
            );
        }

        public static StoryItem ToStoryItem(this StoryItemDto storyItemDto)
        {
            return new StoryItem(
                storyItemDto.Id,
                storyItemDto.Name,
                storyItemDto.Description,
                storyItemDto.Type,
                storyItemDto.Priority,
                storyItemDto.IsCompleted,
                storyItemDto.CreatedAt,
                storyItemDto.UpdatedAt,
                storyItemDto.UserStoryId
            );
        }

        public static StoryItem ToStoryItem(this CreateStoryItemDto createStoryItemDto)
        {
            return new StoryItem(
                createStoryItemDto.Name,
                createStoryItemDto.Description,
                createStoryItemDto.Type ?? ItemType.Task,
                createStoryItemDto.Priority ?? Priority.None,
                createStoryItemDto.UserStoryId
            );
        }
    }
}
