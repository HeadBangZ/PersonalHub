using ProjectHub.Domain.Common.Entities;
using ProjectHub.Domain.Common.ValueObjects;
using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Domain.Workspace.ValueObjects;

namespace ProjectHub.Domain.Workspace.RelationShips;

public class EpicTag
{
    public Epic Epic { get; set; }
    public EpicId EpicId { get; set; }

    public Tag Tag { get; set; }
    public TagId TagId { get; set; }
}
