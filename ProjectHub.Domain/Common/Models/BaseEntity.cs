using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ProjectHub.Domain.Common.Models;

public abstract class BaseEntity
{
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;

    [DataType(DataType.DateTime)]
    public DateTime? ModifiedAt { get; protected set; }

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
