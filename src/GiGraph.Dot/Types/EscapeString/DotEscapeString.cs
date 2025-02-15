using System.Diagnostics.CodeAnalysis;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Output.Text.Escaping;

namespace GiGraph.Dot.Types.EscapeString;

/// <summary>
///     Represents the DOT escape string (see
///     <see href="https://www.graphviz.org/docs/attr-types/escString">
///         documentation
///     </see>
///     ). Implemented by <see cref="DotEscapedString" />, <see cref="DotUnescapedString" />, and
///     <see cref="DotConcatenatedEscapeString" />.
/// </summary>
public abstract partial class DotEscapeString : IDotEscapable
{
    string? IDotEscapable.GetEscaped(IDotTextEscaper textEscaper) => GetEscapedString(textEscaper);

    protected internal abstract string GetRawString();
    protected internal abstract string? GetEscapedString(IDotTextEscaper textEscaper);

    /// <summary>
    ///     Returns the underlying string.
    /// </summary>
    public override string ToString() => GetRawString();

    [return: NotNullIfNotNull(nameof(value))]
    public static implicit operator DotEscapeString?(string? value) => (DotUnescapedString?) value;

    [return: NotNullIfNotNull(nameof(value))]
    public static implicit operator string?(DotEscapeString? value) => value?.GetRawString();

    public static DotEscapeString operator +(DotEscapeString? value1, DotEscapeString? value2) => new DotConcatenatedEscapeString(value1, value2);
}