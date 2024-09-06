using ProjectHub.Domain.Common.Models;
using ProjectHub.Domain.Shared.Entities;
using ProjectHub.Domain.Workspace.Enums;
using ProjectHub.Domain.Workspace.RelationShips;
using ProjectHub.Domain.Workspace.ValueObjects;

namespace ProjectHub.Domain.Workspace.Entities;

public sealed class Epic : BaseEntity
{
    public EpicId Id { get; private init; } = EpicId.NewEntityId();

    public SectionId SectionId { get; set; }

    public string AssignedToUserId { get; set; }

    public string? ReviewerUserId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public bool IsCompleted { get; set; } = false;

    public IReadOnlyCollection<EpicTag> EpicTags { get; set; }

    public double? EstimatedEffort { get; set; }

    public double? ActualEffort { get; set; }

    public bool IsArchived { get; set; } = false;

    public DateTime? ArchivedAt { get; set; }

    public IReadOnlyCollection<Feature> Features { get; set; } = new List<Feature>();

    public IReadOnlyCollection<Bug> Bugs { get; set; } = new List<Bug>();
}
