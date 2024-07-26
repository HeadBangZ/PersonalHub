using PersonalHub.Domain.Entities;
using PersonalHub.Domain.Enums;
using PersonalHub.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalHub.Domain.Contracts
{
    public interface IUserStoryItem<T>
    {
        T Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        ItemType Type { get; set; }
        int Priority { get; set; }
        bool IsCompleted { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
        public UserStoryId UserStoryId { get; set; }
        public UserStory UserStory { get; set; }
    }
}
