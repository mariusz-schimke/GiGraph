namespace GiGraph.Dot.Entities.Attributes;

/// <summary>
///     A custom attribute. The value is rendered AS IS in the output DOT script, so the attribute can be used for any type of value,
///     not only for strings. Make sure, however, that the value is escaped when necessary, following the DOT syntax rules (
///     <see href="https://graphviz.org/doc/info/lang.html" />). If, for instance, it contains an unescaped quotation mark, the
///     output script will be syntactically incorrect.
/// </summary>
public record DotCustomAttribute : DotAttribute<string>
{
    /// <summary>
    ///     Creates a new instance of a custom attribute.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute.
    /// </param>
    public DotCustomAttribute(string key, string value)
        : base(key, value)
    {
    }
}