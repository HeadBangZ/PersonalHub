using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Domain.Workspace.Enums;
using ProjectHub.Domain.Workspace.ValueObjects;

namespace ProjectHub.Tests.Unit.Domain.Entities;

public class SpaceTests
{
    [Fact]
    public void SetProperties_Successfully()
    {
        var s = new Space("name", "description");

        Assert.Equal("name", s.Name);
        Assert.Equal("description", s.Description);
        Assert.Equal(ProgressState.NotStarted, s.State);
        Assert.Empty(s.Sections);
    }
}
