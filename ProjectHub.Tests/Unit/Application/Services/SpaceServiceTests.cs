using NSubstitute;
using NSubstitute.ExceptionExtensions;
using ProjectHub.Application.Contracts;
using ProjectHub.Application.DTOs.SpaceDtos;
using ProjectHub.Application.Services;
using ProjectHub.Domain.Contracts;
using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Domain.Workspace.Enums;
using ProjectHub.Domain.Workspace.ValueObjects;
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

        var response = await _spaceService.AddSpaceAsync(dto);

        Assert.NotNull(response);
        Assert.Equal(typeof(SpaceDtoResponse), response.GetType());
        Assert.Equal(dto.Name, response.Name);
        Assert.Equal(dto.Description, response.Description);

        await _spaceRepository.Received(1).AddAsync(Arg.Any<Space>());
    }

    [Fact]
    public async Task AddSpace_ThrowsException_WhenRepositoryFails()
    {
        var exceptionMessage = "Repository Error";

        var dto = SpaceTestData.CreateSpaceDto("name", "dto description");

        _spaceRepository.AddAsync(Arg.Any<Space>()).ThrowsAsync(new Exception(exceptionMessage));

        var exception = await Assert.ThrowsAsync<Exception>(() => _spaceService.AddSpaceAsync(dto));

        Assert.Equal(exceptionMessage, exception.Message);

        await _spaceRepository.Received(1).AddAsync(Arg.Any<Space>());
    }

    [Fact]
    public async Task GetAllSpaces_Successfully()
    {
        var data = SpaceTestData.CreateMultipleEntityData(3);

        var spaces = _spaceRepository.GetAllAsync().Returns(data);

        var result = await _spaceService.GetAllSpacesAsync();

        Assert.NotNull(result);
        Assert.Equal(3, result.Count);

        for (int i = 0; i < data.Count; i++)
        {
            Assert.Equal(data[i].Name, result[i].Name);
            Assert.Equal(data[i].Description, result[i].Description);
        }

        await _spaceRepository.Received(1).GetAllAsync();
    }

    [Fact]
    public async Task GetAllSpaces_ThrowsException_WhenRepositoryFails()
    {
        var exceptionMessage = "Repository Error";

        _spaceRepository.GetAllAsync().ThrowsAsync(new Exception(exceptionMessage));

        var exception = await Assert.ThrowsAsync<Exception>(() => _spaceService.GetAllSpacesAsync());

        Assert.Equal(exceptionMessage, exception.Message);

        await _spaceRepository.Received(1).GetAllAsync();
    }

    [Fact]
    public async Task GetSpaceById_Successfully()
    {
        var spaces = SpaceTestData.SeedData();

        var id = spaces.First().Id;

        _spaceRepository.GetAsync(Arg.Any<SpaceId>()).Returns(Task.FromResult<Space?>(spaces.First()));

        var result = await _spaceService.GetSpaceAsync(id.Id);

        Assert.NotNull(result);
        Assert.Equal(spaces.First().Name, result?.Name);
        Assert.Equal(spaces.First().Description, result?.Description);
    }

    [Fact]
    public async Task GetSpaceById_Failed()
    {
        var spaces = SpaceTestData.SeedData();

        var id = Guid.NewGuid();

        _spaceRepository.GetAsync(Arg.Any<SpaceId>()).Returns(Task.FromResult<Space?>(null));


        var result = await _spaceService.GetSpaceAsync(id);

        Assert.Null(result);
    }

    [Fact]
    public async Task DeleteSpaceById_Successfully()
    {
        var spaces = SpaceTestData.SeedData();

        var id = spaces.First().Id;

        await _spaceService.DeleteSpaceAsync(id.Id);

        await _spaceRepository.Received(1).DeleteAsync(id);
    }

    [Fact]
    public async Task DeleteSpaceById_ThrowException_WhenRepositoryFails()
    {
        var exceptionMessage = "Repository Error";

        var id = Guid.NewGuid();

        _spaceRepository.DeleteAsync(Arg.Any<SpaceId>()).ThrowsAsync(new Exception(exceptionMessage));

        var exception = await Assert.ThrowsAsync<Exception>(() => _spaceService.DeleteSpaceAsync(id));

        Assert.Equal(exceptionMessage, exception.Message);
        await _spaceRepository.Received(1).DeleteAsync(new SpaceId(id));
    }

    [Fact]
    public async Task UpdateSpace_Successfully()
    {
        var spaces = SpaceTestData.SeedData();

        var id = spaces.First().Id;
        var dto = new UpdateSpaceDtoRequest(id.Id, "Updated Space", "Description!?", ProgressState.Completed);

        _spaceRepository.GetAsync(Arg.Any<SpaceId>()).Returns(Task.FromResult<Space?>(spaces.First()));
        _spaceRepository.UpdateAsync(Arg.Any<Space>()).Returns(Task.FromResult<Space?>(spaces.First()));

        await _spaceService.UpdateSpaceAsync(id.Id, dto);

        Assert.Equal(dto.Name, spaces.First().Name);
        Assert.Equal(dto.Description, spaces.First().Description);
        Assert.Equal(dto.State, spaces.First().State);

        await _spaceRepository.Received(1).UpdateAsync(spaces.First());
    }

    [Fact]
    public async Task UpdateSpace_ThrowException_WhenEntityNotExist()
    {
        var id = Guid.NewGuid();
        var dto = new UpdateSpaceDtoRequest(id, "Updated Space", "Description!?", ProgressState.Completed);
        var exceptionMessage = $"Space with ID - {id} was not found";

        _spaceRepository.GetAsync(Arg.Any<SpaceId>()).Returns(Task.FromResult<Space?>(null));

        var result = await _spaceService.UpdateSpaceAsync(id, dto);

        Assert.False(result);
    }
}
