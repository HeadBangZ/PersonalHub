using PersonalHub.Domain.Common.Models;
using PersonalHub.Domain.Workspace.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonalHub.Domain.Workspace.Entities;

public class Bug : BaseEntity
{
    public Guid Id { get; private set; } = new();

    public string Issue { get; set; }

    public string? Description { get; set; }

    public Priority Severity { get; set; } = Priority.None;

    public bool IsCompleted { get; set; } = false;
}
