using PersonalHub.Domain.Common.Models;

namespace PersonalHub.Domain.Workspace.Entities;

public sealed class Section : BaseEntity
{
    public Guid Id { get; private init; } = new();
    public required Guid SpaceId { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
}
