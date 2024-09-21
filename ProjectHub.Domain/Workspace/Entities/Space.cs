using ProjectHub.Domain.Common.Models;
using ProjectHub.Domain.Workspace.Enums;
using ProjectHub.Domain.Workspace.ValueObjects;

namespace ProjectHub.Domain.Workspace.Entities;

public sealed class Space : BaseEntity
{
    public SpaceId Id { get; private init; } = SpaceId.NewEntityId();

    public string Name { get; private set; }

    public string Description { get; private set; }


    private readonly List<Section> _sections = new List<Section>();
    public IReadOnlyCollection<Section> Sections => _sections.AsReadOnly();

    public ProgressState State { get; private set; } = ProgressState.NotStarted;

    public Space(string name, string description)
    {
        Name = name;
        Description = description;
        CreatedAt = DateTime.Now;
    }

    public Space(string name, string description, ProgressState state)
    {
        Name = name;
        Description = description;
        State = state;
    }

    public void AddSections(IEnumerable<Section> sections)
    {
        foreach (var section in sections)
        {
            _sections.Add(section);
        }
    }
}
