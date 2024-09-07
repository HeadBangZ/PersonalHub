using ProjectHub.Domain.Common.Models;
using ProjectHub.Domain.Workspace.Enums;
using ProjectHub.Domain.Workspace.ValueObjects;

namespace ProjectHub.Domain.Workspace.Entities;

public sealed class Bug : BaseEntity
{
    public BugId Id { get; private init; } = BugId.NewEntityId();

    public EpicId EpicId { get; set; }

    public string Issue { get; set; }

    public string? Description { get; set; }

    public Priority Severity { get; set; } = Priority.None;

    // TODO: Change this for a valueObject
    public bool IsCompleted { get; set; } = false;
}
