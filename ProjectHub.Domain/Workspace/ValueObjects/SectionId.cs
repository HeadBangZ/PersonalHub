namespace PersonalHub.Domain.Workspace.ValueObjects;

public readonly record struct SectionId(Guid Id)
{
    public static SectionId Empty => new(Guid.Empty);
    public static SectionId NewEntityId() => new(Guid.NewGuid());
}
