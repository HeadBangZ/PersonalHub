using ProjectHub.Application.DTOs.SpaceDtos;
using ProjectHub.Application.Utils;
using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Domain.Workspace.Enums;
using ProjectHub.Domain.Workspace.ValueObjects;
using ProjectHub.Infrastructure.Data.Contexts;
using ProjectHub.Infrastructure.Data.Seeders;
using ProjectHub.Infrastructure.Repositories;
using ProjectHub.Tests.Unit.Mocks;
using ProjectHub.Tests.Unit.Seeder;

namespace ProjectHub.Tests.Unit.Infrastructure.Repositories;

public class SpaceRepositoryTests : IAsyncLifetime
{
    private readonly SpaceRepository _spaceRepository;
    private readonly ProjectHubDbContext _context;

    public SpaceRepositoryTests()
    {
        _context = MockDbContextFactory.CreateDbContext();
        _spaceRepository = new SpaceRepository(_context);
    }

    public async Task InitializeAsync()
    {
        var spaces = SpaceTestData.SeedData();
        await _context.Spaces.AddRangeAsync(spaces);
        await _context.SaveChangesAsync();
    }

    public async Task DisposeAsync()
    {
        _context.Spaces.RemoveRange(_context.Spaces);
        await _context.SaveChangesAsync();
    }

    [Fact]
    public async Task GetAllAsync_Successfully()
    {
        var entities = await _spaceRepository.GetAllAsync();

        Assert.Equal(4, entities.Count);
        Assert.Equal("Space 1", entities[0].Name);
        Assert.Empty(entities[1].Sections);
        Assert.Equal(ProgressState.InProgress, entities[2].State);
        Assert.Equal("Description Space 4", entities[3].Description);
    }

    [Fact]
    public async Task GetById_Failed()
    {
        var result = await _spaceRepository.GetAsync(SpaceId.Empty);

        Assert.Null(result);
    }

    [Fact]
    public async Task GetById_Successfully()
    {
        var space = SpaceTestData.CreateData("Space X", "Description Space X");

        await _context.AddAsync(space);
        await _context.SaveChangesAsync();

        var result = await _spaceRepository.GetAsync(space.Id);

        Assert.NotNull(result);
        Assert.Equal(typeof(Space), result.GetType());
        Assert.NotEqual(Guid.Empty, result.Id.Id);
        Assert.Equal("Space X", result.Name);
        Assert.Equal("Description Space X", result.Description);
        Assert.Equal(ProgressState.NotStarted, result.State);
    }

    [Fact]
    public async Task Delete_Successfully()
    {
        var entities = await _spaceRepository.GetAllAsync();

        Assert.True(entities.Any());

        var id = entities.First().Id;
        await _spaceRepository.DeleteAsync(id);

        var updatedEntities = await _spaceRepository.GetAllAsync();

        Assert.Equal(entities.Count - 1, updatedEntities.Count);
        Assert.DoesNotContain(updatedEntities, e => e.Id == id);
    }

    [Fact]
    public async Task Update_Successfully()
    {
        var entities = await _spaceRepository.GetAllAsync();

        Assert.True(entities.Any());

        var entity = entities.First();
        var spaceId = entities.First().Id;

        var dto = new UpdateSpaceDtoRequest(spaceId.Id, "Hubba Bubba", "FizzBuzz", null, ProgressState.InProgress);

        var changes = DeltaFinder.GetChangedProperties(dto, entity);

        Assert.True(changes.Any());
        Assert.Equal(3, changes.Count);

        var properties = DeltaFinder.GetPropertyDictionary<Space>();

        entity.ApplyChanges<Space>(changes, properties);

        await _spaceRepository.UpdateAsync(entity);

        var updatedEntities = await _spaceRepository.GetAllAsync();

        Assert.Equal(entity.Name, updatedEntities.First().Name);
        Assert.Equal(entity.Description, updatedEntities.First().Description);
        Assert.Empty(updatedEntities.First().Sections);
        Assert.Equal(entity.State, updatedEntities.First().State);
    }
}
