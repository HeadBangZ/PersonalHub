using ProjectHub.Domain.Common.Models;
using ProjectHub.Domain.Workspace.Enums;
using ProjectHub.Domain.Workspace.ValueObjects;
using System.Xml.Linq;

namespace ProjectHub.Domain.Workspace.Entities;

public sealed class Space : BaseEntity
{
    public SpaceId Id { get; private init; } = SpaceId.NewEntityId();

    public string Name { get; set; }

    public string Description { get; set; }

    // TODO: Maybe remove sections
    public IReadOnlyCollection<Section> Sections { get; set; } = new List<Section>();

    public ProgressState State { get; set; } = ProgressState.NotStarted;

    public Space() { }

    public Space(string name, string description)
    {
        Name = name;
        Description = description;
        CreatedAt = DateTime.Now;
    }

    public Space(Guid id, string name, string description, ProgressState state, IReadOnlyCollection<Section> sections)
    {
        Id = new SpaceId(id);
        Name = name;
        Description = description;
        Sections = new List<Section>();
        State = state;
    }
}
