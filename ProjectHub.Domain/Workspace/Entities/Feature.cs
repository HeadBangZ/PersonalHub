using ProjectHub.Domain.Common.Models;
using ProjectHub.Domain.Workspace.Enums;
using ProjectHub.Domain.Workspace.ValueObjects;

namespace ProjectHub.Domain.Workspace.Entities;

public sealed class Feature : BaseEntity
{
    public FeatureId Id { get; private init; } = FeatureId.NewEntityId();

    public EpicId EpicId { get; private set; }

    public string Name { get; private set; }

    public string? Description { get; private set; }

    public IReadOnlyCollection<Activity> Activities { get; private set; } = new List<Activity>();

    public Priority Importance { get; private set; } = Priority.None;

    // TODO: Change this for a valueObject
    public bool IsCompleted { get; private set; } = false;

    public Feature()
    {

    }

    public Feature(Guid epicId, string name, string? description)
    {
        EpicId = new EpicId(epicId);
        Name = name;
        Description = description;
        CreatedAt = DateTime.Now;
    }

    public Feature(Guid epicId, string name, string? description, IReadOnlyCollection<Activity> activities, Priority importance, bool isCompleted)
    {
        EpicId = new EpicId(epicId);
        Name = name;
        Description = description;
        Activities = activities;
        Importance = importance;
        IsCompleted = isCompleted;
    }
}
