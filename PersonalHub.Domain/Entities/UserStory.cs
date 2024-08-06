using System.ComponentModel.DataAnnotations;

namespace PersonalHub.Domain.Entities;

public class UserStory
{
    public Guid Id { get; private set; } = new();

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

    public UserStory(Guid id, string name, string? description, DateTime createdAt, DateTime updatedAt)
    {
        Id = id;
        Name = name;
        Description = description;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public UserStory(Guid id, string name, string? description, List<StoryItem> items, DateTime createdAt, DateTime? updatedAt)
    {
        Id = id;
        Name = name;
        Description = description;
        Items = items;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}
