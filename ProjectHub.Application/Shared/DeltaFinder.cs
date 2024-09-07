namespace ProjectHub.Application.Shared;

public sealed class DeltaFinder
{
    public static Dictionary<string, object> GetChangedProperties<TSource, TTarget>(TSource source, TTarget target)
    {
        var changes = new Dictionary<string, object>();

        var sourceProperties = typeof(TSource).GetProperties();
        var targetProperties = typeof(TTarget).GetProperties();

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

        return changes;
    }
}
