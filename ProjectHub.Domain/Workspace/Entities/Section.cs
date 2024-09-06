using ProjectHub.Domain.Common.Models;
using ProjectHub.Domain.Workspace.ValueObjects;

namespace ProjectHub.Domain.Workspace.Entities;

public sealed class Section : BaseEntity
{
    public SectionId Id { get; private init; } = SectionId.NewEntityId();

    public SpaceId SpaceId { get; set; }

    public IReadOnlyCollection<Epic> Epics { get; set; } = new List<Epic>();

    public string Name { get; set; }

    public string Description { get; set; }
}
