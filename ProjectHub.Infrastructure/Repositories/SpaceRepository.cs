﻿using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Domain.Contracts;
using ProjectHub.Infrastructure.Repositories.GenericRepositories;
using ProjectHub.Infrastructure.Data.Contexts;
using ProjectHub.Domain.Workspace.ValueObjects;

namespace ProjectHub.Infrastructure.Repositories;

public sealed class SectionRepository : GenericRepository<Section, SectionId>, ISectionRepository
{
    private readonly ProjectHubDbContext _context;

    public SectionRepository(ProjectHubDbContext context) : base(context)
    {
        _context = context;
    }
}
