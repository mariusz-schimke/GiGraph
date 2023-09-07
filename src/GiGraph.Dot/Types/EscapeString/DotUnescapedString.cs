using System;
using GiGraph.Dot.Output.Text.Escaping;

namespace GiGraph.Dot.Types.EscapeString;

/// <summary>
///     A string to be escaped on output DOT script generation.
/// </summary>
public class DotUnescapedString : DotEscapeString
{
    protected readonly string _value;

    /// <summary>
    ///     Initializes a new instance.
    /// </summary>
    /// <param name="value">
    ///     The unescaped string to initialize the instance with.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when the <paramref name="value" /> is null.
    /// </exception>
    public DotUnescapedString(string value)
    {
        _value = value ?? throw new ArgumentNullException(nameof(value), "Value must not be null.");
    }

    protected internal override string GetRawString() => _value;

    protected internal override string GetEscapedString(IDotTextEscaper textEscaper) => textEscaper.Escape(_value);

    public static implicit operator DotUnescapedString(string value) => value is not null ? new DotUnescapedString(value) : null;
}