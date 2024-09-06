namespace ProjectHub.Domain.Workspace.ValueObjects;

public readonly record struct ActivityId(Guid Id)
{
    public static ActivityId Empty => new(Guid.Empty);
    public static ActivityId NewEntityId() => new(Guid.NewGuid());
}
