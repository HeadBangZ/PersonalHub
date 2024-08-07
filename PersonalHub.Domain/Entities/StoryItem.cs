using PersonalHub.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonalHub.Domain.Entities;

public class StoryItem
{
    public Guid Id { get; private set; } = new();

    [Required]
    public Guid UserStoryId { get; set; }

    [Required]
    [StringLength(75)]
    public string Name { get; set; }

    public string Description { get; set; }

    [Required]
    public ItemType StoryItemType { get; set; } = ItemType.Task;

    [Required]
    public Priority StoryItemPriority { get; set; } = Priority.None;

    public bool IsCompleted { get; set; } = false;

    [Required]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime? UpdatedAt { get; set; }
}
