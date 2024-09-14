using NSubstitute;
using NSubstitute.ExceptionExtensions;
using ProjectHub.Application.Contracts;
using ProjectHub.Application.DTOs.SpaceDtos;
using ProjectHub.Application.Services;
using ProjectHub.Domain.Contracts;
using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Tests.Unit.Seeder;

namespace ProjectHub.Tests.Unit.Application.Services;

public class SpaceServiceTests : IAsyncLifetime
{
    private readonly ISpaceRepository _spaceRepository;
    private readonly ISpaceService _spaceService;

    public SpaceServiceTests()
    {
        _spaceRepository = Substitute.For<ISpaceRepository>();
        _spaceService = new SpaceService(_spaceRepository);
    }

    public Task InitializeAsync() => Task.CompletedTask;
    public Task DisposeAsync() => Task.CompletedTask;

    [Fact]
    public async Task AddSpace_Successfully()
    {
        var dto = SpaceTestData.CreateSpaceDto("name", "dto description");

        var response = await _spaceService.AddSpace(dto);

        Assert.NotNull(response);
        Assert.Equal(typeof(SpaceDtoResponse), response.GetType());
        Assert.Equal(dto.Name, response.Name);
        Assert.Equal(dto.Description, response.Description);

        await _spaceRepository.Received(1).AddAsync(Arg.Any<Space>());
    }

    [Fact]
    public async Task AddSpace_ThrowsException_WhenRepositoryFails()
    {
        var dto = SpaceTestData.CreateSpaceDto("name", "dto description");

        _spaceRepository.AddAsync(Arg.Any<Space>()).ThrowsAsync(new Exception("Repository Error"));

        var exception = await Assert.ThrowsAsync<Exception>(() => _spaceService.AddSpace(dto));

        Assert.Equal("Repository Error", exception.Message);

        await _spaceRepository.Received(1).AddAsync(Arg.Any<Space>());
    }
}
