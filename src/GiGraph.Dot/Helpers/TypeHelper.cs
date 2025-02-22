namespace GiGraph.Dot.Helpers;

internal static class TypeHelper
{
    public static string GetDisplayName<T>() => GetDisplayName(typeof(T));

    public static string GetDisplayName(Type type) => Nullable.GetUnderlyingType(type) is { } nullable
        ? $"{nullable.Name}?"
        : type.Name;

    public static Type Unwrap(Type type) => Nullable.GetUnderlyingType(type) ?? type;
}