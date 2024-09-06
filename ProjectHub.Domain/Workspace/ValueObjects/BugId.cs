using ProjectHub.Domain.Common.Contracts;

namespace ProjectHub.Domain.Workspace.ValueObjects;

public readonly record struct BugId(Guid Id) : IEntityId
{
    public static BugId Empty => new(Guid.Empty);
    public static BugId NewEntityId() => new(Guid.NewGuid());
}
