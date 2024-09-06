namespace ProjectHub.Domain.Workspace.ValueObjects;

public readonly record struct EpicId(Guid Id)
{
    public static EpicId Empty => new(Guid.Empty);
    public static EpicId NewEntityId() => new(Guid.NewGuid());
}
