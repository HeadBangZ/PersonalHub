using PersonalHub.Domain.Contracts;
using PersonalHub.Domain.Enums;
using PersonalHub.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace PersonalHub.Domain.Entities
{
    public class StoryItem
    {
        public StoryItemId Id { get; private set; } = new StoryItemId();

        [Required]
        [StringLength(75)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public ItemType Type { get; set; } = ItemType.Task;

        [Required]
        public UserStoryPriority Priority { get; set; } = UserStoryPriority.None;

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
    }
}
