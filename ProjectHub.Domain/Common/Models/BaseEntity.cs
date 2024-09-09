using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ProjectHub.Domain.Common.Models;

public abstract class BaseEntity
{
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [DataType(DataType.DateTime)]
    public DateTime? ModifiedAt { get; set; }

    public void ApplyChanges<T>(IReadOnlyDictionary<string, object> changes, IDictionary<string, PropertyInfo> properties)
    {
        if (this is not T)
        {
            return;
        }

        foreach (var change in changes)
        {
            if (properties.TryGetValue(change.Key, out var property) && property.CanWrite)
            {
                property.SetValue(this, change.Value);
            }
        }

        ModifiedAt = DateTime.Now;
    }
}
