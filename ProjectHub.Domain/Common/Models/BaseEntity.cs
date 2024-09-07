using ProjectHub.Domain.Workspace.Entities;
using System.ComponentModel.DataAnnotations;
namespace ProjectHub.Domain.Common.Models;

public abstract class BaseEntity
{
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [DataType(DataType.DateTime)]
    public DateTime? ModifiedAt { get; set; }

    public void ApplyChanges<T>(Dictionary<string, object> changes)
    {
        if (this is not T)
        {
            return;
        }

        var properties = typeof(T).GetProperties();

        foreach (var change in changes)
        {
            var property = properties.FirstOrDefault(p => p.Name == change.Key);

            if (property != null)
            {
                property.SetValue(this, change.Value);
            }
        }

        ModifiedAt = DateTime.Now;
    }
}
