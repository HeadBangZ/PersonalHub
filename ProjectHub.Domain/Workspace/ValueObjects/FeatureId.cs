using ProjectHub.Domain.Common.Contracts;

namespace ProjectHub.Domain.Workspace.ValueObjects;

public readonly record struct FeatureId(Guid Id) : IEntityId
{
    public static FeatureId Empty => new(Guid.Empty);
    public static FeatureId NewEntityId() => new(Guid.NewGuid());
}
