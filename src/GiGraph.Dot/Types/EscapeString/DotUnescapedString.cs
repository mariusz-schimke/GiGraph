using System.Diagnostics.CodeAnalysis;
using GiGraph.Dot.Output.Text.Escaping;

namespace GiGraph.Dot.Types.EscapeString;

/// <summary>
///     A string to be escaped on DOT output generation. Contrarily to <see cref="DotEscapedString" />, the string will
///     undergo further processing to make sure that the DOT output is syntactically correct, and that the string is
///     interpreted as expected (WYSIWYG). By using this class you can be sure that the value you specify will be visualized exactly
///     the way it was provided (as a label, for example), even if it contains special characters (they will be escaped or replaced
///     with their 'safe' counterparts).
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

    [return: NotNullIfNotNull(nameof(value))]
    public static implicit operator DotUnescapedString?(string? value) => value is not null ? new DotUnescapedString(value) : null;
}