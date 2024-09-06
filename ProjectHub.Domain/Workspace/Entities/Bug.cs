using PersonalHub.Domain.Common.Models;
using PersonalHub.Domain.Workspace.Enums;
using PersonalHub.Domain.Workspace.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace PersonalHub.Domain.Workspace.Entities;

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
