using PersonalHub.Domain.Common.Models;
using PersonalHub.Domain.Workspace.Enums;
using PersonalHub.Domain.Workspace.ValueObjects;
using System.Collections.ObjectModel;

namespace PersonalHub.Domain.Workspace.Entities;

public sealed class Feature : BaseEntity
{
    public Guid Id { get; private init; } = new();

    public EpicId EpicId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public IReadOnlyCollection<Activity> Activities { get; set; } = new List<Activity>();

    public Priority Importance { get; set; } = Priority.None;

    // TODO: Change this for a valueObject
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

    public Feature(Guid id, string name, string? description, IReadOnlyCollection<Activity> activities, Priority importance, bool isCompleted, DateTime createdAt, DateTime? updatedAt)
    {
        Id = id;
        Name = name;
        Description = description;
        Activities = activities;
        Importance = importance;
        IsCompleted = isCompleted;
        CreatedAt = createdAt;
        ModifiedAt = updatedAt;
    }
}
