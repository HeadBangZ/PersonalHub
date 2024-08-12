using PersonalHub.Domain.Common.Models;
using PersonalHub.Domain.Workspace.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonalHub.Domain.Workspace.Entities;

public class Activity : BaseEntity
{
    public Guid Id { get; private set; } = new();

    public Guid FeatureId { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public bool IsCompleted { get; set; } = false;
}
