namespace GiGraph.Dot.Entities.Attributes.Properties.Extensions;

internal static class OptionalExtension
{
    public static void IfSet<T>(this T? value, Action<T> apply)
        where T : struct
    {
        if (value is not null)
        {
            apply(value.Value);
        }
    }

    public static void IfSet<T>(this T? value, Action<T> apply)
        where T : class
    {
        if (value is not null)
        {
            apply(value);
        }
    }
}