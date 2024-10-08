﻿using Microsoft.EntityFrameworkCore;
using ProjectHub.Domain.Contracts;
using ProjectHub.Infrastructure.Data.Contexts;

namespace ProjectHub.Infrastructure.Repositories.GenericRepositories;

public class GenericRepository<T, TId> : IGenericRepository<T, TId> where T : class where TId : struct
{
    private readonly ProjectHubDbContext _context;

    public GenericRepository(ProjectHubDbContext context)
    {
        _context = context;
    }

    public async Task<T> AddAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(TId id)
    {
        var entity = await GetAsync(id);
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync()
    {
        IQueryable<T> query = _context.Set<T>();

        var navigationProperties = _context.Model.FindEntityType(typeof(T))
            .GetNavigations()
            .Select(n => n.Name);

        foreach (var prop in navigationProperties)
        {
            query = query.Include(prop);
        }

        return await query.ToListAsync();
    }

    public async Task<T?> GetAsync(TId id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }
}
