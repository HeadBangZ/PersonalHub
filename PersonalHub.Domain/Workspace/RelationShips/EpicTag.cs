using PersonalHub.Domain.Shared.Entities;
using PersonalHub.Domain.Shared.ValueObjects;
using PersonalHub.Domain.Workspace.Entities;
using PersonalHub.Domain.Workspace.ValueObjects;

namespace PersonalHub.Domain.Workspace.RelationShips;

public class EpicTag
{
    public Epic Epic { get; set; }
    public EpicId EpicId { get; set; }

    public Tag Tag { get; set; }
    public TagId TagId { get; set; }
}
