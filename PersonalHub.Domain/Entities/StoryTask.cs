using PersonalHub.Domain.Contracts;
using PersonalHub.Domain.Enums;
using PersonalHub.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace PersonalHub.Domain.Entities
{
    public class StoryTask
    {
        public StoryTaskId Id { get; set; }
        [Required]
        [StringLength(75)]
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType Type { get; set; }
        public int Priority { get; set; }
        public bool IsCompleted { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? UpdatedAt { get; set; }
        [Required]
        public UserStoryId UserStoryId { get; set; }
        public UserStory UserStory { get; set; }
    }
}
