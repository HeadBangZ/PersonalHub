using PersonalHub.Domain.Common.Models;
using PersonalHub.Domain.Workspace.ValueObjects;

namespace PersonalHub.Domain.Workspace.Entities;

public sealed class Space : BaseEntity
{
    public SpaceId Id { get; private init; } = SpaceId.NewEntityId();
    public required string SpaceName { get; set; }
    public required string SpaceDescription { get; set; }
}