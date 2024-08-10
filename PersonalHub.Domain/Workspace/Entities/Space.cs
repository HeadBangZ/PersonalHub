using PersonalHub.Domain.Base.Entities;

namespace PersonalHub.Domain.Workspace.Entities;

public class Space : BaseEntity
{
    public Guid Id { get; private set; } = new();
    public required string SpaceName { get; set; }
    public required string SpaceDescription { get; set; }
}