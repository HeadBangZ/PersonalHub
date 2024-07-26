using PersonalHub.Application.DTOs;
using PersonalHub.Domain.Entities;
using PersonalHub.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalHub.Application.Extensions
{
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

        public static UserStory ToUserStory(this UpdateUserStoryDto userStoryDto, UserStory existingUserStory)
        {
            return new UserStory(
                existingUserStory.Id,
                userStoryDto.Name,
                userStoryDto.Description,
                existingUserStory.CreatedAt,
                DateTime.Now
            );
        }
    }
}


