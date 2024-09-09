using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Reflection;

namespace ProjectHub.Application.Shared;

public static class DeltaFinder
{
    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> PropertyCache = new ConcurrentDictionary<Type, PropertyInfo[]>();

    public static IReadOnlyDictionary<string, object> GetChangedProperties<TSource, TTarget>(TSource source, TTarget target)
    {
        var changes = new Dictionary<string, object>();

        var sourceProperties = GetPropertyCache(typeof(TSource));
        var targetProperties = GetPropertyCache(typeof(TTarget));

        foreach (var sourceProperty in sourceProperties)
        {
            if (sourceProperty.Name == "Id")
            {
                continue;
            }

            var targetProperty = targetProperties.FirstOrDefault(p => p.Name == sourceProperty.Name);

            if (targetProperty != null && targetProperty.CanRead && sourceProperty.CanRead)
            {
                var sourceValue = sourceProperty.GetValue(source);
                var targetValue = targetProperty.GetValue(target);

                if (sourceValue != null && !sourceValue.Equals(targetValue))
                {
                    changes.Add(sourceProperty.Name, sourceValue);
                }
            }
        }

        return new ReadOnlyDictionary<string, object>(changes);
    }

    private static PropertyInfo[] GetPropertyCache(Type type)
    {
        return PropertyCache.GetOrAdd(type, type.GetProperties());
    }

    public static IDictionary<string, PropertyInfo> GetPropertyDictionary<T>()
    {
        return GetPropertyCache(typeof(T)).ToDictionary(p => p.Name);
    }
}
