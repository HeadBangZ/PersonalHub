namespace ProjectHub.Domain.Common.ValueObjects;

public readonly record struct TagId(Guid Id)
{
    public static TagId Empty => new(Guid.Empty);
    public static TagId NewEntityId() => new(Guid.NewGuid());
}
