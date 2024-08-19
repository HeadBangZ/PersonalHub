namespace PersonalHub.Domain.Workspace.ValueObjects;

public readonly record struct SpaceId(Guid Id)
{
    public static SpaceId Empty => new(Guid.Empty);
    public static SpaceId NewEntityId() => new(Guid.NewGuid());
}
