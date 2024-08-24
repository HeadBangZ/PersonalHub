using PersonalHub.Domain.Shared.ValueObjects;
using PersonalHub.Domain.Workspace.Entities;
using PersonalHub.Domain.Workspace.RelationShips;

namespace PersonalHub.Domain.Shared.Entities;

public class Tag
{
    public TagId Id { get; private init; } = TagId.NewEntityId();

    public string Name { get; set; }

    public string Color { get; set; }

    public IReadOnlyCollection<EpicTag> EpicTags { get; set; }
}
