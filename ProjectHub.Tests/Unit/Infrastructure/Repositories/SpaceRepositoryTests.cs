using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Domain.Workspace.Enums;
using ProjectHub.Infrastructure.Data.Contexts;
using ProjectHub.Infrastructure.Repositories;

namespace ProjectHub.Tests.Unit.Infrastructure.Repositories
{
    public class SpaceRepositoryTests
    {
        private readonly SpaceRepository _spaceRepository;
        private readonly ProjectHubDbContext _context;

        public SpaceRepositoryTests()
        {
            var mockConfiguration = Substitute.For<IConfiguration>();

            var options = new DbContextOptionsBuilder<ProjectHubDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ProjectHubDbContext(options, mockConfiguration);

            _spaceRepository = new SpaceRepository(_context);
        }

        private static List<Space> GetTestSpaces()
        {
            var spaces = new List<Space>()
            {
                new Space("Space 1", "Description Space 1", ProgressState.Completed, new List<Section>()),
                new Space("Space 2", "Description Space 2", ProgressState.NotStarted, new List<Section>()),
                new Space("Space 3", "Description Space 3", ProgressState.InProgress, new List<Section>()),
                new Space("Space 4", "Description Space 4", ProgressState.NotStarted, new List<Section>())
            };

            return spaces;
        }

        [Fact]
        public async Task GetAllAsync_Successfully()
        {
            var spaces = GetTestSpaces();

            await _context.Spaces.AddRangeAsync(spaces);
            await _context.SaveChangesAsync();

            var result = await _spaceRepository.GetAllAsync();

            Assert.Equal(4, result.Count);
            Assert.Equal("Space 1", result[0].Name);
            Assert.Empty(result[1].Sections);
            Assert.Equal(ProgressState.InProgress, result[2].State);
            Assert.Equal("Description Space 4", result[3].Description);
        }
    }
}
