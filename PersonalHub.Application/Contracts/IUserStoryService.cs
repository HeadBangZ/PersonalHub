using PersonalHub.Application.DTOs;
namespace PersonalHub.Application.Contracts;

public interface IUserStoryService
{
    Task<UserStoryDto> AddUserStory(CreateUserStoryDto userStoryDto);
    Task<UserStoryDto?> GetUserStory(string id);
    Task<List<UserStoryDto>> GetAllUserStories();
    Task UpdateUserStory(string id, UpdateUserStoryDto userStoryDto);
    Task DeleteUserStory(string id);
    Task<bool> UserStoryExist(string id);
}
