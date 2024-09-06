using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Domain.Workspace.ValueObjects;

namespace ProjectHub.Domain.Contracts;

public interface IFeatureRepository : IGenericRepository<Feature, FeatureId>
{
}
