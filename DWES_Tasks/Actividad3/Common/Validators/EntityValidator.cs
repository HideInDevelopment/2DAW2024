namespace Actividad3.Common.Validators;

public static class EntityValidator
{
    public static bool IsNullOrDefault<T>(T value)
    {
        if (value is null) return true;
        
        var properties = typeof(T).GetProperties();
        foreach (var property in properties)
        {
            var propertyValue = property.GetValue(value);
            if (propertyValue is not null && EqualityComparer<object>.Default.Equals(propertyValue,
                    GenericValidator.GetDefaultValue(property.PropertyType)))
            {
                return false;
            }
        }
        return true;
    }
}