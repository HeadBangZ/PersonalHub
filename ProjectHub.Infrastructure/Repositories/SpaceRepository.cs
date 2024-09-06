using PersonalHub.Domain.Workspace.Entities;
using PersonalHub.Domain.Contracts;
using PersonalHub.Infrastructure.Repositories.GenericRepositories;
using PersonalHub.Infrastructure.Data.Contexts;
using PersonalHub.Domain.Workspace.ValueObjects;

namespace PersonalHub.Infrastructure.Repositories;

public class SpaceRepository : GenericRepository<Space, SpaceId>, ISpaceRepository
{
    private readonly PersonalHubDbContext _context;

    public SpaceRepository(PersonalHubDbContext context) : base(context)
    {
        _context = context;
    }
}
