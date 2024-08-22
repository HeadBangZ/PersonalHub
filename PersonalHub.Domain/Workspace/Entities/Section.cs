using PersonalHub.Domain.Common.Models;
using PersonalHub.Domain.Workspace.ValueObjects;

namespace PersonalHub.Domain.Workspace.Entities;

public sealed class Section : BaseEntity
{
    public SectionId Id { get; private init; } = SectionId.NewEntityId();

    public required SpaceId SpaceId { get; set; }

    public IEnumerable<Epic> Epics { get; set; } = Enumerable.Empty<Epic>();

    public required string Title { get; set; }

    public required string Description { get; set; }
}
