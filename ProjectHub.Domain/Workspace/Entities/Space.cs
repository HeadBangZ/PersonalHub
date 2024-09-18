using ProjectHub.Domain.Common.Models;
using ProjectHub.Domain.Workspace.Enums;
using ProjectHub.Domain.Workspace.ValueObjects;

namespace ProjectHub.Domain.Workspace.Entities;

public sealed class Space : BaseEntity
{
    public SpaceId Id { get; private init; } = SpaceId.NewEntityId();

    public string Name { get; private set; }

    public string Description { get; private set; }

    public IReadOnlyCollection<Section> Sections { get; private set; } = new List<Section>();

    public ProgressState State { get; private set; } = ProgressState.NotStarted;

    public Space(string name, string description)
    {
        Name = name;
        Description = description;
        CreatedAt = DateTime.Now;
    }

    public Space(string name, string description, ProgressState state, IReadOnlyCollection<Section> sections)
    {
        Name = name;
        Description = description;
        Sections = sections ?? new List<Section>();
        State = state;
    }
}
