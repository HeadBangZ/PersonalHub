using PersonalHub.Application.Contracts;
using PersonalHub.Application.Contracts.Repositories;
using PersonalHub.Application.DTOs;
using PersonalHub.Application.Extensions;
using PersonalHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalHub.Application.Services
{
    public class StoryItemService : IStoryItemService
    {
        private readonly IStoryItemRepository _storyItemRepository;

        public StoryItemService(IStoryItemRepository storyItemRepository)
        {
            _storyItemRepository = storyItemRepository;
        }

        public async Task<StoryItemDto> AddStoryItem(CreateStoryItemDto storyItemDto)
        {
            var storyItem = storyItemDto.ToStoryItem();

            await _storyItemRepository.AddAsync(storyItem);
            return storyItem.ToStoryItemDto();
        }
    }
}
