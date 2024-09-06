using ProjectHub.Domain.Common.Models;
using ProjectHub.Domain.Workspace.ValueObjects;

namespace ProjectHub.Domain.Workspace.Entities;

public sealed class Activity : BaseEntity
{
    public ActivityId Id { get; private init; } = ActivityId.NewEntityId();

    public FeatureId FeatureId { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public bool IsCompleted { get; set; } = false;
}
