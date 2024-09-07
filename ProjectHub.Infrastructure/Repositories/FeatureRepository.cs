using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Domain.Contracts;
using ProjectHub.Infrastructure.Repositories.GenericRepositories;
using ProjectHub.Infrastructure.Data.Contexts;
using ProjectHub.Domain.Workspace.ValueObjects;

namespace ProjectHub.Infrastructure.Repositories;

public sealed class FeatureRepository : GenericRepository<Feature, FeatureId>, IFeatureRepository
{
    private readonly ProjectHubDbContext _context;

    public FeatureRepository(ProjectHubDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Feature?> GetFeature(FeatureId id)
    {
        return await _context.Set<Feature>().FindAsync(id);
    }
}
