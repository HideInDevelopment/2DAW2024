namespace Actividad2.Functions;

public static class ExtensionFunctions
{
    public static bool IsNullOrEmpty<T>(IEnumerable<T>? enumerable)
    {
        return enumerable is null || !enumerable.Any();
    }

    public static bool IsNullOrDefault<T>(T value)
    {
        if (value is null) return true;
        
        var properties = typeof(T).GetProperties();
        foreach (var property in properties)
        {
            var propertyValue = property.GetValue(value);
            if (propertyValue is not null &&
                !EqualityComparer<object>.Default.Equals(propertyValue, GetDefaultValue(property.PropertyType)))
                return false;

        }
        return true;
    }

    private static object? GetDefaultValue(Type type) => type.IsValueType ? Activator.CreateInstance(type) : null;
}