using PersonalHub.Domain.Common.Models;
using PersonalHub.Domain.Workspace.ValueObjects;

namespace PersonalHub.Domain.Workspace.Entities;

public sealed class Epic : BaseEntity
{
    public EpicId Id { get; private init; } = EpicId.NewEntityId();
    public required Guid SectionId { get; set; }
    public required string EpicName { get; set; }
    public required string EpicDescription { get; set; }
    public bool IsCompleted { get; set; } = false;

}
