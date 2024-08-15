using PersonalHub.Domain.Common.Models;
using PersonalHub.Domain.Workspace.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonalHub.Domain.Workspace.Entities;

public sealed class Feature : BaseEntity
{
    public Guid Id { get; private init; } = new();

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

    public Feature(Guid id, string name, string? description, List<Activity> activities, Priority importance, bool isCompleted, DateTime createdAt, DateTime? updatedAt)
    {
        Id = id;
        Name = name;
        Description = description;
        Activities = activities;
        Importance = importance;
        IsCompleted = isCompleted;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}
