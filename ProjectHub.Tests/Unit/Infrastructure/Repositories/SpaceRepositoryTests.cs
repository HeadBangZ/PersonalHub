using Microsoft.EntityFrameworkCore;
using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Domain.Workspace.Enums;
using ProjectHub.Domain.Workspace.ValueObjects;
using ProjectHub.Infrastructure.Data.Contexts;
using ProjectHub.Infrastructure.Repositories;
using ProjectHub.Tests.Unit.Mocks;
using System.ComponentModel.DataAnnotations;

namespace ProjectHub.Tests.Unit.Infrastructure.Repositories
{
    public class SpaceRepositoryTests : IAsyncLifetime
    {
        private readonly SpaceRepository _spaceRepository;
        private readonly ProjectHubDbContext _context;

        public SpaceRepositoryTests()
        {
            _context = MockDbContextFactory.CreateDbContext();
            _spaceRepository = new SpaceRepository(_context);
        }

        private async Task SeedDataAsync()
        {
            var spaces = new List<Space>()
            {
                new Space("Space 1", "Description Space 1", ProgressState.Completed, new List<Section>()),
                new Space("Space 2", "Description Space 2", ProgressState.NotStarted, new List<Section>()),
                new Space("Space 3", "Description Space 3", ProgressState.InProgress, new List<Section>()),
                new Space("Space 4", "Description Space 4", ProgressState.NotStarted, new List<Section>()),
            };

            await _context.Spaces.AddRangeAsync(spaces);
            await _context.SaveChangesAsync();
        }

        public async Task InitializeAsync()
        {
            await SeedDataAsync();
        }

        public async Task DisposeAsync()
        {
            _context.Spaces.RemoveRange(_context.Spaces);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task GetAllAsync_Successfully()
        {
            var result = await _spaceRepository.GetAllAsync();

            Assert.Equal(4, result.Count);
            Assert.Equal("Space 1", result[0].Name);
            Assert.Empty(result[1].Sections);
            Assert.Equal(ProgressState.InProgress, result[2].State);
            Assert.Equal("Description Space 4", result[3].Description);
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
            var space = new Space("Space X", "Description Space X");

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
    }
}
