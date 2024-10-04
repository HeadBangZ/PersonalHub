using Microsoft.EntityFrameworkCore;
using ProjectHub.Domain.Contracts;
using ProjectHub.Infrastructure.Data.Contexts;

namespace ProjectHub.Infrastructure.Services;

public class EntityExistenceVerfifier<T, TId> : IEntityExistenceVerfifier<T, TId> where T : class
{
    private readonly ProjectHubDbContext _context;

    public EntityExistenceVerfifier(ProjectHubDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistsAsync(TId entityId)
    {
        return await _context.Set<T>().AnyAsync(e => EF.Property<TId>(e, "Id").Equals(entityId));
    }
}
