using PersonalHub.Application.DTOs;
using PersonalHub.Domain.Entities;
using PersonalHub.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalHub.Application.Contracts
{
    public interface IUserStoryService
    {
        Task<UserStoryDto> AddUserStory(CreateUserStoryDto userStoryDto);
        Task<UserStoryDto?> GetUserStory(string id);
        Task<List<UserStoryDto>> GetAllUserStories();
        Task UpdateUserStory(string id, UpdateUserStoryDto userStoryDto);
        Task DeleteUserStory(string id);
        Task<bool> UserStoryExist(string id);
    }
}
