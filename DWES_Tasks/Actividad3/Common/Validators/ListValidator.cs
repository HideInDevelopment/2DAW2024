namespace Actividad3.Common.Validators;

public static class ListValidator
{
    public static bool IsNullOrEmpty<T>(IEnumerable<T>? enumerable)
    {
        return enumerable is null  || !enumerable.Any();
    }
}