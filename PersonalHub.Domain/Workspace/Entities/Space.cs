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

    public Space() { }

    public Space(string name, string description)
    {
        Name = name;
        Description = description;
        CreatedAt = DateTime.Now;
    }

    public Space(Guid id, string name, string description, ProgressStatus status, IReadOnlyCollection<Section> sections)
    {
        Id = new SpaceId(id);
        Name = name;
        Description = description;
        Sections = new List<Section>();
        Status = status;
    }
}
