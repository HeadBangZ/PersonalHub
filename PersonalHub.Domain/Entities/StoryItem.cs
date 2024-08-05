using PersonalHub.Domain.Contracts;
using PersonalHub.Domain.Enums;
using PersonalHub.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace PersonalHub.Domain.Entities
{
    public class StoryItem
    {
        public StoryItemId Id { get; private set; } = StoryItemId.NewStoryItemId;

        [Required]
        [StringLength(75)]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public ItemType Type { get; set; } = ItemType.Task;

        [Required]
        public Priority Priority { get; set; } = Priority.None;

        public bool IsCompleted { get; set; } = false;

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? UpdatedAt { get; set; }

        [Required]
        public UserStoryId UserStoryId { get; set; }

        public UserStory? UserStory { get; set; }

        private StoryItem()
        {
            IsCompleted = false;
            Type = ItemType.Task;
            Priority = Priority.None;
        }

        public StoryItem(StoryItemId id, string name, string? description, ItemType type, Priority priority, bool isCompleted, DateTime createdAt, DateTime? updatedAt, UserStoryId userStoryId) : this()
        {
            Id = id;
            Name = name;
            Description = description;
            Type = type;
            Priority = priority;
            IsCompleted = isCompleted;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            UserStoryId = userStoryId;
        }

        public StoryItem(string name, string? description, ItemType type, Priority priority, UserStoryId userStoryId) : this()
        {
            Name = name;
            Description = description;
            Type = type;
            Priority = priority;
            UserStoryId = userStoryId;
        }
    }
}
