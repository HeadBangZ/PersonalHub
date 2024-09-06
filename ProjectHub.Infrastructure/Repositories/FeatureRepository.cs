using PersonalHub.Domain.Workspace.Entities;
using PersonalHub.Domain.Contracts;
using PersonalHub.Infrastructure.Repositories.GenericRepositories;
using PersonalHub.Infrastructure.Data.Contexts;
using PersonalHub.Domain.Workspace.ValueObjects;

namespace PersonalHub.Infrastructure.Repositories;

public class FeatureRepository : GenericRepository<Feature, FeatureId>, IFeatureRepository
{
    private readonly PersonalHubDbContext _context;

    public FeatureRepository(PersonalHubDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Feature?> GetFeature(FeatureId id)
    {
        return await _context.Set<Feature>().FindAsync(id);
    }
}
