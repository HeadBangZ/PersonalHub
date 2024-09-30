using ProjectHub.Domain.Common.Models;
using ProjectHub.Domain.Workspace.ValueObjects;

namespace ProjectHub.Domain.Workspace.Entities;

public sealed class Section : BaseEntity
{
    public SectionId Id { get; private init; } = SectionId.NewEntityId();

    public SpaceId SpaceId { get; private set; }

    private readonly List<Epic> _epics = new List<Epic>();
    public IReadOnlyCollection<Epic> Epics => _epics.AsReadOnly();

    public string Name { get; private set; }

    public string Description { get; private set; }

    public Section(string name, string description)
    {
        Name = name;
        Description = description;
        CreatedAt = DateTime.UtcNow;
    }

    public void SetSpaceId(SpaceId id)
    {
        SpaceId = id;
    }

    public void AddEpics(IEnumerable<Epic> epics)
    {
        foreach (var epic in epics)
        {
            _epics.Add(epic);
        }
    }
}
