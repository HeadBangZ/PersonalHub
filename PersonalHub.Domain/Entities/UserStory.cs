using PersonalHub.Domain.Contracts;
using PersonalHub.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;

namespace PersonalHub.Domain.Entities
{
    public class UserStory
    {
        public UserStoryId Id { get; private set; } = UserStoryId.NewUserStoryId;

        [Required]
        [StringLength(75)]
        public string Name { get; set; }

        public string? Description { get; set; }

        public List<StoryItem> Items { get; private set; } = new List<StoryItem>();

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM-yyyy}")]
        public DateTime CreatedAt { get; set; }


        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM-yyyy}")]
        public DateTime? UpdatedAt { get; set; }


        public UserStory(string name, string? description)
        {
            Name = name;
            Description = description;
            CreatedAt = DateTime.Now;
        }

        public UserStory(UserStoryId id, string name, string? description, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Name = name;
            Description = description;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public UserStory(UserStoryId id, string name, string? description, List<StoryItem> items, DateTime createdAt, DateTime? updatedAt)
        {
            Id = id;
            Name = name;
            Description = description;
            Items = items;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
