using PersonalHub.Application.Contracts;
using PersonalHub.Application.Contracts.Repositories;
using PersonalHub.Application.DTOs;
using PersonalHub.Application.Extensions;

namespace PersonalHub.Application.Services;

public class UserStoryService : IUserStoryService
{
    private readonly IUserStoryRepository _userStoryRepository;
    public UserStoryService(IUserStoryRepository userStoryRepository)
    {
        _userStoryRepository = userStoryRepository;
    }

    public async Task<UserStoryDto> AddUserStory(CreateUserStoryDto userStoryDto)
    {
        var userStory = userStoryDto.ToUserStory();

        await _userStoryRepository.AddAsync(userStory);
        return userStory.ToUserStoryDto();
    }

    public async Task<UserStoryDto?> GetUserStory(string id)
    {
        var userStoryId = Guid.Parse(id);
        var userStory = await _userStoryRepository.GetAsync(userStoryId);

        if (userStory == null)
        {
            return null;
        }

        var userStoryDto = userStory.ToUserStoryDto();

        return userStoryDto;
    }

    public async Task<List<UserStoryDto>> GetAllUserStories()
    {
        var userStoryDtos = new List<UserStoryDto>();
        var userStories = await _userStoryRepository.GetAllAsync();

        foreach (var userStory in userStories)
        {
            userStoryDtos.Add(userStory.ToUserStoryDto());
        }
        return userStoryDtos;
    }

    public async Task DeleteUserStory(string id)
    {
        var userStoryId = Guid.Parse(id);

        await _userStoryRepository.DeleteAsync(userStoryId);
    }

    public async Task<bool> UserStoryExist(string id)
    {
        var userStoryId = Guid.Parse(id);
        return await _userStoryRepository.Exists(userStoryId);
    }

    public async Task UpdateUserStory(string id, UpdateUserStoryDto userStoryDto)
    {
        var userStoryId = Guid.Parse(id);
        var userStory = await _userStoryRepository.GetAsync(userStoryId);

        if (userStory == null)
        {
            return;
        }

        if (!string.IsNullOrEmpty(userStoryDto.Name))
        {
            userStory.Name = userStoryDto.Name;
        }

        if (!string.IsNullOrEmpty(userStoryDto.Description))
        {
            userStory.Description = userStoryDto.Description;
        }

        userStory.UpdatedAt = DateTime.UtcNow;

        await _userStoryRepository.UpdateAsync(userStory);
    }
}
