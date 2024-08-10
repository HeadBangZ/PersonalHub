using PersonalHub.Domain.Workspace.Entities;
using PersonalHub.Domain.Contracts;
using PersonalHub.Infrastructure.Repositories.GenericRepositories;
using PersonalHub.Infrastructure.Data.Contexts;

namespace PersonalHub.Infrastructure.Repositories;

public class FeatureRepository : GenericRepository<Feature>, IFeatureRepository
{
    private readonly PersonalHubDbContext _context;

    public FeatureRepository(PersonalHubDbContext context) : base(context)
    {
        _context = context;
    }
}
