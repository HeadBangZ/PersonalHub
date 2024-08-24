using PersonalHub.Domain.Common.Models;
using PersonalHub.Domain.Workspace.Enums;
using PersonalHub.Domain.Workspace.ValueObjects;

namespace PersonalHub.Domain.Workspace.Entities;

public sealed class Space : BaseEntity
{
    public SpaceId Id { get; private init; } = SpaceId.NewEntityId();

    public string Name { get; set; }

    public string Description { get; set; }

    public IReadOnlyCollection<Section> Sections { get; set; } = new List<Section>();

    public ProgressStatus Status { get; set; } = ProgressStatus.NotStarted;
}