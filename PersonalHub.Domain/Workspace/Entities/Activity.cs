using PersonalHub.Domain.Common.Models;
using PersonalHub.Domain.Workspace.ValueObjects;

namespace PersonalHub.Domain.Workspace.Entities;

public sealed class Activity : BaseEntity
{
    public ActivityId Id { get; private init; } = ActivityId.NewEntityId();

    public FeatureId FeatureId { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public bool IsCompleted { get; set; } = false;
}
