using PersonalHub.Domain.Workspace.Entities;
using PersonalHub.Domain.Workspace.Enums;
using PersonalHub.Domain.Workspace.ValueObjects;

namespace PersonalHub.Tests.Unit.Domain.Entities;

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
