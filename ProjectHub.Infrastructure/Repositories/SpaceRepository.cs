﻿using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Domain.Contracts;
using ProjectHub.Infrastructure.Repositories.GenericRepositories;
using ProjectHub.Infrastructure.Data.Contexts;
using ProjectHub.Domain.Workspace.ValueObjects;

namespace ProjectHub.Infrastructure.Repositories;

public sealed class SpaceRepository : GenericRepository<Space, SpaceId>, ISpaceRepository
{
    private readonly ProjectHubDbContext _context;

    public SpaceRepository(ProjectHubDbContext context) : base(context)
    {
        _context = context;
    }
}
