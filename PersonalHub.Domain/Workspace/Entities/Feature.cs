using PersonalHub.Domain.Base.Entities;
using PersonalHub.Domain.Workspace.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonalHub.Domain.Workspace.Entities;

public class Feature : BaseEntity
{
    public Guid Id { get; private set; } = new();

    public string Name { get; set; }

    public string? Description { get; set; }

    public List<Activity> Activities { get; set; } = new List<Activity>();

    public Priority Importance { get; set; } = Priority.None;

    public bool IsCompleted { get; set; } = false;

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
