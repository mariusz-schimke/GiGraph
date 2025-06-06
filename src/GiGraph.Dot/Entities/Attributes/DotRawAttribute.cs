﻿namespace GiGraph.Dot.Entities.Attributes;

/// <summary>
///     A raw value attribute. The value is rendered AS IS in the DOT output, so the attribute can be used for any type of
///     value, not only for strings. Make sure, however, that the value is escaped when necessary, following the DOT syntax rules
///     (see
///     <see href="https://www.graphviz.org/doc/info/lang.html">
///         documentation
///     </see>
///     ). If, for instance, it contains an unescaped quotation mark, the DOT output will be syntactically incorrect.
/// </summary>
public class DotRawAttribute : DotAttribute<string>
{
    /// <summary>
    ///     Creates a new instance of a raw value attribute.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute.
    /// </param>
    public DotRawAttribute(string key, string value)
        : base(key, value)
    {
    }
}