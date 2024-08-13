using PersonalHub.Domain.Common.Models;

namespace PersonalHub.Domain.Workspace.Entities;

public sealed class Epic : BaseEntity
{
    public Guid Id { get; private init; } = new();
    public required Guid SectionId { get; set; }
    public required string EpicName { get; set; }
    public required string EpicDescription { get; set; }
    public bool IsCompleted { get; set; } = false;

}
