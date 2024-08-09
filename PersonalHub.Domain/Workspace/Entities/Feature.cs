using System.ComponentModel.DataAnnotations;

namespace PersonalHub.Domain.Workspace.Entities;

public class Feature
{
    public Guid Id { get; private set; } = new();

    [Required]
    [StringLength(75)]
    public string Name { get; set; }

    public string? Description { get; set; }

    public List<Activity> Activities { get; set; } = new List<Activity>();

    [Required]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:dd/MM-yyyy}")]
    public DateTime CreatedAt { get; set; }


    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:dd/MM-yyyy}")]
    public DateTime? UpdatedAt { get; set; }

    public Feature()
    {

    }
    public Feature(string name, string? description)
    {
        Name = name;
        Description = description;
        CreatedAt = DateTime.Now;
    }

    public Feature(Guid id, string name, string? description, DateTime createdAt, DateTime updatedAt)
    {
        Id = id;
        Name = name;
        Description = description;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public Feature(Guid id, string name, string? description, List<Activity> items, DateTime createdAt, DateTime? updatedAt)
    {
        Id = id;
        Name = name;
        Description = description;
        Activities = items;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}
