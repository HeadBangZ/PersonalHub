using PersonalHub.Application.Contracts.Repositories;
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
    public interface IStoryItemService
    {
        Task<StoryItemDto> AddStoryItem(CreateStoryItemDto storyItemDto);
    }
}
