namespace ProjectHub.Domain.User.ValueObjects;

public readonly record struct UserProfileId(Guid Id)
{
    public static UserProfileId Empty => new(Guid.Empty);
    public static UserProfileId NewEntityId() => new(Guid.NewGuid());
}
