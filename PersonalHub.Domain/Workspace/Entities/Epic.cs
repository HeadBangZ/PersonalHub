using PersonalHub.Domain.Common.Models;
using PersonalHub.Domain.Workspace.Enums;
using PersonalHub.Domain.Workspace.ValueObjects;

namespace PersonalHub.Domain.Workspace.Entities;

public sealed class Epic : BaseEntity
{
    public EpicId Id { get; private init; } = EpicId.NewEntityId();

    //public required SectionId SectionId { get; set; }

    public required string AssignedToUserId { get; set; }

    public string? ReviewerUserId { get; set; }

    public required string Name { get; set; }

    public required string Description { get; set; }

    public bool IsCompleted { get; set; } = false;

    public IReadOnlyCollection<string> Tags { get; set; } = new List<string>(); // OPTIMIZE: Create a Tag Class

    public ProgressStatus Status { get; set; } = ProgressStatus.NotStarted;

    public double? EstimatedEffort { get; set; }

    public double? ActualEffort { get; set; }

    public bool IsArchived { get; set; } = false;

    public DateTime? ArchivedAt { get; set; }

    public IReadOnlyCollection<Feature> Features { get; set; } = new List<Feature>();

    public IReadOnlyCollection<Bug> Bugs { get; set; } = new List<Bug>();
}
