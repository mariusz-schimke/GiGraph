using System;
using GiGraph.Dot.Output.Text.Escaping;

namespace GiGraph.Dot.Types.EscapeString;

/// <summary>
///     An escaped string to be rendered on output DOT script generation as is, with no further processing applied to it (no special
///     characters will be escaped or replaced). The string value has to follow the formatting rules described in the
///     <see href="https://www.graphviz.org/docs/attr-types/escString">
///         documentation
///     </see>
///     (otherwise the output DOT script may be syntactically incorrect). For comparison, see also <see cref="DotUnescapedString" />.
/// </summary>
public class DotEscapedString : DotEscapeString
{
    protected readonly string _value;

    /// <summary>
    ///     Initializes a new instance.
    /// </summary>
    /// <param name="value">
    ///     The escaped string to initialize the instance with.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when the <paramref name="value" /> is null.
    /// </exception>
    public DotEscapedString(string value)
    {
        _value = value ?? throw new ArgumentNullException(nameof(value), "Value must not be null.");
    }

    protected internal override string GetRawString() => _value;

    protected internal override string GetEscapedString(IDotTextEscaper textEscaper) => _value;

    public static implicit operator DotEscapedString(string value) => value is not null ? new DotEscapedString(value) : null;
}