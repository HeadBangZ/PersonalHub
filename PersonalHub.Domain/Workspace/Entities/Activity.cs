using PersonalHub.Domain.Workspace.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonalHub.Domain.Workspace.Entities;

public class Activity
{
    public Guid Id { get; private set; } = new();

    [Required]
    public Guid FeatureId { get; set; }

    [Required]
    [StringLength(75)]
    public string Name { get; set; }

    public string Description { get; set; }

    [Required]
    public ActivityType ActivityItemType { get; set; } = ActivityType.Task;

    [Required]
    public Priority ActivityPriority { get; set; } = Priority.None;

    public bool IsCompleted { get; set; } = false;

    [Required]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime? UpdatedAt { get; set; }
}
