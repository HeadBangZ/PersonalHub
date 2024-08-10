using PersonalHub.Domain.Base.Entities;

namespace PersonalHub.Domain.Workspace.Entities;

public class Section : BaseEntity
{
    public Guid Id { get; private set; } = new();
    public required Guid SpaceId { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
}
