using PersonalHub.Domain.Workspace.Entities;
using PersonalHub.Domain.Workspace.ValueObjects;

namespace PersonalHub.Domain.Contracts;

public interface IFeatureRepository : IGenericRepository<Feature, FeatureId>
{
}
